using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLua;

namespace UYMO
{
    /// <summary>
    /// 窗口层级枚举：注意这些枚举不要轻易改变名称（因为它们对应GameCavas.prefab里的各个层级根节点名称）
    /// </summary>
    /// 
    [CustomLuaClassAttribute]
    public enum WindowLayer
    {
        /// <summary>
        /// 场景的最底层，不能再往下了
        /// </summary>
        UnderScene = -1,
        /// <summary>
        /// 窗口层级：最底层，最靠近场景的一层
        /// </summary>
        Scene = 0,
        /// <summary>
        /// 窗口层级：很底层
        /// </summary>
        BottomMost = 1,
        /// <summary>
        /// 窗口层级：底层
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// 窗口层级：偏底层
        /// </summary>
        Lower = 3,
        /// <summary>
        /// 窗口层级：普通层级，大多数窗口应该在这个层级
        /// </summary>
        Normal = 4,
        /// <summary>
        /// 窗口层级：偏顶层
        /// </summary>
        Upper = 5,
        /// <summary>
        /// 窗口层级：顶层
        /// </summary>
        Top = 6,
        /// <summary>
        /// 窗口层级：很顶层
        /// </summary>
        TopMost = 7,
        /// <summary>
        /// 窗口层级：最顶层，最接近屏幕层
        /// </summary>
        Screen = 8,
        /// <summary>
        /// 窗口层级：调试层
        /// </summary>
        Debug = 9,
    }

    /// <summary>
    /// 窗口皮肤
    /// </summary>
    public enum WindowSkin
    {
        /// <summary>
        /// 无皮肤
        /// </summary>
        None,

        /// <summary>
        /// 皮肤01
        /// </summary>
        Skin01
    }

    /// <summary>
    /// 窗口持有器
    /// </summary>
    public interface IWinCanvas
    {
    }

    /// <summary>
    /// 对窗口的基本封装
    /// </summary>
    [CustomLuaClassAttribute]
    [ExecuteInEditMode]
    public class Window : MonoBehaviour
    {
        /// <summary>
        /// 窗口的开始层级
        /// </summary>
        public const int LayerStart = (int)WindowLayer.UnderScene;
        /// <summary>
        /// 窗口的结束层级
        /// </summary>
        public const int LayerEnd = (int)WindowLayer.Debug;
        /// <summary>
        /// 窗口层级数量
        /// </summary>
        public const int LayerCount = LayerEnd - LayerStart + 1;

        private static string c_CloseButtonName = "sys_CloseButton";
        private static string c_ReturnButtonName = "sys_ReturnButton";
        private static string CloseFromShadow = "ShadowButton";
        /// <summary>
        /// 是否为全屏窗口
        /// </summary>
        public bool m_IsFullScreen = true;
        public WindowLayer m_Layer = WindowLayer.Normal;

        /// <summary>
        /// 窗口所属的canvas
        /// </summary>
        public IWinCanvas winCanvas { get; set; }

        /// <summary>
        /// ui系统点击事件回调
        /// </summary>
        /// <param name="lua"></param>
        /// <param name="uiObj"></param>
        /// <param name="hitMe"></param>
        public delegate void ClickCheckHandle(LuaTable lua, GameObject uiObj, bool hitMe);
        ClickCheckHandle _CheckClickHandler; //回调函数
        LuaTable _CheckClickLua;
        UYTimerBase _CheckClickHandlerTimer; //延迟注册

        public void Init()
        {
        }
        void Start()
        {
#if UNITY_STANDALONE_WIN
            UpdateSkin();
#endif
        }
        void OnDestroy()
        {
            _CheckClickLua = null;
            _CheckClickHandler = null;
            _CheckClickHandlerTimer = null;
        }

        /// <summary>
        /// 窗口对于的根节点（即gameObject）
        /// </summary>
        public GameObject Root
        {
            get { return gameObject; }
        }

        /// <summary>
        /// 当前窗口的根UI，可能为null
        /// </summary>
        public Image RootUI
        {
            get { return GetComponent<Image>(); }
        }
        /// <summary>
        /// 当前窗口的根Button，可能为null
        /// </summary>
        public Button RootButton
        {
            get { return GetComponent<Button>(); }
        }

        /// <summary>
        /// 窗口层级
        /// </summary>
        public WindowLayer Layer
        {
            get { return m_Layer; }
            set
            {
                m_Layer = value;
            }
        }

