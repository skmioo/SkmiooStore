using Datas;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 技能按钮
/// </summary>
public class SkillButton : MonoBehaviour
{
    //技能中的内容是被roleinfo改写的

    protected Image spell_img;
    protected Image selected_img;

    [HideInInspector]
    public SkillData skill;
    [HideInInspector]
    public SkillMode skillMode;

    /// <summary>
    /// 技能是否可用、冷却、超过可用次数
    /// </summary>
    public bool isOn;


    /// <summary>
    /// 技能起点位置组
    /// </summary>
    bool[] _startPos = new bool[4];
    /// <summary>
    /// 技能终点位置组
    /// </summary>
    bool[] _endPos = new bool[4];

    public bool[] startPos { get {
            ResetSkillPos();//数组坑--- 不同实例下的数组,会使用同一个内存地址?赋值后接过相同找不到原因,故在每次取值前,刷新一次POS组
            return _startPos; }  }

    public bool[] endPos { get {
            ResetSkillPos();
            return _endPos; } }

    [HideInInspector]
    public int level = 0;

    public void SetSkillButton(SkillData _skillData,SkillMode _skillMode)
    {
        if (selected_img == null || spell_img == null)
        {
            selected_img = transform.Find("selected_img").GetComponent<Image>();
            spell_img = transform.Find("spell_img").GetComponent<Image>();
        }

        selected_img.gameObject.SetActive(false);
        spell_img.gameObject.SetActive(true);
        skill = _skillData.Clone();
        skillMode = _skillMode;
        level = skillMode.level;
;
        skill.icon.LoadAssetAsync().Completed += go =>
        {
            spell_img.sprite = go.Result;
        };

        bool isGet = skillMode.level > 0;       
        SetButtonOn(isGet);

        if (skillMode.isUse)
        {
            SelectedOn();
        }

        ResetSkillPos();
    }

    /// <summary>
    ///设置技能是否可用的显示
    /// </summary>
    /// <param name="on"></param>
    public void SetButtonOn(bool on)
    {
        if (on)
        {
            spell_img.color = new Color(1, 1, 1, 1);
        }
        else
        {
            spell_img.color = new Color(1, 1, 1, 0.5f);
        }
    }

    //重置当前按钮的位置组信息
    protected void ResetSkillPos()
    {
        _startPos[0] = skill.position.A;
        _startPos[1] = skill.position.B;
        _startPos[2] = skill.position.C;
        _startPos[3] = skill.position.D;


        _endPos[0] = skill.position.W;
        _endPos[1] = skill.position.X;
        _endPos[2] = skill.position.Y;
        _endPos[3] = skill.position.Z;
    }

    /// <summary>
    /// 被选中
    /// </summary>
    public void SelectedOn()
    {
        selected_img.gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭选中提示
    /// </summary>
    public void SelectedOff()
    {
        selected_img.gameObject.SetActive(false);
    }
}
