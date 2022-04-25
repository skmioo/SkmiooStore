using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 交互物-触发器
/// </summary>
public class InteractiveTriggerBox : AddRoomBase
{
    public Button interactiveBtn;
    protected InteractiveMode modeBase;
    protected BoxCollider2D Collider;
    private const float BoxSizeX = 3.5f;
    private const float BoxSizeY = 3.5f;
    public Vector2 BoxSize { get { return new Vector2(BoxSizeX, BoxSizeY); } }

    bool isBattling;
    /// <summary>
    /// 可交互次数的最大值
    /// </summary>
    public int interactiveCountMax;
    public  virtual void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        if (Collider == null) Collider = gameObject.AddComponent<BoxCollider2D>();
        Collider.size = new Vector2(BoxSizeX, BoxSizeY);
        modeBase = DataManager.Instance.GetInteractiveMode(m_InteractiveType, mapType, roomIndex, routeGroupIndex, routeIndex);
        InteractiveData m_interactieData = DataManager.Instance.GetInteractiveDataByType(m_InteractiveType);
        interactiveCountMax = m_interactieData.interactiveCountMax;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        interactiveBtn.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactiveBtn.enabled = false;
    }

    public virtual InteractiveType m_InteractiveType { get; }

    public virtual void InteractiveDataInitialized(AddRoomData _addRoomData) {
        InitAddRoom(_addRoomData);
    }
    /// <summary>
    /// 交互按钮点击
    /// </summary>
    protected virtual void InteractiveBtn_OnClick()
    {
        if (BattleFlowController.Instance.IsBattling || BattleFlowController.Instance.IsInteracting) return;

        AudioManager.Instance.PlayAudio(AudioName.DOOR_Metal_Open_Creak_stereo, AudioType.Common);

        BattleFlowController.Instance.IsInteracting = true;
    }
    /// <summary>
    /// 按键响应
    /// </summary>
    public  void IntoInteractiveOfKeyDown() {
        InteractiveBtn_OnClick();
    }

    private void Update()
    {
        if (BattleFlowController.Instance.IsBattling != isBattling)
        {
            isBattling = BattleFlowController.Instance.IsBattling;
            interactiveBtn.gameObject.SetActive(!isBattling);
        }
    }
    protected virtual void OnDisable()
    {
        BattleFlowController.Instance.IsInteracting = false;
    }
}