        /// <summary>
        /// 是否显示关闭按钮
        /// </summary>
        public bool CloseButtonVisible
        {
            get
            {
                GameObject obj = TryGetChild(c_CloseButtonName);
                return obj && obj.activeSelf;
            }
            set
            {
                GameObject obj = TryGetChild(c_CloseButtonName);
                if (obj)
                {
                    obj.SetActive(value);
                }
            }
        }
        /// <summary>
        /// 窗口中是否存在关闭按钮（如果有，即使 不可见也返回true）
        /// </summary>
        public bool CloseButtonExist
        {
            get { return TryGetChild(c_CloseButtonName) != null; }
        }
        /// <summary>
        /// 设置鼠标点中与否的处理函数，传null表示取消处理
        /// </summary>
        /// <param name="lua">回调者</param>
        /// <param name="handler">回调函数</param>
        public void SetClickCheckHandler(LuaTable lua, ClickCheckHandle handler)
        {
            if (handler == null)
            {//传递null表示清理回调
                if (_CheckClickHandler != null)
                {//之前有回调
                    _CheckClickLua = null;
                    _CheckClickHandler = null;
                    _CheckClickHandlerTimer = PlayInterface.DestroyTimer(_CheckClickHandlerTimer);
                    PlayInterface.RemoveClickCheckWindow(this);
                }
            }
            else
            {//设置有效回调
                bool needReg = _CheckClickHandler == null;
                _CheckClickLua = lua;
                _CheckClickHandler = handler;
                if (needReg && _CheckClickHandlerTimer == null)
                {//延迟一段时间再注册，具体原因忘了
                    _CheckClickHandlerTimer = PlayInterface.CreateFramer(() =>
                    {
                        _CheckClickHandlerTimer = null;
                        PlayInterface.RegisterClickCheckWindow(this);
                    }, 1);
                }
            }
        }
        /// <summary>
        /// 通知鼠标击中事件
        /// </summary>
        /// <param name="uiObj">被击中的对象，可能为null</param>
        /// <param name="hitMe">是否击中当前窗口</param>
        [DoNotToLuaAttribute]
        public void NotifyClickCheck(GameObject uiObj, bool hitMe)
        {
            if (_CheckClickHandler != null)
            {
                _CheckClickHandler(_CheckClickLua, uiObj, hitMe);
            }
        }
        /// <summary>
        /// 窗口根对象名称
        /// </summary>
        public string Name
        {
            get { return gameObject.name; }
        }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Visible
        {
            get { return gameObject.activeSelf; }
            set { PlayInterface.ShowWindow(this, value); }
        }

        /// <summary>
        /// 尝试获取关闭按钮，如果没有关闭按钮，返回null
        /// </summary>
        /// <returns>关闭按钮</returns>
        public YButton TryGetCloseButton()
        {
            return TryGetUI<YButton>(c_CloseButtonName);
        }
        /// <summary>
        /// 尝试获取返回按钮，如果没有则返回null
        /// </summary>
        /// <returns>返回按钮</returns>
        public YButton TryGetReturnButton()
        {
            return TryGetUI<YButton>(c_ReturnButtonName);
        }
        /// <summary>
        /// 尝试获取阴影按钮，如果没有则返回null
        /// </summary>
        /// <returns>返回按钮</returns>
        public YButton TryGetShadowButton()
        {
            return TryGetUI<YButton>(CloseFromShadow);
        }

