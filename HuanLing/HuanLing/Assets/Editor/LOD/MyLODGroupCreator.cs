#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public static class MyLODGroupCreator
{
	public static bool s_SearchAllRenderer = false;

	const string c_strLODGroupName = "_LODGroup";
	const string c_strLODName = "_$LOD_";
	const string c_strLODPath = "LOD";
	const string c_strAssetsDataPath = "Assets/AssetsData/Scene";

	enum SceneShaderType
	{
		Normal = 0,
		Alpha,
		AlphaTest,
		UnKnown,
	}

	readonly static string[] c_NormalSceneShaders =
	   {
			"AUYShader/Scene/TCLM/Normal",
			"AUYShader/Scene/CPLM/Normal"
		};
	readonly static string[] c_AlphaSceneShaders =
	{
			"AUYShader/Scene/TCLM/Alpha",
			"AUYShader/Scene/CPLM/Alpha"
		};
	readonly static string[] c_AlphaTestSceneShaders =
	{
			"AUYShader/Scene/TCLM/AlphaTest",
			"AUYShader/Scene/CPLM/AlphaTest"
		};

	const string c_strFakeLMSceneNormalShaderName = "AUYShader/Scene/FakeLM/Normal";
	const string c_strFakeLMSceneAlphaShaderName = "AUYShader/Scene/FakeLM/Alpha";
	const string c_strFakeLMSceneAlphaTestShaderName = "AUYShader/Scene/FakeLM/AlphaTest";

	enum ShaderType
	{
		OutlineShadow = 0,
		Outline,
		UnKnown,
	}

	static SceneShaderType checkShaderType(string strName)
	{
		SceneShaderType sst = SceneShaderType.UnKnown;
		foreach (var strNameToCheck in c_NormalSceneShaders)
		{
			if (strNameToCheck == strName)
			{
				sst = SceneShaderType.Normal;
				break;
			}
		}
		if (sst == SceneShaderType.UnKnown)
		{
			foreach (var strNameToCheck in c_AlphaSceneShaders)
			{
				if (strNameToCheck == strName)
				{
					sst = SceneShaderType.Alpha;
					break;
				}
			}
		}
		if (sst == SceneShaderType.UnKnown)
		{
			foreach (var strNameToCheck in c_AlphaTestSceneShaders)
			{
				if (strNameToCheck == strName)
				{
					sst = SceneShaderType.AlphaTest;
					break;
				}
			}
		}
		return sst;
	}
	static MyLODSimplify s_LODQuadrics = new MyLODSimplify();

	/// <summary>
	/// 配置模型导入设置 可读写 不需要光照贴图uv 不需要法线跟切线数据 并重新导入
	/// 生成LODGroup
	/// </summary>
	/// <param name="go"></param>
	/// <param name="listLODParams">移除的模型比例系数 决定着生成的模型的顶点三角形数量</param>
	/// <param name="listSRTs">Lod相对屏幕比例大小  决定着使用哪个lod模型</param>
	public static void CreateLODGroup(this GameObject go, List<float> listLODParams, List<float> listSRTs)
	{
		if (listLODParams != null && listLODParams.Count > 0)
		{
			go.RemoveLODGroup();
			var activeScene = SceneManager.GetActiveScene();
			string strSceneName = activeScene.name;
			string strScenePath = c_strAssetsDataPath + "/" + c_strLODPath + "/" + strSceneName;
			MeshFilter mf = go.GetComponent<MeshFilter>();
			MeshRenderer mr = go.GetComponent<MeshRenderer>();
			if (mf != null && mr != null)
			{
				Mesh mesh = mf.sharedMesh;
				bool bNeedRevertReadable = false;
				bool bNeedRevertLMUV = false;
				ModelImporterNormals oldNormalImporter = ModelImporterNormals.None;
				ModelImporterTangents oldTangentImporter = ModelImporterTangents.None;
				string strMeshPath = "";
				//只要点击场景中的mesh网格文件能对应到资源文件，是可以找到的
				if (AssetDatabase.Contains(mesh))
				{
					strMeshPath = AssetDatabase.GetAssetPath(mesh);
					string strMeshFileName = mesh.name;
					if (strMeshFileName == null || strMeshFileName.Length <= 0)
					{
						strMeshFileName = Path.GetFileNameWithoutExtension(strMeshPath);
					}
					//进行一些模型导入的配置修改才可以进行模型的读取
					//默认 不可读写 
					bool bCloseReadable = !mesh.isReadable;
					bool bHasUV2 = (mesh.uv2 != null && mesh.uv2.Length > 0);
					bool bHasNormal = mesh.normals != null && mesh.normals.Length > 0;
					if (bCloseReadable || bHasUV2 || bHasNormal)
					{
						var meshImporter = AssetImporter.GetAtPath(strMeshPath) as ModelImporter;
						if (bCloseReadable)
						{
							//Read/Write Enabled:启⽤此选项后，Unity会将Mesh数据上传到GPU可寻址的内存，但也将其保留在CPU可寻址的内存中。这意味着Unity
							//可以在运⾏时访问Mesh数据，并且您可以从脚本中访问它。例如，如果您要按程序⽣成⽹格，或者要从⽹格复制某些数据，则可能要执⾏此
							//操作。禁⽤此选项后，Unity会将Mesh数据上传到GPU可寻址的内存，然后将其从CPU可寻址的内存中删除。默认情况下，此选项是禁⽤
							//的。在⼤多数情况下，要节省运⾏时内存使⽤量，请禁⽤此选项。
							meshImporter.isReadable = true;
							bNeedRevertReadable = true;
						}
						if (bHasUV2)
						{
							//SecondaryUV用于光照贴图uv
							if (meshImporter.generateSecondaryUV)
							{
								meshImporter.generateSecondaryUV = false;
								bNeedRevertLMUV = true;
							}
						}
						if (bHasNormal)
						{
							//ModelImporterNormals.Import 从模型文件中导入顶点法线（默认设置）。
							if (meshImporter.importNormals != ModelImporterNormals.None)
							{
								oldNormalImporter = meshImporter.importNormals;
								meshImporter.importNormals = ModelImporterNormals.None;
							}
							//系统默认ModelImporterTangents.CalculateMikk	使用 MikkTSpace 计算切线（默认设置）。
							if (meshImporter.importTangents != ModelImporterTangents.None)
							{
								oldTangentImporter = meshImporter.importTangents;
								meshImporter.importTangents = ModelImporterTangents.None;
							}
						}
					}
					if (bNeedRevertLMUV || bNeedRevertReadable || oldNormalImporter != ModelImporterNormals.None || oldTangentImporter != ModelImporterTangents.None)
					{
						//保存修改后的配置 可读写 不需要光照贴图uv 不需要法线跟切线数据
						AssetDatabase.WriteImportSettingsIfDirty(strMeshPath);
						//重新导入文件 
						AssetDatabase.ImportAsset(strMeshPath);
						//刷新文件
						AssetDatabase.Refresh();
						//此处使用LoadAllAssetsAtPath因为 虽然 文件是FBX文件 但加载后会有GameObject,Mesh,Transform,MeshFilter,MeshRenderer
						//见LODTestWindow 	if (GUILayout.Button("Test Mesh File Read"))
						var meshs = AssetDatabase.LoadAllAssetsAtPath(strMeshPath);
						//重新获取导入后的mesh数据
						foreach (var subObject in meshs)
						{
							if (subObject is Mesh)
							{
								var meshTest = subObject as Mesh;
								if (meshTest.name == mesh.name)
								{
									mesh = meshTest;
									break;
								}
							}
						}
					}

					//如果存在旧版本的checkShaderType材质 创建新的对应的材质,这些材质都是消耗性能很低的材质，用于生成的LOD模型上使用
					List<Material> listLODMats = new List<Material>();
					foreach (var matOri in mr.sharedMaterials)
					{
						var matLod = matOri;
						string strShaderName = matOri.shader.name;
						SceneShaderType sst = checkShaderType(strShaderName);
						if (sst != SceneShaderType.UnKnown)
						{
							Shader shaderNew = null;
							switch (sst)
							{
								case SceneShaderType.Normal:
									{
										shaderNew = Shader.Find(c_strFakeLMSceneNormalShaderName);
										break;
									}
								case SceneShaderType.Alpha:
									{
										shaderNew = Shader.Find(c_strFakeLMSceneAlphaShaderName);
										break;
									}
								case SceneShaderType.AlphaTest:
									{
										shaderNew = Shader.Find(c_strFakeLMSceneAlphaTestShaderName);
										break;
									}
							}
							if (shaderNew != null)
							{
								string strMatFileName = matOri.name + ".mat";
								string strMatFileFullPath = strScenePath + "/" + strMatFileName;
								string strGUID = AssetDatabase.AssetPathToGUID(strMatFileFullPath);
								if (strGUID != null && strGUID.Length > 0)
								{
									matLod = AssetDatabase.LoadAssetAtPath<Material>(strMatFileFullPath);
								}
								if (matLod == matOri || matLod == null)
								{
									matLod = new Material(matOri);
									matLod.shader = shaderNew;
									string strLODPath = c_strAssetsDataPath + "/" + c_strLODPath;
									if (!AssetDatabase.IsValidFolder(strLODPath))
									{
										AssetDatabase.CreateFolder(c_strAssetsDataPath, c_strLODPath);
										AssetDatabase.Refresh();
									}
									if (!AssetDatabase.IsValidFolder(strScenePath))
									{
										AssetDatabase.CreateFolder(strLODPath, strSceneName);
										AssetDatabase.Refresh();
									}
									AssetDatabase.CreateAsset(matLod, strMatFileFullPath);
									AssetDatabase.Refresh();
								}
							}
						}
						listLODMats.Add(matLod);
					}

					//添加LODGroup组件
					LODGroup cptLODGrp = go.GetComponent<LODGroup>();
					if (!cptLODGrp)
					{
						cptLODGrp = go.AddComponent<LODGroup>();
					}
					cptLODGrp.fadeMode = LODFadeMode.None;
					UnityEngine.LOD[] lods = new UnityEngine.LOD[listLODParams.Count + 1];
					Renderer[] renderersLOD0 = new Renderer[1];
					renderersLOD0[0] = mr;
					float[] srts = listSRTs.ToArray();
					// lods[0] 为 默认的模型LOD
					lods[0] = new UnityEngine.LOD(srts[0], renderersLOD0);
					//添加剩余LOD模型 生成LOD模型资源
					for (int nLOD = 1; nLOD <= listLODParams.Count; nLOD++)
					{
						float fRemoveFaceRatio = listLODParams[nLOD - 1];
						Mesh meshLOD = null;

						string strLODMeshFileName = strMeshFileName + c_strLODName + nLOD.ToString() + ".asset";
						string strLODMeshFileFullPath = strScenePath + "/" + strLODMeshFileName;
						string strGUID = AssetDatabase.AssetPathToGUID(strLODMeshFileFullPath);
						if (strGUID != null && strGUID.Length > 0)
						{
							meshLOD = AssetDatabase.LoadAssetAtPath<Mesh>(strLODMeshFileFullPath);
						}
						if (meshLOD == null)
						{
							int nTriCount = mesh.triangles.Length / 3;
							int nTargetTriCount = Mathf.RoundToInt(nTriCount * (1 - fRemoveFaceRatio));
							//nTargetTriCount = nTriCount - 1;
							meshLOD = s_LODQuadrics.GenLOD(mesh, nTargetTriCount);
							string strLODPath = c_strAssetsDataPath + "/" + c_strLODPath;
							if (!AssetDatabase.IsValidFolder(strLODPath))
							{
								AssetDatabase.CreateFolder(c_strAssetsDataPath, c_strLODPath);
								AssetDatabase.Refresh();
							}

							if (!AssetDatabase.IsValidFolder(strScenePath))
							{
								AssetDatabase.CreateFolder(strLODPath, strSceneName);
								AssetDatabase.Refresh();
							}
							AssetDatabase.CreateAsset(meshLOD, strLODMeshFileFullPath);
							AssetDatabase.Refresh();
						}

						//生成lod的GameObject，并绑定生成的Mesh跟材质
						GameObject goLOD = new GameObject();
						var mfLOD = goLOD.AddComponent<MeshFilter>();
						mfLOD.sharedMesh = meshLOD;
						var mrLOD = goLOD.AddComponent<MeshRenderer>();
						mrLOD.sharedMaterials = listLODMats.ToArray();

						goLOD.name = go.name + c_strLODName + nLOD.ToString();
						goLOD.transform.SetParent(go.transform);
						goLOD.transform.localPosition = Vector3.zero;
						goLOD.transform.localRotation = Quaternion.identity;
						goLOD.transform.localScale = Vector3.one;

						//配置Lod
						Renderer[] renderersLOD = new Renderer[1];
						renderersLOD[0] = mrLOD;
						lods[nLOD] = new UnityEngine.LOD(srts[nLOD], renderersLOD);
					}
					//配置LODGroup
					cptLODGrp.SetLODs(lods);
					cptLODGrp.RecalculateBounds();
				}

				//恢复为之前的模型导入配置
				if (bNeedRevertLMUV || bNeedRevertReadable || oldNormalImporter != ModelImporterNormals.None || oldTangentImporter != ModelImporterTangents.None)
				{
					var meshImporter = AssetImporter.GetAtPath(strMeshPath) as ModelImporter;
					if (bNeedRevertReadable)
					{
						meshImporter.isReadable = false;
					}
					if (bNeedRevertLMUV)
					{
						meshImporter.generateSecondaryUV = true;
					}
					if (oldNormalImporter != ModelImporterNormals.None)
					{
						meshImporter.importNormals = oldNormalImporter;
					}
					if (oldTangentImporter != ModelImporterTangents.None)
					{
						meshImporter.importTangents = oldTangentImporter;
					}
					AssetDatabase.WriteImportSettingsIfDirty(strMeshPath);
					AssetDatabase.ImportAsset(strMeshPath);
					AssetDatabase.Refresh();
				}
			}
			//保存当前场景
			EditorSceneManager.MarkSceneDirty(activeScene);
		}
		else
		{
			if (listSRTs != null && listSRTs.Count == 1)
			{
				LODGroup cptLODGrp = go.GetComponent<LODGroup>();
				if (!cptLODGrp)
				{
					cptLODGrp = go.AddComponent<LODGroup>();
				}
				cptLODGrp.fadeMode = LODFadeMode.None;
				UnityEngine.LOD[] lods = new UnityEngine.LOD[listLODParams.Count + 1];
				Renderer[] renderersLOD0 = new Renderer[1];
				Renderer rdr = go.GetComponent<Renderer>();
				renderersLOD0[0] = rdr;
				float[] srts = listSRTs.ToArray();
				lods[0] = new UnityEngine.LOD(srts[0], renderersLOD0);
				cptLODGrp.SetLODs(lods);
				var activeScene = SceneManager.GetActiveScene();
				EditorSceneManager.MarkSceneDirty(activeScene);
			}
		}
	}

	public static void RemoveLODGroup(this GameObject go)
	{
		LODGroup cptLodGrp = go.GetComponent<LODGroup>();
		if (cptLodGrp != null)
		{
			var lods = cptLodGrp.GetLODs();
			List<GameObject> gosToDelete = new List<GameObject>();
			if (lods != null && lods.Length > 0)
			{
				foreach (var lod in lods)
				{
					var rs = lod.renderers;
					if (rs != null && rs.Length > 0)
					{
						foreach (var r in rs)
						{
							GameObject goToDel = r.gameObject;
							if (goToDel != null && goToDel != go)
							{
								if (!gosToDelete.Find(goInList => ReferenceEquals(goInList, goToDel)))
								{
									gosToDelete.Add(goToDel);
								}
							}
						}
					}
				}
			}

			foreach (var goToDel in gosToDelete)
			{
				Object.DestroyImmediate(goToDel);
			}
			Object.DestroyImmediate(cptLodGrp);


			var activeScene = SceneManager.GetActiveScene();
			EditorSceneManager.MarkSceneDirty(activeScene);
		}
	}

	public static void FindNoLODGameObjects(this GameObject go, List<GameObject> listGOs)
	{
		string strName = go.name;
		if (!strName.Contains(c_strLODName))
		{
			Renderer rdr = null;
			if (s_SearchAllRenderer)
			{
				rdr = go.GetComponent<Renderer>();
			}
			else
			{
				rdr = go.GetComponent<MeshRenderer>();
			}
			var mf = go.GetComponent<MeshFilter>();
			//MeshRenderer需要MeshFilter
			//SkinnedMeshRenderer没有MeshFilter
			bool bOK = s_SearchAllRenderer ? (rdr != null) : (rdr != null && mf != null);

			if (bOK)
			{
				bool bInLODGrp = false;
				var parentGo = go.transform.parent;
				if (parentGo != null)
				{
					LODGroup grpLOD = parentGo.GetComponent<LODGroup>();
					if (grpLOD != null)
					{
						bInLODGrp = grpLOD.HasRenderer(rdr);
					}
				}
				if (!bInLODGrp)
				{
					listGOs.Add(go);
				}
			}
		}
		foreach (Transform child in go.transform)
		{
			child.gameObject.FindNoLODGameObjects(listGOs);
		}
	}

	public static void FindLODGameObjects(this GameObject go, List<GameObject> listGOs)
	{
		Renderer rdr = null;
		if (s_SearchAllRenderer)
		{
			rdr = go.GetComponent<Renderer>();
		}
		else
		{
			rdr = go.GetComponent<MeshRenderer>();
		}
		var mf = go.GetComponent<MeshFilter>();
		bool bOk = s_SearchAllRenderer ? (rdr != null) : (rdr != null && mf != null);
		if (bOk)
		{
			LODGroup grpLOD = go.GetComponent<LODGroup>();
			if (grpLOD != null)
			{
				listGOs.Add(go);
			}
		}
		foreach (Transform child in go.transform)
		{
			child.gameObject.FindLODGameObjects(listGOs);
		}
	}

	public static void DeleteLODResources(this GameObject go, int nLODCount)
	{
		var activeScene = SceneManager.GetActiveScene();
		string strSceneName = activeScene.name;
		string strScenePath = c_strAssetsDataPath + "/" + c_strLODPath + "/" + strSceneName;
		MeshFilter mf = go.GetComponent<MeshFilter>();
		if (mf != null)
		{
			Mesh mesh = mf.sharedMesh;
			if (mesh != null)
			{
				for (int nLOD = 1; nLOD <= nLODCount; nLOD++)
				{
					string strLODMeshFileName = mesh.name + c_strLODName + nLOD.ToString() + ".asset";
					string strLODMeshFileFullPath = strScenePath + "/" + strLODMeshFileName;
					string strGUID = AssetDatabase.AssetPathToGUID(strLODMeshFileFullPath);
					if (strGUID != null && strGUID.Length > 0)
					{
						/*bool bOK = */
						AssetDatabase.DeleteAsset(strLODMeshFileFullPath);
						AssetDatabase.Refresh();
					}
				}
			}
		}
		MeshRenderer mr = go.GetComponent<MeshRenderer>();
		if (mr != null)
		{
			var mat = mr.sharedMaterial;
			if (mat != null)
			{
				string strMatFileName = mat.name + ".mat";
				string strMatFileFullPath = strScenePath + "/" + strMatFileName;
				string strGUID = AssetDatabase.AssetPathToGUID(strMatFileFullPath);
				if (strGUID != null && strGUID.Length > 0)
				{
					AssetDatabase.DeleteAsset(strMatFileFullPath);
					AssetDatabase.Refresh();
				}
			}
		}
	}

	public static bool HasRenderer(this LODGroup lodGrp, Renderer rdr)
	{
		bool bRet = false;
		var lods = lodGrp.GetLODs();
		if (lods != null && lods.Length > 0)
		{
			foreach (var lod in lods)
			{
				var rsInLod = lod.renderers;
				if (rsInLod != null && rsInLod.Length > 0)
				{
					foreach (var r in rsInLod)
					{
						if (ReferenceEquals(r, rdr))
						{
							bRet = true;
							break;
						}
					}
				}
				if (bRet)
				{
					break;
				}
			}
		}
		return bRet;
	}

	public static string ExportObjToString(this GameObject go, string strMeshName)
	{
		MeshFilter mf = go.GetComponent<MeshFilter>();
		string strRet = null;
		if (mf != null)
		{
			if (mf.sharedMesh != null)
			{
				var mesh = mf.sharedMesh;
				StringBuilder sb = new StringBuilder();

				sb.Append("#" + strMeshName + ".obj"
							+ "\n#" + System.DateTime.Now.ToLongDateString()
							+ "\n#" + System.DateTime.Now.ToLongTimeString()
							+ "\n#-------"
							+ "\n\n");

				sb.AppendFormat("g {0}\n", strMeshName);

				foreach (var v in mesh.vertices)
				{
					sb.AppendFormat("v {0} {1} {2}\n", -v.x, v.y, v.z);
				}
				sb.Append("\n");
				foreach (var n in mesh.normals)
				{
					sb.AppendFormat("vn {0} {1} {2}\n", -n.x, n.y, n.z);
				}
				sb.Append("\n");
				foreach (var uv in mesh.uv)
				{
					sb.AppendFormat("vt {0} {1}\n", uv.x, uv.y);
				}

				for (int iSubMesh = 0; iSubMesh < mesh.subMeshCount; iSubMesh++)
				{
					sb.Append("\n");

					int[] tris = mesh.GetTriangles(iSubMesh);
					for (int iTriIdx = 0; iTriIdx < tris.Length; iTriIdx += 3)
					{
						sb.AppendFormat("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n",
							tris[iTriIdx] + 1, tris[iTriIdx + 2] + 1, tris[iTriIdx + 1] + 1);
					}
				}

				strRet = sb.ToString();
			}
		}
		return strRet;
	}
}

#endif