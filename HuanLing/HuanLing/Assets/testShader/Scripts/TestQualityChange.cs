// jave.lin 2019.06.26
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestQualityChange : MonoBehaviour
{
    public Dropdown dropdown;
    public Material mat;
    public bool initAutoSelected = true;
    private List<string> showOptions = new List<string>();
    private List<string> dataOptions = new List<string>();
    private void OnEnable()
    {
        dropdown.options.Clear();
        showOptions.Add("Low");
        showOptions.Add("Medium");
        showOptions.Add("High");
        showOptions.Add("Best");

        dataOptions.Clear();
        dataOptions.Add("_Q_LOW");
        dataOptions.Add("_Q_MEDIUM");
        dataOptions.Add("_Q_HIGH");
        dataOptions.Add("_Q_BEST");

        dropdown.onValueChanged.RemoveListener(OnDropdownListValueChange);
        dropdown.onValueChanged.AddListener(OnDropdownListValueChange);
        dropdown.AddOptions(showOptions);

        if (initAutoSelected)
        {
            var selected = -1;
            for (int i = 0; i < dataOptions.Count; i++)
            {
                var kw = dataOptions[i];
                if (Shader.IsKeywordEnabled(kw))
                {
                    selected = i;
                    break;
                }
            }
            for (int i = 0; i < dataOptions.Count; i++)
            {
                var kw = dataOptions[i];
                if (selected != i)
                {
                    Shader.DisableKeyword(kw);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < dataOptions.Count; i++)
            {
                Shader.DisableKeyword(dataOptions[i]);
            }
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < dataOptions.Count; i++)
        {
            Shader.DisableKeyword(dataOptions[i]); // 这里做测试退出时恢复一下相关的全局关键字
        }

        dropdown.onValueChanged.RemoveAllListeners();
        dropdown.options.Clear();
        dataOptions.Clear();
    }
    private void OnDropdownListValueChange(int arg0)
    {
        var opt = dataOptions[arg0];
        for (int i = 0; i < dataOptions.Count; i++)
        {
            if (i == arg0)
            {
                Shader.EnableKeyword(opt);
            }
            else
            {
                Shader.DisableKeyword(dataOptions[i]);
            }
        }
    }
}
