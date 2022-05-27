using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UYMO;

namespace DRLoader
{
    public class LoadUI
    {
        public static LoadUI instance;

        public GameObject logicGO;

        private GameObject _Root;
        private Text _PrgLabel;
        private Text _InfoLabel;
        private Text _ClientInfoLabel;
        private Text _SrvLabel;
        private Text _ErrorLabel;
        private float _Progress = -1.0f;
        public LoadUI()
        {
            instance = this;

            _Root = GameObject.Instantiate(Resources.Load<GameObject>("LoaderUI"));
            _PrgLabel = U3DUtil.GetChildByName(_Root, "PrgText", true).GetComponent<Text>();
            _InfoLabel = U3DUtil.GetChildByName(_Root, "LoadingInfo", true).GetComponent<Text>();
            _SrvLabel = U3DUtil.GetChildByName(_Root, "ResServerInfo", true).GetComponent<Text>();
            _ClientInfoLabel = U3DUtil.GetChildByName(_Root, "ClientInfo", true).GetComponent<Text>();
            _ErrorLabel = U3DUtil.GetChildByName(_Root, "ErrorInfo", true).GetComponent<Text>();

            progress = 0.0f;
            loadInfo = "检查更新...";
            if (!UYMO.BaseVersion.IsInner)
            {//外网
                //errorVisible = false;
                //clientInfoVisible = Application.platform != RuntimePlatform.IPhonePlayer;
            }
        }
        public void StartCoroutine(IEnumerator callback)
        {
            _PrgLabel.StartCoroutine(callback);
        }

        public float progress
        {
            get { return _Progress; }
            set
            {
                value = Mathf.Clamp(value, 0.0f, 1.0f);
                if (_Progress != value)
                {
                    _Progress = value;
                    int p = (int)(_Progress * 100.0f);
                    _PrgLabel.text = string.Format("{0}%", p);
                }
            }
        }

        /// <summary>
        /// 加载文本
        /// </summary>
        public string loadInfo
        {
            get { return _InfoLabel.text; }
            set
            {
                _InfoLabel.text = value == null ? "" : value;
            }
        }

        public string resServer
        {
            get { return _SrvLabel.text; }
            set
            {
                _SrvLabel.text = value == null ? "" : value;
            }
        }

        public string clientInfo
        {
            get { return _ClientInfoLabel.text; }
            set
            {
                _ClientInfoLabel.text = value == null ? "" : value;
            }
        }

        public bool clientInfoVisible
        {
            get { return _ClientInfoLabel.gameObject.activeSelf; }
            set
            {
                _ClientInfoLabel.gameObject.SetActive(value);
            }
        }

        /// <summary>
        /// 报错信息
        /// </summary>
        public string errorStr
        {
            get { return _ErrorLabel.text; }
            set
            {
                _ErrorLabel.text = value == null ? "" : value;
            }
        }

        /// <summary>
        /// 是否显示错误信息
        /// </summary>
        public bool errorVisible
        {
            get { return _ErrorLabel.gameObject.activeSelf; }
            set
            {
                _ErrorLabel.gameObject.SetActive(value);
            }
        }

        public void ShowMsgBox(string msg, string btns, Action<int> click)
        {
            MessageBox.ShowMessageBox(msg, btns, click, _Root.transform);
        }

        public void CloseMsgBox()
        {
            MessageBox.CloseAll();
        }

        public void Destroy()
        {
            instance = null;
            CloseMsgBox();
            GameObject.Destroy(_Root);
        }
    }

    class MessageBox
    {
        static List<MessageBox> sBoxs = new List<MessageBox>();
        public static void ShowMessageBox(string msg, string btns, Action<int> click, Transform parent)
        {
            var box = new MessageBox(parent);
            box.Show(msg, btns, click);
            sBoxs.Add(box);
        }
        public static void CloseAll()
        {
            for (int idx = 0; idx < sBoxs.Count; ++idx)
            {
                var box = sBoxs[idx];
                GameObject.Destroy(box.msgDlg);
                box.msgDlg = null;
            }
            sBoxs.Clear();
        }

        public static void CloseMsgBox(MessageBox box)
        {
            sBoxs.Remove(box);
            GameObject.Destroy(box.msgDlg);
            box.msgDlg = null;
        }

        GameObject msgDlg;
        Text msgLabel;
        GameObject ok;
        GameObject yes;
        GameObject no;
        Action<int> _Click;
        public MessageBox(Transform canvas)
        {
            GameObject res = Resources.Load<GameObject>("MessageDlg");
            msgDlg = GameObject.Instantiate(res);
            msgDlg.transform.SetParent(canvas, false);

            msgLabel = msgDlg.transform.Find("msg").GetComponent<Text>();
            ok = msgDlg.transform.Find("ok").gameObject;
            yes = msgDlg.transform.Find("yes").gameObject;
            no = msgDlg.transform.Find("no").gameObject;
            if (ok == null)
            {
                Debug.Log("ok");
            }
            if (yes == null)
            {
                Debug.Log("ok");
            }
            if (no == null)
            {
                Debug.Log("ok");
            }
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="btns">按钮设定，最多支持2个按钮 如："确定", "是|否"</param>
        /// <param name="click">点击回调,参数为从左往右，0开始的按钮索引</param>
        public void Show(string msg, string btns, Action<int> click)
        {
            string[] buttons = btns.Split('|');
            switch (buttons.Length)
            {
                case 1:
                    ok.SetActive(true);
                    yes.SetActive(false);
                    no.SetActive(false);
                    var text = ok.transform.Find("Text").GetComponent<Text>();
                    text.text = buttons[0];
                    var btn = ok.GetComponent<Button>();
                    btn.onClick.AddListener(okClick);
                    break;
                case 2:
                    ok.SetActive(false);
                    yes.SetActive(true);
                    no.SetActive(true);
                    var btnText = yes.transform.Find("Text").GetComponent<Text>();
                    btnText.text = buttons[0];
                    btnText = no.transform.Find("Text").GetComponent<Text>();
                    btnText.text = buttons[1];
                    var button = yes.GetComponent<Button>();
                    button.onClick.AddListener(yesClick);
                    button = no.GetComponent<Button>();
                    button.onClick.AddListener(noClick);
                    break;
                default:
                    Debug.Log("just support 1~2 buttons!");
                    return;
            }
            _Click = click;
            msgLabel.text = msg;
            msgDlg.SetActive(true);
        }
        void okClick()
        {
            CloseMsgBox(this);
            _Click(0);
        }
        void yesClick()
        {
            CloseMsgBox(this);
            _Click(0);
        }
        void noClick()
        {
            CloseMsgBox(this);
            _Click(1);
        }

        public bool closed
        {
            get
            {
                return msgDlg == null;
            }
        }
    }
}
