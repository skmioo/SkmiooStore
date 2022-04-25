using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSkillInfoUI : HoverInfoUI
{
    public List<PositionInfoUI> positionInfos;

    public void AddPositionInfo(int index,List<bool> positions)
    {
        positionInfos[index].gameObject.SetActive(true);
        positionInfos[index].SetPositions(positions);
        positionInfos[index].transform.SetAsLastSibling();
    }

    public override void ClearData()
    {
        base.ClearData();
        for (int i = 0; i < positionInfos.Count; i++)
        {
            positionInfos[i].gameObject.SetActive(false);
        }
    }
}
