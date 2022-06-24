// jave.lin 2019.06.24
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(TestMultiCompile))]
public class TestMultiCompileEditor : Editor
{
	// 可以从配置中读取
	private string[][] globalKeywordList =
    {
        new string[]{ "AMBIENT_ON", },  // group one
        new string[]{                   // group two
        "LIGHTMODEL_AMBIENT",
        "SKY_COLOR",
        "EQUATOR_COLOR",
        "GROUND_COLOR",
        }
    };
    // 可以从配置中读取
    private string[][] localKeywordList =
    {
        new string[] {"AMBIENT_ONLY_R", }   // group
    };

    private Material m;

    private bool globalKeywordFoldSummary = true;
    private bool localKeywordFoldSummary = true;
	TestMultiCompile m_Target;
	CompileShaderType compileShaderType = CompileShaderType.UnKnow;
	private void OnEnable()
	{
		m_Target = target as TestMultiCompile;
	}

	public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

		//AssetDatabase是一个对资源进行读写和各种操作的接口；
		//然而因为这是一个编辑类，当需要使用的时候把他放在工程目录下的Assets / Editor 文件夹下
		if (compileShaderType != m_Target.compileShaderType)
		{
			compileShaderType = m_Target.compileShaderType;
			if (compileShaderType == CompileShaderType.ByScript)
			{
				m = AssetDatabase.LoadAssetAtPath<Material>("Assets/testShader/Materials/TestMulitCompileByScript.mat");
			}
			if (compileShaderType == CompileShaderType.ByKeywordEnum)
			{
				m = AssetDatabase.LoadAssetAtPath<Material>("Assets/testShader/Materials/TestMulitCompileByShaderKeywordEnum.mat");
			}
		}
	

		int idx = 0;
        const int indent = 1;
        // global
        globalKeywordFoldSummary = EditorGUILayout.Foldout(globalKeywordFoldSummary, "Global Keyword Summary");
        if (globalKeywordFoldSummary)
        {
			//字段后移
            EditorGUI.indentLevel += indent;
			GUILayout.Label("显示Shader中字段是否为true:");
			//  Shader.EnableKeyword("FAKE_BLOOM");
			idx = 0;
            foreach (var kws in globalKeywordList)
            {
                EditorGUILayout.Foldout(true, $"Global Keyword_Group{idx++}");
                foreach (var kw in kws)
                {
                    EditorGUILayout.Toggle(kw, Shader.IsKeywordEnabled(kw));
                }
            }
            EditorGUI.indentLevel -= indent;
        }

        // local
        localKeywordFoldSummary = EditorGUILayout.Foldout(localKeywordFoldSummary, "Local Keyword Summary");
        if (localKeywordFoldSummary && m != null)
        {
            EditorGUI.indentLevel += indent;
            idx = 0;
            foreach (var kws in localKeywordList)
            {
                EditorGUILayout.Foldout(true, $"Local Keyword_Group{idx++}");
                foreach (var kw in kws)
                {
                    EditorGUILayout.Toggle(kw, m.IsKeywordEnabled(kw));
                }
            }
            EditorGUI.indentLevel -= indent;
        }
    }
}