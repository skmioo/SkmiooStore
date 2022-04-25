using UnityEngine;
using System.Collections;

public class LuckyRoll : MonoBehaviour
{

    //幸运转盘
    private Transform mRoolPanel;

    //初始旋转速度
    private float mInitSpeed;
    //速度变化值
    private float mDelta = 1f;

    //转盘是否暂停
    private bool isPause = true;

    void Start()
    {
        //获取转盘
        mRoolPanel = GameObject.Find("pointer").transform;
    }

    //开始抽奖
    public void OnClick()
    {
        if (isPause)
        {
            //随机生成一个初始速度
            mInitSpeed = Random.Range(500, 2000);
            //开始旋转
            isPause = false;
        }
    }

    void Update()
    {
        if (!isPause)
        {

            //转动转盘(-1为顺时针,1为逆时针)
            mRoolPanel.Rotate(new Vector3(0, 0, -1) * mInitSpeed * Time.deltaTime);
            //让转动的速度缓缓降低
            mInitSpeed -= mDelta;
            //当转动的速度为0时转盘停止转动
            if (mInitSpeed <= 0)
            {
                //转动停止
                isPause = true;

            }
        }
    }
}