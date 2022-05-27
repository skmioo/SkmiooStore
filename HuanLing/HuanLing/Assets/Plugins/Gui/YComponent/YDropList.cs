using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.EventSystems;
using UYMO;
using SLua;

namespace UnityEngine.UI
{
    [SLua.CustomLuaClass]
    [AddComponentMenu("YUI/YDropList", 12)]
    [RequireComponent(typeof(RectTransform))]
    [ExecuteInEditMode]
    public class YDropList: UIBehaviour
    {
        public enum Direction
        {
            Down,
            Up,
        }

        [SerializeField]
        YButton _Btn;
        YLabel _BtnLabel;
        [DoNotToLua]
        public YButton btnTarget
        {
            get { return _Btn; }
            set
            {
                _Btn = value;
            }
        }

        [SerializeField]
        public GameObject ListTemplate;

        [SerializeField]
        GameObject _ItemPrefab;
        [DoNotToLua]
        public GameObject itemPrefab
        {
            get { return _ItemPrefab; }
            set { _ItemPrefab = value; }
        }

        /// <summary>
        /// 方向，向上还是向下
        /// </summary>
        [SerializeField]
        private Direction _Direction = Direction.Down;
        public Direction direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        } 

        GameObject _List;
        GameObject _Blocker;
        List<object> _Options;
        int _Selected;

        object _listener;
        Action<object, int> _callback;

        object _clickChecker;
        Func<object,int, bool> _checkClickCallback;

        LuaTable  _UpdateTable;
        Action<LuaTable, GameObject, int> _UpdateCallback;
        private string _WinName = null;

        static List<Canvas> sCanvasList = new List<Canvas>();

        protected override void Awake()
        {
            if (ListTemplate == null)
            {
                ListTemplate = NewGameObject("ListTemplate");
                var img = ListTemplate.AddComponent<YImage>();
                img.type = YImage.Type.Sliced;
                img.imageID = new UYMO.ResID(5, 11, 130);
                var ysr = ListTemplate.AddComponent<YScrollRect>();
                RectTransform listRT = FetchComonent<RectTransform>(ListTemplate);
                listRT.SetParent(transform);
                listRT.pivot = new Vector2(0.5f, 1);
                listRT.localScale = Vector2.one;
                listRT.anchorMin = new Vector2(0, 1);
                listRT.anchorMax = new Vector2(1, 1);
                listRT.offsetMin = new Vector2(0, -100);
                listRT.offsetMax = Vector2.zero;
                ListTemplate.SetActive(false);


                var maskObj = NewGameObject("mask");
                maskObj.AddComponent<YImage>();
                var mask = maskObj.AddComponent<Mask>();
                mask.showMaskGraphic = false;
                mask.enabled = false;
                var maskRT = FetchComonent<RectTransform>(maskObj);
                maskRT.SetParent(listRT);
                maskRT.anchorMin = Vector2.zero;
                maskRT.anchorMax = Vector2.one;
                maskRT.offsetMin = new Vector2(10, 15);
                maskRT.offsetMax = new Vector2(-10, -10);

                var content = NewGameObject("Content");
                var contentRT = FetchComonent<RectTransform>(content);
                var vl = content.AddComponent<VerticalLayoutGroup>();
                vl.padding.top = 10;
                vl.spacing = 10;
                vl.childForceExpandHeight = false;
                vl.childAlignment = TextAnchor.UpperCenter;
                var cs = content.AddComponent<ContentSizeFitter>();
                cs.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                contentRT.SetParent(maskRT);
                contentRT.anchorMin = new Vector2(0, 1);
                contentRT.anchorMax = Vector2.one;
                contentRT.offsetMin = Vector2.zero;
                contentRT.offsetMax = Vector2.zero;

                ysr.viewport = maskRT;
                ysr.content = contentRT;
            }
            if (ListTemplate.GetComponent<YScrollRect>() == null)
            {
                var ys = ListTemplate.AddComponent<YScrollRect>();
                ys.horizontal = false;
                ys.vertical = false;
            }
            else
            {
                if (!Application.isPlaying)
                {
                    //增加个把多余的YScrollRect删除
                    List<YScrollRect> ysr = ListTemplate.GetComponents<YScrollRect>().ToList();
                    if (ysr.Count > 1)
                    {
                        for (int i = 1; i < ysr.Count; i++)
                        {
                            if (ysr[i].content == null)
                            {
                                DestroyImmediate(ysr[i]);
                            }
                        }
                        ysr.Clear();
                    }
                }
            }

            RectTransform btnRT = null;
            RectTransform btnLabelRT = null;
            if(_Btn == null)
            {
                var btnObj = NewGameObject("Button");
                var img = btnObj.AddComponent<YImage>();
                img.type = YImage.Type.Sliced;
                img.imageID = new UYMO.ResID(5, 11, 129);
                _Btn = btnObj.AddComponent<YButton>();
                _Btn.image = img;
                btnRT = FetchComonent<RectTransform>(btnObj);
                btnRT.SetParent(transform);

                var btnLabelObj = NewGameObject("BtnLabel");
                _BtnLabel = btnLabelObj.AddComponent<YLabel>();
                _BtnLabel.configColor = "黑";
                _BtnLabel.fontSize = 22;
                btnLabelRT = FetchComonent<RectTransform>(btnLabelObj);
                btnLabelRT.SetParent(btnRT);

                _Btn.label = _BtnLabel;
            }
            else
            {
                _BtnLabel = _Btn.label;
                btnRT = _Btn.GetComponent<RectTransform>();
                btnLabelRT = _BtnLabel.GetComponent<RectTransform>();
            }

            btnRT.anchorMax = Vector2.one;
            btnRT.anchorMin = Vector2.zero;
            btnRT.offsetMax = Vector2.zero;
            btnRT.offsetMin = Vector2.zero;
            btnRT.localScale = Vector3.one;

            btnLabelRT.anchorMax = Vector2.one;
            btnLabelRT.anchorMin = Vector2.zero;
            btnLabelRT.offsetMax = Vector2.zero;
            btnLabelRT.offsetMin = Vector2.zero;

            _Btn.eClick += _ShowList;

            _Options = new List<object>();
            _Selected = -1;
        }