        public YScrollList GetScrollListLoop(string childName)
        {
            var obj = GetChild(childName);
            if (obj != null)
            {
                return obj.GetComponent<YScrollList>();
            }
            return null;
        }
        /// <summary>
        /// 获取循环列表组件
        /// </summary>
        /// <param name="childName"></param>
        /// <returns></returns>
        public YScrollView GetYScrollView(string childName)
        {
            var obj = GetChild(childName);
            if (obj != null)
            {
                return obj.GetComponent<YScrollView>();
            }
            return null;
        }
        /// <summary>
        /// 添加子对象
        /// </summary>
        /// <param name="obj">子对象</param>
        public void AddChild(GameObject obj)
        {
            obj.transform.parent = gameObject.transform;
        }
        /// <summary>
        /// 尝试获取给定名称的对象
        /// </summary>
        /// <param name="name">子对象名称</param>
        /// <returns>子对象，没有就返回null</returns>
        public GameObject TryGetChild(string name)
        {
            return U3DUtil.GetChildByName(gameObject, name, true);
        }
        /// <summary>
        /// 获取子对象
        /// </summary>
        /// <param name="name">子对象名</param>
        /// <returns>子对象，保证不返回null（如果不存在，抛出异常）</returns>
        public GameObject GetChild(string name)
        {
            GameObject obj = TryGetChild(name);
            if (obj == null)
            {
                throw new GuiException(Name, string.Format("Child with name \"{0}\" not exist", name));
            }
            return obj;
        }
        /// <summary>
        /// 设置子项的文本，子项有Text组件，或者子项的子拥有Text组件才有效
        /// </summary>
        /// <param name="name">子对象名</param>
        /// <param name="text">文本字符串</param>
        public void SetChildText(string name, string text)
        {
            GameObject child = TryGetChild(name);
            Text txt = child.GetComponent<Text>();
            if (txt == null)
            {//没有Text组件，查找子
                txt = child.GetComponentInChildren<Text>();
            }
            if (txt != null)
            {
                txt.text = text;
            }
        }
        /// <summary>
        /// 尝试获取给定名称的控件
        /// </summary>
        /// <typeparam name="T">控件类型</typeparam>
        /// <param name="name">控件名称</param>
        /// <returns>子控件，没有就返回null</returns>
        public T TryGetUI<T>(string name) where T : Component
        {
            GameObject obj = TryGetChild(name);
            if (obj)
            {
                return obj.GetComponent<T>();
            }
            return null;
        }
        /// <summary>
        /// 获取子控件（注意不是GameObject，而是Component）
        /// </summary>
        /// <typeparam name="T">控件类型，比如Button等</typeparam>
        /// <param name="name">控件对应的对象的名称</param>
        /// <returns>控件组件，保证不返回null（如果获取失败，抛出异常）</returns>
        public T GetUI<T>(string name) where T : Component
        {
            T ui = TryGetUI<T>(name);
            if (ui == null)
            {
                throw new GuiException(Name, string.Format("UI with name \"{0}\" is not {1}", name, typeof(T).ToString()));
            }
            return ui;
        }
        /// <summary>
        /// 获取给定名称的子面板
        /// </summary>
        /// <param name="name">面板名称</param>
        /// <returns>面板（其实是Image类），保证不返回null（如果获取失败，抛出异常）</returns>
        public Image GetPanel(string name)
        {
            return GetUI<Image>(name);
        }
        /// <summary>
        /// 获取给定名称的子按钮
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns>按钮，保证不返回null（如果获取失败，抛出异常）</returns>
        public Button GetButton(string name)
        {
            return GetUI<Button>(name);
        }
        /// <summary>
        /// 获取给定名称的子图片控件
        /// </summary>
        /// <param name="name">图片控件名称</param>
        /// <returns>图片控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public Image GetImage(string name)
        {
            return GetUI<Image>(name);
        }
        /// <summary>
        /// 获取给定名称的子文本
        /// </summary>
        /// <param name="name">文本名称</param>
        /// <returns>文本，保证不返回null（如果获取失败，抛出异常）</returns>
        public Text GetText(string name)
        {
            return GetUI<Text>(name);
        }
        /// <summary>
        /// 获取给定名称的子图片控件
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <returns>控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public RawImage GetRawImage(string name)
        {
            return GetUI<RawImage>(name);
        }
        /// <summary>
        /// 获取给定名称的子滑动条
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <returns>控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public Slider GetSlider(string name)
        {
            return GetUI<Slider>(name);
        }
        /// <summary>
        /// 获取给定名称的子滚动条
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <returns>控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public Scrollbar GetScrollbar(string name)
        {
            return GetUI<Scrollbar>(name);
        }
        /// <summary>
        /// 获取给定名称的子选择按钮
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <returns>控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public Toggle GetToggle(string name)
        {
            return GetUI<Toggle>(name);
        }
        /// <summary>
        /// 获取给定名称的子输入框
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <returns>控件，保证不返回null（如果获取失败，抛出异常）</returns>
        public InputField GetInputField(string name)
        {
            return GetUI<InputField>(name);
        }

