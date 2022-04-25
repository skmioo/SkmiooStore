using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class BasePanel : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected Button btn;

    private bool noDestroy;
    public bool NoDestroy
    {
        get { return noDestroy; }
        set { noDestroy = value; }
    }


    public void Awake()
    {
        btn = FindCloseButton("CloseButton");
        canvasGroup = GetComponent<CanvasGroup>();

        if (btn != null)
        {
            btn.onClick.AddListener(()=> {
                AudioManager.Instance.PlayAudio(AudioName.BUTTON_Clean_Tap_mono, AudioType.Common);
                UIManager.Instance.PopPanel();
            });
        }

    }

    /// <summary>
    /// 在进入状态(OnEnter)中，Panel是出现且可点击的
    /// </summary>
    public void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        _OnEnter();

        UIManager.Instance.onLanguageChangedAction += OnLanguageChanged;

        OnLanguageChanged();
    }

    protected virtual void _OnEnter()
    {

    }
    /// <summary>
    /// 在暂停状态(OnPause)中，Panel是出现且不可点击的/改为不出现了
    /// </summary>
    public void OnPause()
    {
        _OnExit();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    /// <summary>
    /// 在继续状态(OnResume)，Panel是出现且可点击的
    /// </summary>
    public void OnResume()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        _OnResume();
    }

    protected virtual void _OnResume()
    {

    }

    /// <summary>
    /// 在退出状态(OnExit)，Panel是消失且不可点击的
    /// </summary>
    public void OnExit()
    {
        _OnExit();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;

        UIManager.Instance.onLanguageChangedAction -= OnLanguageChanged;
    }

    protected virtual void _OnExit()
    {

    }

    //给出子物体名字，并尝试在子物体中搜索到以该名字命名的子物体的button组件
    //搜索到了返回button组件，未搜索到则返回null   ,必须取名为CloseButton，Awake中定义了名称
    private Button FindCloseButton(string childName)
    {
        Button closeButton = null;
        foreach (var item in GetComponentsInChildren<Button>())
        {
            if (item.name == childName)
                closeButton = item.GetComponent<Button>();
        }
        return closeButton;
    }

    // 刷新多语言
    protected virtual void OnLanguageChanged()
    {
    }

}
