using Datas;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


/// <summary>
/// UI管理器,改自UIFormWork框架
/// 测试阶段,若在start或awker中调用需要延时
/// </summary>
public class UIManager
{
    // 单例
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }


    //保存所有已实例化面板的游戏物体身上的BasePanel组件
    private Dictionary<UIPanelType, BasePanel> panelDict = new Dictionary<UIPanelType, BasePanel>();
    private Dictionary<UIPanelType, PanelData> panelDataDict = new Dictionary<UIPanelType, PanelData>();

    //存储当前场景中的界面
    private Stack<BasePanel> panelStack = new Stack<BasePanel>();
    private Stack<BuildPanelBase> panelBuildStack = new Stack<BuildPanelBase>();

    //默认所以UI面板放在Canvas下
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
              GameObject gtmp =  GameObject.Find("Canvas");
                if(gtmp == null) gtmp = GameObject.Find("BattleCanvas");
                canvasTransform = gtmp.transform;
            }
            return canvasTransform;
        }
    }

    private Transform noDestroyCanvas;
    private Transform NoDestroyCanvas
    {
        get
        {
            if (noDestroyCanvas == null)
            {
                GameObject gtmp = GameObject.Find("Canvas2");
                noDestroyCanvas = gtmp.transform;
            }
            return noDestroyCanvas;
        }
    }

    private UIManager()
    {
        GetPanelData();
    }

    /// <summary>
    /// 获取UI面板基础数据,若未加载场景测试,报空引用错误,请延时3秒调用
    /// </summary>
    void GetPanelData()
    {
        //面板加载已被独立
        //DataSetItem data =  DataManager.Instance.GetData("UIPanelData");
        //UIPanelDataSet uiData = data.scriptableObject as UIPanelDataSet;

        //foreach (var item in DataManager.uIPanelDataSet.panelDatas)
        //{
        //    panelDataDict.Add(item.panelType, item);
        //}

        SchudleManger.instance.Schudle(() =>
        {
            foreach (var item in DataManager.uIPanelDataSet.panelDatas)
            {
                panelDataDict.Add(item.panelType, item);
            }
        }, 1f);
    }
 
   // public static Func<UIPanelType,BasePanel> _Getpanel;



    public Action<BasePanel> GetPanelComleted;
    public Action onLanguageChangedAction;

    /// <summary>
    /// 提供一个异步加载并获得Panel的方法.方法后面跟.GetPanelComleted，注册回调
    /// </summary>
    /// <param name="panelType"></param>
    /// <returns></returns>
    public UIManager GetpanelAndPushAsync(UIPanelType panelType, bool noDestroy = false)
    {
        BasePanel basePanel = panelDict.TryGetValue(panelType);

        if (basePanel == null)
        {
            if (panelStack.Count > 0)
            {
                panelStack.Peek().OnPause();//原栈顶界面暂停
            }

            PanelData panelData = panelDataDict.TryGetValue(panelType);
            Debug.Log(panelData.name);

            panelData.PanelMode.InstantiateAsync(noDestroy ? NoDestroyCanvas : CanvasTransform).Completed += go =>
            {
                BasePanel panel = go.Result.GetComponent<BasePanel>();

                panel.OnEnter();//调用进入动作
                panelStack.Push(panel);//页面入栈

                GetPanelComleted?.Invoke(panel);
                panelDict.Add(panelType, panel);       
            };
        }
        else
        {
            PushPanel(panelType);
            GetPanelComleted?.Invoke(basePanel);
        }

        return this;
    }


    /// <summary>
    /// 根据面板类型，返回对应的BasePanel组件,未入栈的面板返回空！！！
    /// </summary>
    /// <param name="panelType">需要返回的面板类型</param>
    /// <returns>返回该面板组件</returns>
    public BasePanel GetPanel(UIPanelType panelType)
    {
        BasePanel basePanel = panelDict.TryGetValue(panelType);
       

        if (basePanel == null)
        {
            //PanelData panelData = panelDataDict.TryGetValue(panelType);
            //panelData.PanelMode.InstantiateAsync(canvasTransform).Completed += go => {
            //    BasePanel panel = go.Result.GetComponent<BasePanel>();
            //    panelDict.Add(panelType, panel);              
            //};


            Debug.Log("只能找已经入过栈的面板");
            return null;
        }
        else
        {
            return basePanel;
        }
    }

    /// <summary>
    /// 设置默认的栈顶元素
    /// </summary>
    /// <param name="panelType">界面类型</param>
    /// <param name="basePanel">组件</param>
    public void SetDefaultPopPanel(UIPanelType panelType, BasePanel basePanel)
    {
        panelDict.Add(panelType, basePanel);
        panelStack.Push(basePanel);
    }

    /// <summary>
    /// 把该页面显示在场景中
    /// </summary>
    /// <param name="panelType">需要显示界面的类型</param>
    public void PushPanel(UIPanelType panelType,bool noDestroy = false)
    {       
        if (panelStack.Count > 0)
        {
            panelStack.Peek().OnPause();//原栈顶界面暂停
        }

        BasePanel panel = panelDict.TryGetValue(panelType);
        if (panel == null)
        {
            PanelData panelData = panelDataDict.TryGetValue(panelType);
            panelData.PanelMode.InstantiateAsync(noDestroy ? NoDestroyCanvas : CanvasTransform).Completed += go => {
                BasePanel _panel = go.Result.GetComponent<BasePanel>();
                _panel.NoDestroy = noDestroy;
                _panel.OnEnter();//调用进入动作
                panelStack.Push(_panel);//页面入栈
                panelDict.Add(panelType, _panel);
            }; 
        }
        else
        {
            panel.OnEnter();//调用进入动作
            panelStack.Push(panel);//页面入栈
        }             
    }

    /// <summary>
    /// 关闭栈顶界面显示
    /// </summary>
    public void PopPanel()
    {
        //当前栈内为空，则直接返回..
        if (panelStack.Count == 0)
        {
            //PushPanel(UIPanelType.MainMenuBoxPanel);
            return;
        }
       
        panelStack.Pop().OnExit();//Pop删除栈顶元素，并关闭栈顶界面的显示，
        if (panelStack.Count <= 0) return;
        panelStack.Peek().OnResume();//获取现在栈顶界面，并调用界面恢复动作
    }

    /// <summary>
    /// 关闭所有界面
    /// </summary>
    public void PopAllPanel()
    {

        if (panelStack.Count <= 0) return;
        for (int i = 0; i < panelStack.Count; i++)
        {
            panelStack.Pop().OnExit();
        }
    
        //panelStack.Peek().OnResume();
    }

    /// <summary>
    /// 当回到标题界面，初始化这个脚本中的部分内容
    /// </summary>
    public void Ondestory()
    {
        panelStack.Clear();
        panelDict.Clear();
    }

    /// <summary>
    /// 清空堆栈
    /// </summary>
    public void ClearStack()
    {
        //canvasTransform = null;
        panelStack.Clear();
        panelDict.Clear();
    }

    /// <summary>
    /// 获取当前窗口数量
    /// </summary>
    public int GetStackCount()
    {
        return panelStack.Count;
    }

    /// <summary>
    /// 获取当前建筑窗口数量
    /// </summary>
    public int GetBuildStackCount()
    {
        return panelBuildStack.Count;
    }

    /// <summary>
    /// 显示建筑界面
    /// </summary>
    public void PushBuildPanel(BuildPanelBase panelBuildBase)
    {       
        panelBuildStack.Push(panelBuildBase);//页面入栈
    }

    /// <summary>
    /// 关闭栈顶建筑界面
    /// </summary>
    public void PopBuildPanel()
    {
        //当前栈内为空，则直接返回..
        if (panelBuildStack.Count == 0)
        {
            return;
        }

        panelBuildStack.Pop().SetPanel(false);//Pop删除栈顶元素，并关闭栈顶界面的显示，
    }

    /// <summary>
    /// 刷新语言
    /// </summary>
    public void OnLanguageChanged()
    {
        onLanguageChangedAction?.Invoke();
    }

}

