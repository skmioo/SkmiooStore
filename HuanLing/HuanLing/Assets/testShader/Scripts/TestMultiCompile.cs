// jave.lin 2019.06.24
using System.Collections.Generic;
using UnityEngine;

public enum AMBIENT_TOGGLE
{
    On,
    Off
}

public enum AMBIENT_COLOR_TYPE
{
    LightModel,
    Sky,
    Equator,
    Ground
}

public enum AMBIENT_APPLY_ONLY_R
{
    On,
    Off
}

public enum CompileShaderType
{
	UnKnow,
	ByScript,
	ByKeywordEnum
}

public class TestMultiCompile : MonoBehaviour
{
    public AMBIENT_TOGGLE ambientToggle = AMBIENT_TOGGLE.On;
    public AMBIENT_COLOR_TYPE ambientColorType = AMBIENT_COLOR_TYPE.LightModel;
	public AMBIENT_APPLY_ONLY_R ambientApplyOnlyR = AMBIENT_APPLY_ONLY_R.Off;

	public CompileShaderType compileShaderType = CompileShaderType.ByScript;
	public string[] enabledLocalKeywords;

    private MeshRenderer[] mrs;
    // Start is called before the first frame update
    void Start()
    {
        mrs = GetComponentsInChildren<MeshRenderer>();
        //避免有时你在退出unity运行时，有些开关的状态还是退出钱的设置，所以这里需要初始化一下
        //string[] allGlobalKeywords = { ... }; // 所有你想控制的全局关键字数组
        //for (int i = 0; i < allGlobalKeywords.Length; i++)
        //{
        //  Shader.DisableKeyword(allGlobalKeywords[i]);
        //}
        //然后有些需要Enable的，可以在下面这里再Enable
        //对局部的关键字就不需要上面的处理，因为你可以从Material.shaderKeywords里很容易看出来
        //对关键字的维护，可以参考TestMultiCompileEditor.cs的写法（目前是简单的写法）
        List<string> dataOptions = new List<string>();
        dataOptions.Add("_Q_LOW");
        dataOptions.Add("_Q_MEDIUM");
        dataOptions.Add("_Q_HIGH");
        dataOptions.Add("_Q_BEST");
        for (int i = 0; i < dataOptions.Count; i++)
        {
            Shader.DisableKeyword(dataOptions[i]); // 这里做测试启动时恢复一下相关的全局关键字
        }
    }

// Update is called once per frame
void Update()
    {
        // 应用优先级会被Shader.material.Enable/DisableKeyword覆盖
        if (ambientToggle == AMBIENT_TOGGLE.On)
            Shader.EnableKeyword("AMBIENT_ON");
        else
            Shader.DisableKeyword("AMBIENT_ON");

        // 下面的Enable/DisableKeyword都可以封装一下，用分组的方式，让同一组的互斥就好了
        switch (ambientColorType)
        {
            case AMBIENT_COLOR_TYPE.LightModel:
                Shader.EnableKeyword("LIGHTMODEL_AMBIENT");
                Shader.DisableKeyword("SKY_COLOR");
                Shader.DisableKeyword("EQUATOR_COLOR");
                Shader.DisableKeyword("GROUND_COLOR");
                break;
            case AMBIENT_COLOR_TYPE.Sky:
                Shader.DisableKeyword("LIGHTMODEL_AMBIENT");
                Shader.EnableKeyword("SKY_COLOR");
                Shader.DisableKeyword("EQUATOR_COLOR");
                Shader.DisableKeyword("GROUND_COLOR");
                break;
            case AMBIENT_COLOR_TYPE.Equator:
                Shader.DisableKeyword("LIGHTMODEL_AMBIENT");
                Shader.DisableKeyword("SKY_COLOR");
                Shader.EnableKeyword("EQUATOR_COLOR");
                Shader.DisableKeyword("GROUND_COLOR");
                break;
            case AMBIENT_COLOR_TYPE.Ground:
                Shader.DisableKeyword("LIGHTMODEL_AMBIENT");
                Shader.DisableKeyword("SKY_COLOR");
                Shader.DisableKeyword("EQUATOR_COLOR");
                Shader.EnableKeyword("GROUND_COLOR");
                break;
            default:
                break;
        }

        SetApplyOnlyR(ambientApplyOnlyR);

        // material.shaderKeywrods只会返回局部的关键字，所以Shader.EnableKeyword设置的是不会在这增加的
        enabledLocalKeywords = mrs[0].sharedMaterial.shaderKeywords;
    }

    private void SetApplyOnlyR(AMBIENT_APPLY_ONLY_R v)
    {

        for (int i = 0; i < mrs.Length; i++)
        {
            var mr = mrs[i];
            switch (v)
            {
                case AMBIENT_APPLY_ONLY_R.On:
                    mr.sharedMaterial.EnableKeyword("AMBIENT_ONLY_R");
                    break;
                case AMBIENT_APPLY_ONLY_R.Off:
                    mr.sharedMaterial.DisableKeyword("AMBIENT_ONLY_R");
                    break;
                default:
                    break;
            }
        }
    }
}