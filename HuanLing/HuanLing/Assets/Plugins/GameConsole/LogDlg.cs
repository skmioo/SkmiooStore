using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace UYMO.GameConsole
{
    public class LogDlg:ConsoleDlgBase
    {
        ScrollRect _ScrollView;
        Text _PageInfo;
        List<Text> _LogLines = new List<Text>(LogMgr.CountPerList);
        Queue<Text> _IdleText = new Queue<Text>();

        GameObject _DetailPanel;
        InputField _DetailText;
        InputField _LogIdxInput;

        int _CurPage;
        float _YPos;
        float _MaxWidth;
        int _InvalidBeginIdx = -1;
        public LogDlg():base("LogDlg")
        {

        }
        protected override void OnInit()
        {
            _DetailPanel = GetChild("DetailPanel");
            _DetailPanel.SetActive(false);
            _DetailText = GetCtrl<InputField>(_DetailPanel, "InputField");
            var hideDetailBtn = GetButton("CloseDetail");
            hideDetailBtn.onClick.AddListener(_HandleHideDetail);

            _LogIdxInput = GetCtrl<InputField>("IdxInput");
            var showDetailBtn = GetButton("ShowDetail");
            showDetailBtn.onClick.AddListener(_HanldeShowDetail);

            _ScrollView = GetCtrl<ScrollRect>("Scroll View");
            _PageInfo = GetText("PageInfo");
            var prePageBtn = GetButton("PrePage");
            prePageBtn.onClick.AddListener(_HandlePrePage);
            var nextPageBtn = GetButton("NextPage");
            nextPageBtn.onClick.AddListener(_HandleNextPage);

            int _CurPage = LogMgr.me.pageCount - 1;
            _CurPage = Math.Max(0, _CurPage);
            _RefreshPage();
        }

        private void _HandleNextPage()
        {
            ++_CurPage;
            _CurPage = Math.Min(_CurPage, LogMgr.me.pageCount - 1);
            _CurPage = Math.Max(0, _CurPage);
            _RefreshPage();
        }

        private void _HandlePrePage()
        {
            --_CurPage;
            _CurPage = Math.Min(_CurPage, LogMgr.me.pageCount - 1);
            _CurPage = Math.Max(0, _CurPage);
            _RefreshPage();
        }

        private void _RefreshPage()
        {
            _PageInfo.text = string.Format("{0}/{1}", _CurPage + 1, LogMgr.me.pageCount);
            for( var idx = 0; idx < _LogLines.Count; ++idx )
            {
                ReleaseLogLine(_LogLines[idx]);
            }
            _LogLines.Clear();

            int logCount = LogMgr.me.GetCountOfPage(_CurPage);
            for( var idx = 0; idx < logCount; ++idx )
            {
                var log = LogMgr.me.GetLog(_CurPage, idx);
                Text line = GetLogLine();
                line.text = log.Brief(_LogLines.Count);
                line.color = log.color;
                _LogLines.Add(line);
            }

            _YPos = 0;
            _MaxWidth = 0;
            _InvalidBeginIdx = 0;

            if (!IsInvoking("Layout"))
            {
                Invoke("Layout", 0.3f);
            }
        }

        public void RecivedLog(LogMgr.LogItem log)
        {
            _PageInfo.text = string.Format("{0}/{1}", _CurPage + 1, LogMgr.me.pageCount);
            bool lastPage = _CurPage == LogMgr.me.pageCount - 1;
            if(!lastPage)
            {//不是最后一页，不用加
                return;
            }

            if (_LogLines.Count >= LogMgr.CountPerList)
            {//当前页满了，下一页
                _HandleNextPage();
                return;
            }

            Text line = GetLogLine();
            line.text = log.Brief(_LogLines.Count);
            line.color = log.color;
            line.rectTransform.anchoredPosition = new Vector2(0, -_YPos);
            _LogLines.Add(line);

            if (_InvalidBeginIdx == -1 )
            {
                _InvalidBeginIdx = _LogLines.Count - 1;
            }
            
            if(!IsInvoking("Layout"))
            {
                Invoke("Layout", 0.3f);
            }
        }

        void Layout()
        {
            if (_InvalidBeginIdx >= 0)
            {
                for (var idx = _InvalidBeginIdx; idx < _LogLines.Count; ++idx)
                {
                    try
                    {
                        var line = _LogLines[idx];
                        RectTransform lineTrans = line.rectTransform;
                        lineTrans.anchoredPosition = new Vector2(10, -_YPos);
                        _YPos += line.preferredHeight;
                        _MaxWidth = Math.Max(10+line.preferredWidth, _MaxWidth);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }

                }
                _InvalidBeginIdx = -1;

                var size = _ScrollView.content.sizeDelta;
                _ScrollView.content.sizeDelta = new Vector2(_MaxWidth, _YPos);
                _ScrollView.verticalNormalizedPosition = 0;
            }
        }

        private Text GetLogLine()
        {
            Text ret = null;
            if(_IdleText.Count > 0 )
            {
                ret = _IdleText.Dequeue();
            }
            else
            {
                ret = GetCtrl<Text>(_ScrollView.content.gameObject, "Text");
                GameObject n = UIUtil.Instantiate(ret.gameObject, ret.transform.parent);
                n.transform.localScale = Vector2.one;
                ret = n.GetComponent<Text>();
            }
            ret.gameObject.SetActive(true);
            return ret;
        }
        private Text ReleaseLogLine(Text line)
        {
            line.gameObject.SetActive(false);
            _IdleText.Enqueue(line);
            return null;
        }

        private void _HandleHideDetail()
        {
            _DetailPanel.SetActive(false);
        }
        private void _HanldeShowDetail()
        {
            string str = _LogIdxInput.text;
            int idx;
            if(int.TryParse(str, out idx))
            {
                if(idx >= 0 && idx < LogMgr.me.GetCountOfPage(_CurPage))
                {
                    var log = LogMgr.me.GetLog(_CurPage, idx);
                    _DetailPanel.SetActive(true);
                    _DetailText.text = string.Format("{0}\n{1}", log.Brief(idx), log.stackTrace);
                }
            }
        }
    }

    public class LogMgr:SingletonAuto<LogMgr>
    {
        public struct LogItem
        {
            public string contition;
            public string stackTrace;
            public LogType type;

            static readonly string[] TypeTags = { "Error", "Assert", "Warning", "Log", "Exception" };
            static readonly Color[] TypeColors = { Color.red, Color.red, Color.yellow, Color.white, Color.red };

            public Color color
            {
                get
                {
                    return TypeColors[(int)type];
                }
            }
            public string Brief(int idx)
            {
                return string.Format("{0}[{1}]:{2}", idx, TypeTags[(int)type], contition);
            }
        }
        public const int CountPerList = 100;
        List<List<LogItem>> _Logs = new List<List<LogItem>>(CountPerList);
        public LogMgr()
        {
            _Logs.Add(new List<LogItem>(CountPerList));
            Application.logMessageReceived += Application_logMessageReceived;
        }

        public int logCount
        {
            get
            {
                return CountPerList * (_Logs.Count - 1) + _Logs[_Logs.Count - 1].Count;
            }
        }

        public int pageCount
        {
            get
            {
                return _Logs.Count;
            }
        }

        public int GetCountOfPage(int page)
        {
            return _Logs[page].Count;
        }

        public LogItem GetLog(int idx)
        {
            int pageIdx = idx / CountPerList;
            int itemIdx = idx % CountPerList;
            return GetLog(pageIdx, itemIdx);
        }

        public LogItem GetLog(int page, int idx )
        {
            return _Logs[page][idx];
        }

        private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
        {
            List<LogItem> lasList = _Logs[_Logs.Count - 1];
            if (lasList.Count >= CountPerList)
            {
                lasList = new List<LogItem>(CountPerList);
                _Logs.Add(lasList);
            }
            LogItem item;
            item.contition = condition;
            item.stackTrace = stackTrace;
            item.type = type;
            lasList.Add(item);

            var dlg = ConsoleMgr.TryGetDlg<LogDlg>();
            if(dlg)
            {
                dlg.RecivedLog(item);
            }
        }
    }
}
