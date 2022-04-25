using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleDefenseInfo : MonoBehaviour
{
    public Text vertiogo;
    public Text poison;
    public Text bleed;
    public Text position;
    public Text debuff;
    public Text death;


    public void SetInfo(ObjLife objLife)
    {
        vertiogo.text = $"眩晕 ：{objLife.GetVertigo()}";
        poison.text = $"中毒 ：{objLife.GetPoison()}";
        bleed.text = $"流血 ：{objLife.GetBleed()}";
        position.text = $"位移 ：{objLife.GetPosition()}";
        debuff.text = $"减益 ：{objLife.GetDebuff()}";
        death.text = $"即死 ：{objLife.GetDeath()}";

    }


}
