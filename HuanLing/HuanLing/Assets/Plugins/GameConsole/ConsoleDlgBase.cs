using UnityEngine;
using UnityEngine.UI;
using UYMO;
/// <summary>
/// 控制台窗口基类
/// </summary>
namespace UYMO.GameConsole
{
    public abstract class ConsoleDlgBase:MonoBehaviour
    {
        protected string _Path;
        GameObject _Root;
        public ConsoleDlgBase(string prefabPath)
        {
            _Path = prefabPath;
        }

        public void Init(Transform parent)
        {
            Object layout = LoadLayout();
            _Root = Instantiate(layout, parent) as GameObject;
            OnInit();
        }

        public GameObject GetRoot()
        {
            return _Root;
        }

        void Update()
        {
            OnUpdate();
        }

        public void Close()
        {
            OnClose();
            Destroy(_Root);
            Destroy(this);
            _Root = null;
        }

        public bool visible
        {
            get
            {
                return _Root.activeSelf;
            }
            set
            {
                _Root.SetActive(value);
            }
        }

        protected GameObject GetChild(string childName)
        {
            return U3DUtil.GetChildByName(_Root, childName, true);
        }

        protected TCtrl GetCtrl<TCtrl>(GameObject root, string childName) where TCtrl : MonoBehaviour
        {
            TCtrl ret = null;
            if (childName == "")
            {
                ret = root.GetComponent<TCtrl>();
            }
            else
            {
                var childObj = U3DUtil.GetChildByName(root, childName, true);
                if (childObj != null)
                {
                    ret = childObj.GetComponent<TCtrl>();
                }
            }
            if (ret == null)
            {
                throw new System.InvalidOperationException(string.Format("未找到控件{0} 类型：{1}", childName, typeof(TCtrl).FullName));
            }
            return ret;
        }
        protected TCtrl GetCtrl<TCtrl>(string childName ) where TCtrl: MonoBehaviour
        {
            return GetCtrl<TCtrl>(_Root, childName);
        }

        protected Text GetText(string childName)
        {
            return GetCtrl<Text>(childName);
        }

        protected Image GetImage(string childName)
        {
            return GetCtrl<Image>(childName);
        }

        protected Button GetButton(string childName)
        {
            return GetCtrl<Button>(childName);
        }

        protected Toggle GetToggle(string childName)
        {
            return GetCtrl<Toggle>(childName);
        }
        protected ToggleGroup GetToggleGroup(string childName)
        {
            return GetCtrl<ToggleGroup>(childName);
        }

        protected virtual void OnInit() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnClose() { }

        protected virtual Object LoadLayout()
        {
            return Resources.Load<GameObject>("Console/" + _Path);
        }
    }
}
