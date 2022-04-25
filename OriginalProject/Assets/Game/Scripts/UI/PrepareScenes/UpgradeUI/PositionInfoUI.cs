using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionInfoUI : MonoBehaviour
{
    public List<Toggle> points;

    public void SetPositions(List<bool> positions)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i].isOn = positions[i];
        }
    }
}
