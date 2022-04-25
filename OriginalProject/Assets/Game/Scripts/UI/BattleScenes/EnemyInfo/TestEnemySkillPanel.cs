using Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 测试boss技能的面板
/// </summary>
public class TestEnemySkillPanel : MonoBehaviour
{
	Dictionary<int, TestEnemySkillCellData> objSkills = new Dictionary<int, TestEnemySkillCellData>();
	public Transform skillRoot;
	public List<Transform> skillCell = new List<Transform>();
	public List<TestEnemySkillCell> cells = new List<TestEnemySkillCell>();
	public Action act;
	public Toggle isAutoRun;
	public Toggle IsOnlyShowBoss;
	public static bool isTestEnemySkill = false;
	private void Awake()
	{
		isAutoRun.isOn = true;
		foreach (Transform cell in skillCell)
		{
			cells.Add(new TestEnemySkillCell(cell));
		}
	}

	private void OnEnable()
	{
		isTestEnemySkill = true;
	}

	/// <summary>
	/// 是否跳过回合
	/// </summary>
	public Toggle isSkipRound;
	/// <summary>
	/// 是否跳过回合
	/// </summary>
	public bool IsSkipRound()
	{
		return isSkipRound.isOn;
	}

	public void ShowEnemySkill(ObjLife objLife, Action onNormalMonsterGo)
	{
		if (IsOnlyShowBoss.isOn)
		{
			if (objLife.GetVocation() != HeroVocation.boss)
			{
				onNormalMonsterGo?.Invoke();
				return;
			}
		}
		act = onNormalMonsterGo;
		int id = objLife.GetHashCode();
		if (!objSkills.ContainsKey(id))
		{
			objSkills.Add(id, new TestEnemySkillCellData(objLife));
		}
		
		for (int i = 0; i < objSkills[id].skillDataStates.Count; i++)
		{
			if (i < objSkills[id].skillDataStates.Count)
			{
				cells[i].SetSkillData(objSkills[id].skillDataStates[i]);
			}
			else
			{
				cells[i].SetSkillData(null);
			}
		}
		if (isAutoRun.isOn)
		{
			MonstorGo();
		}
	}

	public void MonstorGo()
	{
		act?.Invoke();
		act = null;
			
	}

	internal bool EnemyCanUseSkill(ObjLife objLife, SkillData skillData)
	{
		int id = objLife.GetHashCode();
		if (!objSkills.ContainsKey(id))
		{
			return true;
		}
		SkillDataState state = objSkills[id].skillDataStates.Find(data => { return data.skillData.id == skillData.id; });
		return state != null ? state.isSkillUse : true;
	}
}

public class TestEnemySkillCell
{
	Transform cell;
	SkillDataState skillData;
	Toggle isSkillOn;
	Text label;
	public TestEnemySkillCell(Transform _cell)
	{
		cell = _cell;
		isSkillOn = cell.transform.GetComponentInChildren<Toggle>();
		label = isSkillOn.transform.GetComponentInChildren<Text>();
		isSkillOn.onValueChanged.AddListener(isOn => skillData.isSkillUse = isOn);
	}

	internal void SetSkillData(SkillDataState _skillData)
	{
		skillData = _skillData;
		if (_skillData != null)
		{
			isSkillOn.isOn = _skillData.isSkillUse;
			label.text = _skillData.skillData.id + " " + _skillData.skillData.name;
		}
		cell.gameObject.SetActive(_skillData != null);
	}
}

public class TestEnemySkillCellData
{
	public List<SkillDataState> skillDataStates = new List<SkillDataState>();
	public TestEnemySkillCellData(ObjLife objLife)
	{
		List<SkillData> skills = DataManager.Instance.GetSkillDatasByIds(objLife.GetHaveSkill());
		skills.ForEach(x => skillDataStates.Add(new SkillDataState(x, true)));
	}
}

public class SkillDataState
{
	public SkillData skillData;
	public bool isSkillUse;
	public SkillDataState(SkillData _skillData, bool _isSkillUse)
	{
		skillData = _skillData;
		isSkillUse = _isSkillUse;
	}


}
