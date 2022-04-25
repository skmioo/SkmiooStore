using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士气技能按钮
/// 继承自skillbutton  ，只改变其设置技能信息
/// </summary>
/*public class OtherSkillButton : SkillButton
{
    
    public void SetOtherSkill(RoleBattleingData roleBattleingData,SkillData _skillData,int _level)
    {
        selected_img.gameObject.SetActive(false);

        if (_skillData == null)
        {
            spell_img.gameObject.SetActive(false);
            return;
        }

        spell_img.gameObject.SetActive(true);
        skill = _skillData.Clone();
        level = _level;

        skillBattleingData = roleBattleingData.otherSkill;
        skill_roleBingData = roleBattleingData;


        skill.icon.LoadAssetAsync().Completed += go =>
        {
            spell_img.sprite = go.Result;
        };


        ResetSkillPos();

        if (roleBattleingData.objLife.roleUi.statusBox.moraleCount > 0)
        {
            isOn = true;
        }

        if (!startPos[roleBattleingData.numInTeam])
        {
            isOn = false;
        }

        SetButtonOn(isOn);
    }


}
*/