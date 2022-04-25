using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UObject = UnityEngine.Object;
public class SchudleManger : SingleObject<SchudleManger>
{

    void Start() {
        StartCoroutine(StartExecuteSchudle());
        StartCoroutine(StarExecuteLoopSchudle());
    }
    class SchudelItem
    {
        public UnityAction action = null;
        public float delayTime = 0f;
        public bool isLoop = false;
        public int loopCount = 0;
        public bool isStop = false;
        public int aleryLoopCount = 0;
        public UnityAction loopFinishCallback = null;
        public float startTime = 0f;
        public UObject refenceObj = null;
        public bool haveRefenceObj = false;
        public bool destroyed { get { return _isDestroy; } }
        private bool _isDestroy = false;
        public SchudelItem(UnityAction action, float time, bool isLoop, int loopCount,UnityAction loopFinishCallback)
        {
            this.action = action;
            this.isLoop = isLoop;
            this.loopCount = loopCount;
            this.delayTime = time;
            this.loopFinishCallback = loopFinishCallback;
        }
        public void Destroy() {
            _isDestroy = true;
        }
    }

    private List<SchudelItem> _allSchuldeItems = new List<SchudelItem>();
    public void Schudle(UnityAction action, float time, bool isLoop = false, int loopCount = -1,UnityAction loopFinishCallback = null)
    {
        if (isLoop && loopCount <= 0) return;
        if (time <= 0) {
            action.Invoke();
            return;
        } 
        SchudelItem temp = new SchudelItem(action, time, isLoop, loopCount, loopFinishCallback);
        temp.startTime = Time.time;
        _allSchuldeItems.Add(temp);
    }

    public void Schudle(UnityAction action, float time, UObject obj, bool isLoop = false, int loopCount = -1, UnityAction loopFinishCallback = null) {
        if (isLoop && loopCount <= 0) return;
        if (time <= 0)
        {
            action.Invoke();
            return;
        }
        SchudelItem temp = new SchudelItem(action, time, isLoop, loopCount, loopFinishCallback);
        temp.startTime = Time.time;
        temp.haveRefenceObj = true;
        temp.refenceObj = obj;
        _allSchuldeItems.Add(temp);
    }

    IEnumerator StartExecuteSchudle()
    {
        float nowTime = 0f;
        SchudelItem item = null;
        while (true)
        {
            yield return null;
            if (_allSchuldeItems.Count == 0) continue;
            nowTime = Time.time;
            for (int i = 0; i<_allSchuldeItems.Count; i++) {
                item = _allSchuldeItems[i];

                if (item == null || item.destroyed || item.action == null || (item.haveRefenceObj && item.refenceObj == null)) {
                    _allSchuldeItems.RemoveAt(i);
                    i--;
                    continue;  
                }

                if (nowTime - item.startTime < item.delayTime) continue;
                SafeExecute(item.action);
                if (item.isLoop)
                {
                    item.aleryLoopCount++;
                    item.startTime = nowTime;
                    if (item.aleryLoopCount < item.loopCount) continue;
                    SafeExecute(item.loopFinishCallback);
                }
                _allSchuldeItems.RemoveAt(i);
                i--;
            }
        }
    }

