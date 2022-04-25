using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    forward,
    back
}
/// <summary>
/// 队伍移动控制脚本
/// </summary>
public class MoveTeam : MonoSingleton<MoveTeam>
{
    public GameObject leftButton;
    public GameObject rightButton;
    [HideInInspector]
    public int goBackRoadCount = 0;
    [HideInInspector]
    public int goForwordRoadCount = 0;
    MoveDirection _moveDirection;
    private Transform showRoomRoad1;
    private Transform showRoomRoad2;
    public MoveDirection moveDirection
    {
        get
        {
            return _moveDirection;
        }
        set
        {
            if (_moveDirection != value)
            {
                goBackRoadCount = 0;
                goForwordRoadCount = 0;
                _moveDirection = value;
            }

        }
    }
    static float _moveX;
    public static float moveX
    {
        get
        {
            if (!BattleFlowController.Instance.CheckCanMove())
            {
                return 0;
            }
            else if (leftLimit)
            {
                if (_moveX < 0)
                {
                    return 0;
                }
            }
            else if (rightLimit)
            {
                if (_moveX > 0)
                {
                    return 0;
                }
            }

            return _moveX;
        }
    }

    public float speed = 5;
    public float fRoadSpeed1 = 3f;
    public float fRoadSpeed2 = 4.5f;
    Rigidbody2D _rigidbody2D;

    bool buttonDown;
    private const float MoveXRatio = 0.5f;
    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UIEventManager.AddTriggersListener(leftButton).onClickDwon += LeftButtonDwon;
        UIEventManager.AddTriggersListener(rightButton).onClickDwon += RightButtonDwon;

        UIEventManager.AddTriggersListener(leftButton).onClickUp += ButtonUp;
        UIEventManager.AddTriggersListener(rightButton).onClickUp += ButtonUp;

        showRoomRoad1 = MapController.Instance.showRoomRoad1;
        showRoomRoad2 = MapController.Instance.showRoomRoad2;
    }
    public void UpdateMoveForwardOrBackCount()
    {
        if (moveDirection == MoveDirection.forward)
        {
            goForwordRoadCount++;
        }
        else
        {
            goBackRoadCount++;
        }
    }

    private void ButtonUp(GameObject go)
    {
        NewbieGuideMag.Instance.triggerGuide(GuideDataSet.guideEnum.move);
        buttonDown = false;
        _moveX = 0;
    }

    private void LeftButtonDwon(GameObject go)
    {
        if (buttonDown) return;
        buttonDown = true;

        _moveX = -1f;

    }

    private void RightButtonDwon(GameObject go)
    {
        if (buttonDown) return;
        buttonDown = true;

        _moveX = 1f;

    }

    private void FixedUpdate()
    {
        //if (!buttonDown)
        //{
        //    _moveX = Input.GetAxis("Horizontal");
        //    Debug.Log("测试-Input.GetAxis:" + _moveX);
        //}
        RecalculationMoveX(ref _moveX);
        if (!Mathf.Approximately(moveX, 0))
        {
            if (moveX < 0)
            {
                moveDirection = MoveDirection.back;
            }
            else
            {
                moveDirection = MoveDirection.forward;
            }
            float goX = _rigidbody2D.position.x + moveX * speed * Time.deltaTime;
            if(FightingCameraCon.Instance.CheckRoadCanMove())
            {
                float goX1 = showRoomRoad1.position.x + moveX * fRoadSpeed1 * Time.deltaTime;
                float goX2 = showRoomRoad2.position.x + moveX * fRoadSpeed2 * Time.deltaTime;
                showRoomRoad1.position = new Vector3(goX1, showRoomRoad1.position.y, showRoomRoad1.position.z);
                showRoomRoad2.position = new Vector3(goX2, showRoomRoad2.position.y, showRoomRoad2.position.z);
            }

            Vector2 goMove = new Vector2(goX, _rigidbody2D.position.y);
            //transform.position.Set(goX, transform.position.y, transform.position.z);
            _rigidbody2D.MovePosition(goMove);
            //如何把我正在移动这件事儿告诉角色的状态机
        }
    }
    private void RecalculationMoveX(ref float cur_moveX)
    {
        if (Mathf.Approximately(cur_moveX, -1f)) cur_moveX *= MoveXRatio;
        else if (Mathf.Approximately(cur_moveX, 1f)) cur_moveX *= 1f;
    }
    public void MoveTo(MoveDirect _direct)
    {
        if (buttonDown) return;
        buttonDown = true;

        if (!MapController.Instance.isZoomOut)
        {
            MapController.Instance.OnMapZoomOut();
        }

        switch (_direct)
        {
            case MoveDirect.left: _moveX = -1f; break;
            case MoveDirect.right: _moveX = 1f; break;
        }

    }
    public void MoveEnd()
    {

        buttonDown = false;
        _moveX = 0;
    }
    public enum MoveDirect { left, right }
    static bool leftLimit;
    static bool rightLimit;
    float limit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RoomLeftLimit")
        {
            leftLimit = true;
            limit = transform.position.x;
        }
        else if (collision.tag == "RoomRightLimit")
        {
            rightLimit = true;
            limit = transform.position.x;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "RoomLeftLimit")
        {
            leftLimit = false;
        }
        else if (collision.tag == "RoomRightLimit")
        {
            rightLimit = false;
        }
    }

}