        private void _ShowList(YButton btn)
        {
            //再次点击将是关闭
            if(_Blocker == null)
            {
                Show();
            }
            else
            {
                Hide();
            }
            
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }
        /// <summary>
        /// 当前选中项索引
        /// </summary>
        public int selectedIdx
        {
            get
            {
                return _Selected;
            }
            set
            {
                SetSelected(value, true);
            }
        }
        /// <summary>
        /// 设置YDropList是否禁用点击
        /// </summary>
        public void SetEnabled(bool isEnable)
        {
            _Btn.enabled = isEnable;
        }
        /// <summary>
        /// 设置当前选中项
        /// </summary>
        /// <param name="idx">选项索引</param>
        /// <param name="notify">选中项变化，是否通知</param>
        public void SetSelected(int idx, bool notify)
        {
            if(idx != _Selected)
            {
                //放到上面，为了可以设置成非选中的值，如果有问题再看怎么改
                _Selected = idx;
                //检查是否可以选中
                if (_checkClickCallback != null && !_checkClickCallback(_clickChecker,idx))
                {
                    return;
                }
                //_Selected = idx;
                if(idx < 0 || idx >= _Options.Count )
                {
                    Debug.LogWarningFormat("invalid idx:{0} option count:{1} ", idx, _Options.Count);
                    return;
                }
                var item = _Options[_Selected];
                _Btn.text = item.ToString();
                if(notify && _callback != null)
                {
                    _callback(_listener, _Selected);
                }
            }
        }
        /// <summary>
        /// 设置所有可用选项
        /// </summary>
        public void SetOptions(IEnumerable<object> options)
        {
            _Options.Clear();
            var enu =  options.GetEnumerator();
            while(enu.MoveNext())
            {
                _Options.Add(enu.Current);
            }
            _SetPanelSize();
        }

        private void _SetPanelSize()
        {

        }

        public void SetOptionsByStringArray(string[] options)
        {
            SetOptions(options);
        }

