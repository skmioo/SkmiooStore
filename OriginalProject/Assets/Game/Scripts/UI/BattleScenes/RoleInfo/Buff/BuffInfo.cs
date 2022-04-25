using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuffInfo : MonoBehaviour
{
    public Camera _camera;
    public Canvas canvas;
    public Text txtContent;
    public RectTransform rectTrans { get { return transform as RectTransform; } }
    public void Show(Vector2 position, List<ObjSkillBuff> objSkillBuffs)
    {
        //复制一份技能buff列表
        List<ObjSkillBuff> buffs = new List<ObjSkillBuff>();
        foreach (var b in objSkillBuffs)
        {
            buffs.Add(new ObjSkillBuff(b));
        }

        //合并相同buff
        List<ObjSkillBuff> result = buffs;
        /*result = buffs;
        while (buffs.Count > 0)
        {
            ObjSkillBuff sb = buffs[0];
            ObjBuffType bt = sb.buffType;
            ValueType vt = sb.valueType;
            result.Add(new ObjSkillBuff(bt, vt,
                buffs.Where(t => t.buffType.Equals(sb) && t.valueType.Equals(vt)).Sum(v => v.buffValue),
                buffs.Where(t => t.buffType.Equals(sb) && t.valueType.Equals(vt)).Min(r => r.round)));
            buffs.RemoveAll(t => t.buffType.Equals(sb) && t.valueType.Equals(vt));
        }*/

        //转为字符串
        string str = "";
        foreach (var r in result)
        {
            str += r.buffType.ToString() + '\t' + (r.buffValue > 0 ? "+" : "") + r.buffValue.ToString() + (r.valueType.Equals(ValueType.系数) ? "%" : " ") 
                + "\t剩余回合" + (r.round > 100 ? "∞" : r.round.ToString()) + "$";
        }
        transform.GetComponentInChildren<Text>().text = str.Replace("$","\n");

        //显示
        Vector3 pos = _camera.WorldToScreenPoint(position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pos, canvas.worldCamera, out Vector2 res);
        res += new Vector2(transform.GetComponent<RectTransform>().rect.width - 200f, -transform.GetComponent<RectTransform>().rect.height - 80f) / 2f;
        transform.localPosition = res;
    }
    public void Show(string str, UnityAction _initCallBack = null) {
        txtContent.text = str;
        _initCallBack?.Invoke();
    }
    public void Hidden()
    {
        transform.localPosition = new Vector3(-1000, -2000);
    }
    public void Hidden(UnityAction _complete = null) {
        _complete?.Invoke();
    }
}
