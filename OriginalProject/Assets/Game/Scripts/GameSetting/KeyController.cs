using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 按键选项控制类
/// </summary>
public static class KeyController
{
    public enum KeyEvent
    { 
        //顺序和UI中的顺序对应
        打开帮助页面,
        查看英雄人物页,
        切换到上一个英雄,
        切换到下一个英雄,
        向左移动,
        向右移动,
        快速施放第1个技能,
        快速施放第2个技能,
        快速施放第3个技能,
        快速施放第4个技能,
        快速施放士气技能,
        换位,
        全部拿走战利品,
        切换地图背包,
        进入下一个房间or与交互物互动
    }

    private static Dictionary<KeyEvent, KeyCode> keyDictionary;

    static KeyController() //暂时使用静态构造函数为其指定初始值
    {
        keyDictionary = new Dictionary<KeyEvent, KeyCode>
        {
            { KeyEvent.打开帮助页面, KeyCode.H },
            { KeyEvent.查看英雄人物页, KeyCode.Mouse1 },
            { KeyEvent.切换到上一个英雄, KeyCode.Q },
            { KeyEvent.切换到下一个英雄, KeyCode.E },
            { KeyEvent.向左移动, KeyCode.A },
            { KeyEvent.向右移动, KeyCode.D },
            { KeyEvent.快速施放第1个技能, KeyCode.Alpha1 },
            { KeyEvent.快速施放第2个技能, KeyCode.Alpha2 },
            { KeyEvent.快速施放第3个技能, KeyCode.Alpha3 },
            { KeyEvent.快速施放第4个技能, KeyCode.Alpha4 },
            { KeyEvent.快速施放士气技能, KeyCode.Alpha5 },
            { KeyEvent.换位, KeyCode.Alpha6 },
            { KeyEvent.全部拿走战利品, KeyCode.Space },
            { KeyEvent.切换地图背包, KeyCode.Tab },
            { KeyEvent.进入下一个房间or与交互物互动, KeyCode.W }
        };
    }

    /// <summary>
    /// 获取触发事件列表
    /// </summary>
    public static Dictionary<KeyEvent, KeyCode> GetKeyDictionary()
    {
        return keyDictionary;
    }

    /// <summary>
    /// 获取触发事件的按键
    /// </summary>
    /// <param name="_keyEvent">事件</param>
    /// <returns>按键</returns>
    public static KeyCode GetKeyCodeByEvent(KeyEvent _keyEvent)
    {
        return keyDictionary[_keyEvent];
    }

    /// <summary>
    /// 更改触发事件的按键
    /// </summary>
    /// <param name="_keyEvent">事件</param>
    /// <param name="_keyCode">按键</param>
    public static void UpdateKeyDictionary(KeyEvent _keyEvent, KeyCode _keyCode)
    {
        keyDictionary[_keyEvent] = _keyCode;
    }    
    public static List<int> GetIndexListRepetionKey()
    {
        List<int> res = new List<int>();
        for (int i = 0; i < keyDictionary.Count; i++)
        {
            for (int j = i + 1; j < keyDictionary.Count; j++)
            {
                if (keyDictionary[(KeyEvent)i] == keyDictionary[(KeyEvent)j])
                {
                    if (!res.Exists(s => s.Equals(i)))
                    {
                        res.Add(i);
                    }
                    if (!res.Exists(s => s.Equals(j)))
                    {
                        res.Add(j);
                    }
                }
            }
        }
        return res;
    }

}