        private void Item_eClick(YButton btn)
        {
            int idx = (int)btn.userData;
            SetSelected(idx, true);
            Hide();
        }

        /// <summary>
        /// 获取选项
        /// </summary>
        /// <param name="idx">选项索引</param>
        /// <returns>选项对象</returns>
        public object GetOption(int idx)
        {
            return idx >= 0 && idx < _Options.Count ? _Options[idx] : null;
        }
        /// <summary>
        /// 设置选中项改变回调
        /// </summary>
        /// <param name="listener">监听者</param>
        /// <param name="callback">回调函数</param>
        public void SetSelectChangedCallback(object listener, Action<object, int> callback)
        {
            _listener = listener;
            _callback = callback;
        }

          /// <summary>
        /// 设置更新回调
        /// </summary>
        /// <param name="luaTable">监听者</param>
        /// <param name="luaCallBack">回调函数</param>
        public void SetLuaUpdateCallback(LuaTable luaTable, Action<LuaTable,GameObject, int> luaCallBack)
        {
            _UpdateTable = luaTable;
            _UpdateCallback = luaCallBack;
        }
        /// <summary>
        /// 检查是否可以触发选中
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="func"></param>
        public void SetCheckClickCallBack(object caller, Func<object,int, bool> func)
        {
            _clickChecker = caller;
            _checkClickCallback = func;
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void Show()
        {
            if(ListTemplate == null)
            {
                Debug.LogError("List Template can't be null。。。");
                return;
            }
            if(_List != null)
            {
                return;
            }

            _List = UIUtil.Instantiate(ListTemplate, transform);
            _List.name = "List";
            _List.transform.SetSiblingIndex(0);
            _List.SetActive(true);

            YScrollRect ysr = _List.GetComponent<YScrollRect>();
            if(ysr ==null)
            {
                Debug.LogError("list template is no valid, the YScrollRect must on the template GameObject");
                return;
            }
            if( ysr.content == null)
            {
                Debug.LogError("list template is no valid, the content of YScrollRect must not be empty!");
                return;
            }

            sCanvasList.Clear();
            gameObject.GetComponentsInParent(false, sCanvasList);
            if (sCanvasList.Count == 0)
                return;
            Canvas rootCanvas = sCanvasList[0];

            //Canvas btnCanvas = FetchComonent<Canvas>(_Btn.gameObject);
            //btnCanvas.overrideSorting = true;
            //btnCanvas.sortingLayerName = rootCanvas.sortingLayerName;
            //btnCanvas.sortingOrder = 30001;

            Canvas listCanvas = FetchComonent<Canvas>(gameObject);
            listCanvas.overrideSorting = true;
            listCanvas.sortingLayerName = rootCanvas.sortingLayerName;
            listCanvas.sortingOrder = 30000;
            FetchComonent<GraphicRaycaster>(gameObject);
            FetchComonent<CanvasGroup>(gameObject);

            float cellHeight = 0;
            for (var idx = 0; idx < _Options.Count; ++idx)
            {
                YButton item = CreateItem();
                item.transform.SetParent(ysr.content);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.one;
                item.userData = idx;
                item.text = _Options[idx].ToString();
                item.eClick += Item_eClick;
                if(_UpdateTable != null && _UpdateCallback != null)
                {
                    _UpdateCallback(_UpdateTable, item.gameObject, (idx + 1));
                }
                cellHeight = (item.transform as RectTransform).sizeDelta.y;
            }

            //计算conteng节点和YScrollRect节点产生的
            float offset = 0;
            Transform t;
            t = ysr.content;
            while(t != _List.transform)
            {
                offset += t.localPosition.y;
                t = t.parent;
            }

            VerticalLayoutGroup group = ysr.content.GetComponent<VerticalLayoutGroup>();
            float padding = group.padding.bottom + group.padding.top;
            float height = cellHeight * _Options.Count + padding + group.spacing * (_Options.Count - 1) + Mathf.Abs(offset);
            Vector2 size = (_List.transform as RectTransform).sizeDelta;
            size.y = height;
            (_List.transform as RectTransform).sizeDelta = size;
            //如果向上，需要调整PosY
            if (_Direction == Direction.Up)
            {
                Vector3 pos = _List.transform.localPosition;
            pos.y += height;
            _List.transform.localPosition = pos;
            }
            _Blocker = CreateBlocker(rootCanvas);
        }

        protected GameObject CreateBlocker(Canvas rootCanvas)
        {
            // Create blocker GameObject.
            GameObject blocker = NewGameObject("Blocker");

            // Setup blocker RectTransform to cover entire root canvas area.
            RectTransform blockerRect = blocker.AddComponent<RectTransform>();
            blockerRect.SetParent(rootCanvas.transform, false);
            blockerRect.anchorMin = Vector3.zero;
            blockerRect.anchorMax = Vector3.one;
            blockerRect.sizeDelta = Vector2.zero;

            // Make blocker be in separate canvas in same layer as dropdown and in layer just below it.
            Canvas blockerCanvas = blocker.AddComponent<Canvas>();
            blockerCanvas.overrideSorting = true;
            Canvas dropdownCanvas = gameObject.GetComponent<Canvas>();
            blockerCanvas.sortingLayerID = dropdownCanvas.sortingLayerID;
            blockerCanvas.sortingOrder = dropdownCanvas.sortingOrder - 1;

            // Add raycaster since it's needed to block.
            blocker.AddComponent<GraphicRaycaster>();

            // Add image since it's needed to block, but make it clear.
            Image blockerImage = blocker.AddComponent<Image>();
            blockerImage.color = Color.clear;

            // Add button since it's needed to block, and to close the dropdown when blocking area is clicked.
            Button blockerButton = blocker.AddComponent<Button>();
            blockerButton.onClick.AddListener(Hide);

            return blocker;
        }
        /// <summary>
        /// 隐藏列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Hide()
        {
            //if(_Btn != null)
            //{
            //    var canvas = _Btn.GetComponent<Canvas>();
            //    Destroy(canvas);
            //}

            var cgrp = gameObject.GetComponent<CanvasGroup>();
            Destroy(cgrp);
            var ray = gameObject.GetComponent<GraphicRaycaster>();
            Destroy(ray);
            var canvas = gameObject.GetComponent<Canvas>();
            Destroy(canvas);

            UIUtil.DestroyUIGameObject(_List);
            _List = null;
            if (_Blocker != null)
            {
                Destroy(_Blocker);
                _Blocker = null;
            }
        }

        private T FetchComonent<T>(GameObject obj) where T : Component
        {
            T ret = obj.GetComponent<T>();
            if( ret == null)
            {
                ret = obj.AddComponent<T>();
            }
            return ret;
        }

        private GameObject NewGameObject(string name)
        {
            var ret = new GameObject(name);
            ret.layer = UYMO.LayerIndex.UI;
            return ret;
        }

        private YButton CreateItem()
        {
            YButton ret = null;
            if (_ItemPrefab != null)
            {
                var obj = UIUtil.Instantiate(_ItemPrefab);
                obj.name = "Item";
                ret = obj.GetComponent<YButton>();
            }
            else
            {
                var obj = NewGameObject("Item");
                ret = obj.AddComponent<YButton>();
                // obj.AddComponent<HorizontalLayoutGroup>();
                var objRT = FetchComonent<RectTransform>(obj);

                var labelObj = NewGameObject("Label");
                var labelRT = FetchComonent<RectTransform>(labelObj);
                labelRT.SetParent(objRT);
                labelRT.localPosition = Vector3.one;
                labelRT.localScale = Vector3.one;
                labelRT.anchorMin = Vector2.zero;
                labelRT.anchorMax = Vector2.one;
                labelRT.offsetMin = Vector2.zero;
                labelRT.offsetMax = Vector2.zero;
                var label = FetchComonent<YLabel>(labelObj);
                label.configColor = "黑";
                label.fontSize = 22;
                ret.label = label;
            }
            if( ret == null)
            {
                Debug.LogError("列表单元必须得是 支持label的YButton");
            }
            return ret;
        }
    }
}
