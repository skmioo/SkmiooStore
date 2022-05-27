using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UYMO.GameConsole
{
    public class ConsoleMainDlg:ConsoleDlgBase
    {
        struct SubDlg
        {
            public string name;
            public Type dlgType;
        }
        static List<SubDlg> sSubDlg = new List<SubDlg>();
        public static void AddSubDlg<T>(string name)where T:ConsoleDlgBase
        {
            SubDlg sub;
            sub.name = name;
            sub.dlgType = typeof(T);
            sSubDlg.Add(sub);
        }

        static ConsoleMainDlg()
        {
            AddSubDlg<LogDlg>("日志");
        }
        List<Toggle> _Toggles = new List<Toggle>(20);
        int _CurSelected = -1;
        GameObject _Panel;
        ConsoleDlgBase _CurDlg;
        public ConsoleMainDlg():base("ConsoleMainDlg")
        {
            
        }

        protected override void OnInit()
        {
            _Panel = GetChild("Panel");
            Button closeBtn = GetButton("Close");
            closeBtn.onClick.AddListener(_HandleClose);
            Button hideBtn = GetButton("Hide");
            hideBtn.onClick.AddListener(_HandleHide);
            for (var idx = 0; idx < sSubDlg.Count; ++idx)
            {
                Toggle t;
                if(idx == 0)
                {
                    t = GetToggle("Toggle0");
                }
                else
                {
                    Toggle pre = _Toggles[0];
                    GameObject to = UIUtil.Instantiate(pre.gameObject, pre.transform.parent) as GameObject;
                    t = to.GetComponent<Toggle>();
                }
                t.onValueChanged.AddListener(_HandleSwitch);
                Text label = GetCtrl<Text>(t.gameObject, "Label");
                label.text = sSubDlg[idx].name;

                _Toggles.Add(t);
            }

            if(_Toggles.Count > 0 )
            {
                _Toggles[0].isOn = true;
            }
        }

        private void _HandleClose()
        {
            Close();
        }
        private void _HandleHide()
        {
            visible = false;
        }

        private void _HandleSwitch(bool isOn)
        {
            if (isOn)
            {
                int selectedIdx = FindIsOnToggle();
                if (_CurSelected != selectedIdx)
                {
                    _CurSelected = selectedIdx;
                    if (selectedIdx == -1)
                    {
                        Debug.LogError("没有分布选中了");
                    }
                    else
                    {
                        var sub = sSubDlg[selectedIdx];
                        if (_CurDlg)
                        {
                            _CurDlg.Close();
                        }
                        _CurDlg = ConsoleMgr.FetchDlg(sub.dlgType);
                        RectTransform trans = _CurDlg.GetRoot().GetComponent<RectTransform>();
                        trans.SetParent(_Panel.transform);
                        trans.offsetMin = Vector2.zero;
                        trans.offsetMax = Vector2.zero;
                        trans.localScale = Vector2.one;
                    }
                }
            }
        }

        private int FindIsOnToggle()
        {
            for(int idx = 0; idx < _Toggles.Count; ++idx )
            {
                if(_Toggles[idx].isOn )
                {
                    return idx;
                }
            }
            return -1;
        }

        protected override void OnClose()
        {
            if(_CurDlg != null)
            {
                _CurDlg.Close();
            }
        }
    }
}