    void SafeExecute(UnityAction action) {
        if (action == null) return;
        try
        {
            action.Invoke();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void UnSchudle(UnityAction action)
    {
        if (action == null) return;
        for (int i = 0; i < _allSchuldeItems.Count; i++) {
            if (action == _allSchuldeItems[i].action) {
                _allSchuldeItems[i].Destroy();
                _allSchuldeItems.RemoveAt(i);
                break;
            }
        }
    }

    public void SetRefenceObj(UnityAction action, UObject obj) {
        if (action == null) return;
        for (int i = 0; i < _allSchuldeItems.Count; i++)
        {
            if (action == _allSchuldeItems[i].action)
            {
                _allSchuldeItems[i].haveRefenceObj = true;
                _allSchuldeItems[i].refenceObj = obj;
                break;
            }
        }
    }

    public void ClearWithRefenceObj(UObject obj = null)
    {
        for (int i = 0; i < _allSchuldeItems.Count; i++)
        {
            if (obj != null && !_allSchuldeItems[i].haveRefenceObj) continue;
            if (obj != null && _allSchuldeItems[i].haveRefenceObj) {
                if(_allSchuldeItems[i].refenceObj == obj) _allSchuldeItems[i].Destroy();
                continue;
            }
            if (!_allSchuldeItems[i].haveRefenceObj) {
                _allSchuldeItems[i].Destroy();
            }
        }
    }


    public void ForceClearn() {
        _allSchuldeItems.Clear();
    }

    public void MustExecuteSchudle(UnityAction action, float time) {
        StartCoroutine(ExecuteMustSchdle(action, time));
    }

    IEnumerator ExecuteMustSchdle(UnityAction action, float time) {
        yield return new WaitForSeconds(time);
        if (action != null) action.Invoke();
    }

    public void NextFrame(UnityAction action) {
        StartCoroutine(ExecuteMustNextFrameSchdle(action));
    }
    IEnumerator ExecuteMustNextFrameSchdle(UnityAction action)
    {
        yield return null;
        if (action != null) action.Invoke();
    }

    // ......Old Schudle End

    // ......new Schudle Start
    public delegate bool LoopCondition();

   class LoopSchudleItem {
        public LoopCondition action = null;
        public float delayTime = 0f;
        public float lastExecteTime = 0f;
        public bool isStop = false;
        public UnityAction finshCallback = null;

        public bool destroyed { get { return _isDestroy; } }
        private bool _isDestroy = false;
        public LoopSchudleItem(LoopCondition action, float delayTime, float lastExecteTime, UnityAction finshCallback) {
            this.action = action;
            this.delayTime = delayTime;
            this.finshCallback = finshCallback;
            this.lastExecteTime = lastExecteTime;
        }

        public void Destroy()
        {
            _isDestroy = true;
        }
    }

    List<LoopSchudleItem> _allLoopSchudleItems = new List<LoopSchudleItem>();

    public void LoopSchudle(LoopCondition action, float time,UnityAction finshCallback = null) {
        if (action == null) return;
        if (IsRepeatAdd(action)) return;
        LoopSchudleItem item = new LoopSchudleItem(action,time,Time.time,finshCallback);
        _allLoopSchudleItems.Add(item);
    }

    bool IsRepeatAdd(LoopCondition action) {
        for (int i = 0; i < _allLoopSchudleItems.Count; i++)
        {
            if (_allLoopSchudleItems[i].action == action)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator StarExecuteLoopSchudle() {
        float nowTime = 0f;
        LoopSchudleItem item = null;
        while (true)
        {
            yield return null;
            if (_allLoopSchudleItems.Count == 0) continue;
            nowTime = Time.time;
            for (int i = 0; i < _allLoopSchudleItems.Count; i++)
            {
                item = _allLoopSchudleItems[i];
                if (item == null || item.destroyed || item.action == null)
                {
                    _allLoopSchudleItems.RemoveAt(i);
                    i--;
                    continue;
                }
                if (item.isStop) continue;
                if (nowTime - item.lastExecteTime < item.delayTime) continue;
                if (SafeExecuteLoopSchulde(item.action))
                {
                    item.lastExecteTime = nowTime;
                    continue;
                }
                SafeExecute(item.finshCallback);
                _allLoopSchudleItems.RemoveAt(i);
                i--;
            }
        }
    }

    bool SafeExecuteLoopSchulde(LoopCondition action) {
        try
        {
            return action.Invoke();
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
        return false;
    }

    public void RemoveLoopSchudle(LoopCondition action) {
        if (action == null) return;
        for (int i = 0; i < _allLoopSchudleItems.Count; i++) {
            if (_allLoopSchudleItems[i].action == action) {
                _allLoopSchudleItems[i].Destroy();
                _allLoopSchudleItems.RemoveAt(i);
                break;
            }
        }
    }

    public void RemoveLoopSchudleAll() {
        for (int i = 0; i < _allLoopSchudleItems.Count; i++)
        {
            _allLoopSchudleItems[i].Destroy();
        }
        _allLoopSchudleItems.Clear();
    }

    public void StopLoopSchudle(LoopCondition action) {
        if (action == null) return;
        for (int i = 0; i < _allLoopSchudleItems.Count; i++)
        {
            if (_allLoopSchudleItems[i].action == action)
            {
                _allLoopSchudleItems[i].isStop = true;
                break;
            }
        }
    }

    public void StartLoopchudle(LoopCondition action) {
        if (action == null) return;
        for (int i = 0; i < _allLoopSchudleItems.Count; i++)
        {
            if (_allLoopSchudleItems[i].action == action)
            {
                _allLoopSchudleItems[i].isStop = false;
                break;
            }
        }
    }
}