        /// <summary>
        /// 加载一个组件
        /// </summary>
        /// <param name="prefabName">待加载的组件名称（相对layout的路径）</param>
        /// <param name="parent">新对象加入的父节点，传null表示直接加入到当前窗口的根节点上</param>
        /// <returns>新的组件节点，保证不为null</returns>
        public GameObject LoadWidget(string prefabName, GameObject parent = null)
        {
            parent = parent == null ? Root : parent;
            GameObject obj = UIUtil.CreateUIGameObject(prefabName);
            obj.transform.SetParent(parent.transform, false);
            return obj;
        }

        /// <summary>
        /// 皮肤
        /// </summary>
        public WindowSkin skin;

        //当前皮肤对象
        private GameObject _CurrentSkin;

        /// <summary>
        /// 更新皮肤
        /// </summary>
        public void UpdateSkin()
        {
        }

        public string _Title;

        /// <summary>
        /// 窗口皮肤上的标题
        /// </summary>
        public string title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title == value)
                {
                    return;
                }

                _Title = value;

                var label = UIUtil.GetYLabel(gameObject, "TitleLabel");
                if (label != null)
                {
                    label.text = value;
                }
            }
        }

        public RectTransform GetRectTransform(string name)
        {
            return GetUI<RectTransform>(name);
        }

        /// <summary>
        /// 获取YLabel，保证不为空
        /// </summary>
        public YLabel GetYLabel(string name)
        {
            return GetUI<YLabel>(name);
        }

        /// <summary>
        /// 获取YImage，保证不为空
        /// </summary>
        public YImage GetYImage(string name)
        {
            return GetUI<YImage>(name);
        }

        /// <summary>
        /// 获取YButton，保证不为空
        /// </summary>
        public YButton GetYButton(string name)
        {
            return GetUI<YButton>(name);
        }

        /// <summary>
        /// 获取YToggle
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public YToggle GetYToggle(string name)
        {
            return GetUI<YToggle>(name);
        }

        /// <summary>
        /// 获取YToggleGroup
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public YToggleGroup GetYToggleGroup(string name)
        {
            return GetUI<YToggleGroup>(name);
        }
        /// <summary>
        /// 获取YInputField,保证不为空
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public YInputField GetYInputField(string name)
        {
            return GetUI<YInputField>(name);
        }
        /// <summary>
        /// 获取YDropList
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public YDropList GetYDropList(string name)
        {
            return TryGetUI<YDropList>(name);
        }
        /// <summary>
        /// 获取YFrameTV
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public YFrameTV GetYFrameTV(string name)
        {
            return TryGetUI<YFrameTV>(name);
        }
        /// <summary>
        /// 获取小部件
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>小部件lua对象</returns>
        public SLua.LuaTable GetWidget(string name)
        {
            CustomWidget wMono = GetUI<CustomWidget>(name);
            return wMono.widget;
        }

        /// <summary>
        /// 窗口打开声音
        /// </summary>
        [SerializeField]
        private ResID _OpenSound = ResID.zero;

        public ResID openSound
        {
            get { return _OpenSound; }
            set { _OpenSound = value; }
        }

        /// <summary>
        /// 窗口关闭声音
        /// </summary>
        [SerializeField]
        private ResID _CloseSound = ResID.zero;

        public ResID closeSound
        {
            get { return _CloseSound; }
            set { _CloseSound = value; }
        }


        /// <summary>
        /// 清空所有子控件的数据
        /// </summary>
        public void ClearChildren()
        {
            UIUtil.ClearAllData(gameObject);
        }

        /// <summary>
        /// 绑定组件变量
        /// </summary>
        /// <param name="bindinfos">绑定信息</param>
        /// <returns></returns>
        public object[] BindGuis(string[] bindinfos)
        {
            return UIUtil.BindGuis(Root, bindinfos);
        }

        /// <summary>
        /// 判断当前窗口内部所有图片是否都加载完毕
        /// </summary>
        public bool CheckAllImageLoaded()
        {
            bool ret = true;
            var spriteUsers = UIUtil.GetSpriteUserListInChildren(gameObject, false);
            for (int i = 0; i < spriteUsers.Count; ++i)
            {
                if (!spriteUsers[i].imageReady)
                {
                    ret = false;
                    break;
                }
            }
            ObjectPool.spriteUserListPool.Gabage(spriteUsers);
            return ret;
        }

    }
}
