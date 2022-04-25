using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Excel;
using System.IO;
using System.Data;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace LexYan.Tools 
{
	/// <summary>
	/// 专门用于读取excel内的数据，然后存储为特定的资源对象.
	/// 方便在游戏中直接加载。
	/// 
	/// Author:绝世爱笑
	/// Date:2020-11-17
	/// </summary>
	public class ReadExcelData : Editor
	{
        /*
		//public static Datas.RoleDataSet roleDateSet = new Datas.RoleDataSet();

		[MenuItem("Tools/ReadExcelData/读取所有数据(未完成)")]
		public static void ReadExcelAllSheet() 
		{

		}

        #region 读取角色表

        [MenuItem("Tools/ReadExcelData/读取角色表")]
		public static void ReadExcelHero()
		{
			//01 打开并加载整个文件
			string path = Application.dataPath + "/GameAssembly/ExcelTools/ExcelFiles/基础架构.xlsx";
			Debug.Log(path);
			FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet resultData = excelReader.AsDataSet();

			ReadSheetData_RoleTable(resultData, "角色表");

			excelReader.Close();
			stream.Close();
		}
        
		/// <summary>
		/// 读取角色表的数据
		/// </summary>
		public static void ReadSheetData_RoleTable(DataSet resultData, string sheetName)
		{
			Datas.RoleDataSet roleDateSet = ScriptableObject.CreateInstance<Datas.RoleDataSet>();

			// 获取表格有多少列
			int columns = resultData.Tables[sheetName].Columns.Count;
			// 获取表格有多少行
			int rows = resultData.Tables[sheetName].Rows.Count;
			// 每个sheet表内 数据开始的行位置不一样
			int i = GetDataRowBeginIndexBySheetName(sheetName);

			// 根据行列依次打印表格中的每个数据 并存入数据容器内
			for (; i < rows; i++)
			{
				//跳过无用的数据
				string tmp = resultData.Tables[sheetName].Rows[i][1].ToString();
				if (string.IsNullOrEmpty(tmp) || tmp == "1009")
				{
					continue;
				}

				//先跳过通用那一行


				//先读取其他的基本数据
				Datas.RoleLifeData roleLifeData = new Datas.RoleLifeData();
				roleLifeData.size = int.Parse(resultData.Tables[sheetName].Rows[i][4].ToString());//角色体积
				string haveSkillKeys = resultData.Tables[sheetName].Rows[i][5].ToString();//角色拥有技能
				roleLifeData.roundCOunt = int.Parse(resultData.Tables[sheetName].Rows[i][6].ToString());//单回合行动点
				roleLifeData.posSkill = resultData.Tables[sheetName].Rows[i][8].ToString();//换位技能
				roleLifeData.hp = int.Parse(resultData.Tables[sheetName].Rows[i][10].ToString());//最大HP
				string maxMstring = resultData.Tables[sheetName].Rows[i][12].ToString();
				string minMstring = resultData.Tables[sheetName].Rows[i][13].ToString();
				if (!string.IsNullOrEmpty(maxMstring) && maxMstring!="null") 
				{
					roleLifeData.maxMorale = int.Parse(maxMstring);//最大士气值
				}
				if (!string.IsNullOrEmpty(minMstring) && minMstring != "null")
				{
					roleLifeData.minMorale = int.Parse(minMstring);//最小士气值
				}
				string tmpInjuries = resultData.Tables[sheetName].Rows[i][15].ToString();//伤势上限字符串,怪物的为null
				if (!string.IsNullOrEmpty(tmpInjuries) && tmpInjuries != "null")
				{
					roleLifeData.maxInjuries = int.Parse(tmpInjuries);
				}
				roleLifeData.defence = int.Parse(resultData.Tables[sheetName].Rows[i][16].ToString());//减伤百分比 就是防御啦
				string[] attackValueArray = resultData.Tables[sheetName].Rows[i][17].ToString().Replace("[", "").Replace("]", "").Split(',');//攻击力
				roleLifeData.minAtk = int.Parse(attackValueArray[0]);//最小攻击力
				roleLifeData.maxAtk = int.Parse(attackValueArray[1]);//最大攻击力
				roleLifeData.dodge = int.Parse(resultData.Tables[sheetName].Rows[i][18].ToString());//闪避
				roleLifeData.crits = int.Parse(resultData.Tables[sheetName].Rows[i][19].ToString());//暴击率
				roleLifeData.rate = int.Parse(resultData.Tables[sheetName].Rows[i][20].ToString());//精准
				roleLifeData.speed = int.Parse(resultData.Tables[sheetName].Rows[i][21].ToString());//速度
				roleLifeData.bleed = int.Parse(resultData.Tables[sheetName].Rows[i][22].ToString());//流血
				roleLifeData.poison = int.Parse(resultData.Tables[sheetName].Rows[i][23].ToString());//中毒
				roleLifeData.debuff = int.Parse(resultData.Tables[sheetName].Rows[i][24].ToString());//减益
				roleLifeData.vertigo = int.Parse(resultData.Tables[sheetName].Rows[i][25].ToString());//眩晕
				roleLifeData.position = int.Parse(resultData.Tables[sheetName].Rows[i][26].ToString());//位移
				string deathString = resultData.Tables[sheetName].Rows[i][27].ToString();//死亡抗性，怪物没有
				if (!string.IsNullOrEmpty(deathString) && deathString != "null")
				{
					roleLifeData.death = int.Parse(deathString);//死亡
				}

				//再读取角色数据，并判断是否英雄还是怪物

				string roleTypeString = resultData.Tables[sheetName].Rows[i][3].ToString();//角色类型字符串
				string roleVocationTypeString = resultData.Tables[sheetName].Rows[i][2].ToString();
				Debug.Log(roleVocationTypeString);
				if (roleTypeString == "hero")
				{
					Datas.HeroData heroData = new Datas.HeroData();
					heroData.roleType = RoleType.Hero;
					heroData.RoleHaveSkill = GetSkillListByString(haveSkillKeys);
					heroData.name = roleVocationTypeString;//暂时也给一个名字好了
					heroData.vocation = (HeroVocation)Enum.Parse(typeof(HeroVocation), roleVocationTypeString);//角色职业（如果是怪物的话，则是名称）
					heroData.id = int.Parse(resultData.Tables[sheetName].Rows[i][1].ToString());//excel 里是有0001这样的数据

					heroData.roleLife = roleLifeData;

					roleDateSet.heroData.Add(heroData);
				}
				else if (roleTypeString =="monster" || roleTypeString == "boss") 
				{
					Datas.EnemyData enemyData = new Datas.EnemyData();

					enemyData.roleType = RoleType.Enemy;
					enemyData.RoleHaveSkill = GetSkillListByString(haveSkillKeys);
					enemyData.name = roleVocationTypeString;//因为这里是怪物，所以就是名称
					enemyData.id = int.Parse(resultData.Tables[sheetName].Rows[i][1].ToString());//excel 里是有0001这样的数据

					enemyData.roleLife = roleLifeData;

					roleDateSet.enemyData.Add(enemyData);
				}
			}

			//转化为asset的资源文件
			AssetDatabase.CreateAsset(roleDateSet, "Assets/GameAssembly/ExcelTools/ExcelDataObj/RoleDateSet.asset");
			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
		}
        
		public static List<int> GetSkillListByString(string keys) 
		{
			List<int> list = new List<int>();
			if (!string.IsNullOrEmpty(keys))
			{
				string[] keyArray = keys.Split('|');
				foreach (string key in keyArray)
				{
					int tmp = int.Parse(key);
					list.Add(tmp);
				}
			}
			return list;
		}


		#endregion

		#region 读取技能表

		[MenuItem("Tools/ReadExcelData/读取技能表")]
		public static void ReadExcelSkill()
		{
			//01 打开并加载整个文件
			string path = Application.dataPath + "/GameAssembly/ExcelTools/ExcelFiles/基础架构.xlsx";
			Debug.Log(path);
			FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			DataSet resultData = excelReader.AsDataSet();

			ReadSheetData_Skill(resultData, "技能表");

			excelReader.Close();
			stream.Close();
		}


		/// <summary>
		/// 中间临时存放数据的变量
		/// </summary>
		public static AssetReferenceSprite tmp;

		/// <summary>
		/// 读取技能表数据
		/// </summary>
		public static void ReadSheetData_Skill(DataSet resultData, string sheetName)
		{
			Addressables.InitializeAsync();
			Datas.SkillDataSet skillDateSet = ScriptableObject.CreateInstance<Datas.SkillDataSet>();

			// 获取表格有多少列
			int columns = resultData.Tables[sheetName].Columns.Count;
			// 获取表格有多少行
			int rows = resultData.Tables[sheetName].Rows.Count;
			// 每个sheet表内 数据开始的行位置不一样
			int i = GetDataRowBeginIndexBySheetName(sheetName);

			// 根据行列依次打印表格中的每个数据 并存入数据容器内
			//暂时只处理到42行
			for (; i <= 42; i++)
			{
				//跳过无用数据
				if (string.IsNullOrEmpty(resultData.Tables[sheetName].Rows[i][1].ToString())) 
				{
					continue;
				}

				Debug.Log(resultData.Tables[sheetName].Rows[i][5].ToString());

				Datas.SkillData skillData = new Datas.SkillData();
				skillData.id = int.Parse(resultData.Tables[sheetName].Rows[i][1].ToString());//技能ID
				skillData.roleID = int.Parse(resultData.Tables[sheetName].Rows[i][2].ToString());//技能关联的角色ID
				//string skillTypeStringEX = resultData.Tables[sheetName].Rows[i][3].ToString();//用于区分士气技能和普通技能
				string skillTypeString = resultData.Tables[sheetName].Rows[i][3].ToString();//技能类型
				if (skillTypeString == "近战") { skillTypeString = "近战伤害"; }
				if (skillTypeString == "远程") { skillTypeString = "远程伤害"; }
				if (skillTypeString == "buff") { skillTypeString = "BUFF"; }
				skillData.skillType = (SkillType)Enum.Parse(typeof(SkillType), skillTypeString);
				skillData.name = resultData.Tables[sheetName].Rows[i][4].ToString();//技能名称
				skillData.tips = resultData.Tables[sheetName].Rows[i][5].ToString();//技能注语
				skillData.describe = resultData.Tables[sheetName].Rows[i][6].ToString();//技能描述

				//处理图片icon,目前只限制在英雄的技能里。
				string basePath = Application.dataPath + "/Art/AddressbleArt/Icon/J_Skill/英雄技能/";
				string skillIconString = resultData.Tables[sheetName].Rows[i][7].ToString();
				string assetPath = GetHeroSkillIconByPath(basePath, skillIconString);
				skillData.iconPath = assetPath;
				//if (!string.IsNullOrEmpty(assetPath)) 
				//{
				//	skillData.icon = Addressables.LoadAssetAsync<AssetReferenceSprite>(assetPath).Result;
				//}

				skillData.skillForm = resultData.Tables[sheetName].Rows[i][8].ToString();//技能可用形态
				string battleingLimitString = resultData.Tables[sheetName].Rows[i][9].ToString();//战斗可用次数
				if (battleingLimitString == "infi")
				{
					skillData.battleingLimit = 0;
				} else if (battleingLimitString == "null") 
				{
					skillData.battleingLimit = -9999;
				}
				else
				{
					skillData.battleingLimit = int.Parse(battleingLimitString);
				}
				skillData.cd = int.Parse(resultData.Tables[sheetName].Rows[i][10].ToString());//冷却回合数
				skillData.targetCount = int.Parse(resultData.Tables[sheetName].Rows[i][11].ToString());//目标数量
				string targetTypeString = resultData.Tables[sheetName].Rows[i][12].ToString();//目标类型
				targetTypeString = targetTypeString.Replace("（", "_").Replace("）", "");
				skillData.targetType = (SkillTargetType)Enum.Parse(typeof(SkillTargetType), targetTypeString);

				//技能的释放位置数据
				string posString = resultData.Tables[sheetName].Rows[i][13].ToString();//技能释放位置数据
				if (posString.Length == 8)
				{
					char[] charArray = posString.ToCharArray();
					Datas.SkillPosition position = new Datas.SkillPosition();
					int d = int.Parse(charArray[0].ToString());
					int c = int.Parse(charArray[1].ToString());
					int b = int.Parse(charArray[2].ToString());
					int a = int.Parse(charArray[3].ToString());
					int w = int.Parse(charArray[4].ToString());
					int x = int.Parse(charArray[5].ToString());
					int y = int.Parse(charArray[6].ToString());
					int z = int.Parse(charArray[7].ToString());
					position.D = d == 1 ? true : false;
					position.C = c == 1 ? true : false;
					position.B = b == 1 ? true : false;
					position.A = a == 1 ? true : false;
					position.W = w == 1 ? true : false;
					position.X = x == 1 ? true : false;
					position.Y = y == 1 ? true : false;
					position.Z = z == 1 ? true : false;
					skillData.position = position;
				}
				else 
				{
					Debug.LogError("技能释放位置数据 长度不为8！");
				}
				//按等级来的数据
				skillData.rate = GetIntLevelDataByString(resultData.Tables[sheetName].Rows[i][14].ToString());//精准修正
				skillData.atk = GetIntLevelDataByString(resultData.Tables[sheetName].Rows[i][15].ToString());//伤害修正
				skillData.crits = GetIntLevelDataByString(resultData.Tables[sheetName].Rows[i][16].ToString());//暴击修正
				skillData.minCureHP = GetIntLevelDataByString(resultData.Tables[sheetName].Rows[i][17].ToString());//最小回复
				skillData.maxCureHP = GetIntLevelDataByString(resultData.Tables[sheetName].Rows[i][18].ToString());//最大回复

				//接下来是最复杂的了
				string tailString = resultData.Tables[sheetName].Rows[i][19].ToString();//尾巴值
				string effectString = resultData.Tables[sheetName].Rows[i][20].ToString();//效果值

				//解析尾巴效果
				skillData.skillTails = DoAnalysisTailstring(tailString);

				//解析技能效果
				skillData.skillBuffs = DoAnalysisEffectstring(effectString);

				//if (skillTypeStringEX == "普通技能")
				//{
				skillDateSet.heroSkills.Add(skillData);
				//} 
				//else if (skillTypeStringEX == "士气技能") 
				//{
				//	skillDateSet.otherSkills.Add((Datas.OtherSkillData)skillData);
				//}
			}
			//转化为asset的资源文件
			AssetDatabase.CreateAsset(skillDateSet, "Assets/GameAssembly/ExcelTools/ExcelDataObj/SkillDateSet.asset");
			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
		}

		/// <summary>
		/// 通过excel里配置的路径，加载图片
		/// </summary>
		/// <param name="basePath"></param>
		/// <param name="pathFromExcel"></param>
		/// <returns></returns>
		public static string GetHeroSkillIconByPath(string basePath,string pathFromExcel)
		{
			pathFromExcel = pathFromExcel.Replace("：", ":");
			string[] pathNodeArray = pathFromExcel.Split(':')[1].Split('_');
			string finalPath = basePath + pathNodeArray[0] + "/" + pathNodeArray[1] + ".png";
			//Debug.Log("SkillIcon Path:"+ finalPath);
			if (File.Exists(finalPath))
			{
				int tIndex = finalPath.IndexOf("Assets");
				return finalPath.Substring(tIndex,finalPath.Length-tIndex);
			}
			else 
			{
				Debug.LogError(pathFromExcel + " 文件不存在！");
			}
			return null;
		}

		public IEnumerator LoadSprteFile(string path, Datas.SkillData skilldata)
		{
			
			AsyncOperationHandle<AssetReferenceSprite> handle = Addressables.LoadAssetAsync<AssetReferenceSprite>(path);
			yield return handle;
			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				skilldata.icon = handle.Result;
				Addressables.Release(handle);
			}
		}

		/// <summary>
		/// 解析传入的trailstring
		/// </summary>
		/// <param name="trailString"></param>
		public static List<Datas.TailValue> DoAnalysisTailstring(string trailString)
		{
			List<Datas.TailValue> traiList = new List<Datas.TailValue>();

			//00 检测数据
			if (!string.IsNullOrEmpty(trailString)&& trailString!="null")
			{
				//01 一组{}就是一个效果。先分组吧
				string[] tmpArray = trailString.Split('}');
				foreach (string tdata in tmpArray) 
				{
					//因为最后末尾应该有一个“”字符串
					if (tdata.Length>0) 
					{
						//再次分割
						string[] typeArray = tdata.Split('|');

						foreach (string typestr in typeArray) 
						{
							SkillBuffTarget tmpTarget = SkillBuffTarget.目标;
							//开始分类别处理 
							//0A 处理目标
							if (typestr.StartsWith("target")) 
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex,typestr.Length-splitIndex);
								if (valuestr == "m")
								{
									tmpTarget = SkillBuffTarget.自身;
								}
								else if (valuestr == "t") 
								{
									tmpTarget = SkillBuffTarget.目标;
								}
							}
							//0B 处理valus 值的数据也可能有多个
							if (typestr.StartsWith("values")) 
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);
								//考虑到有多个值的情况，还得再次按照[]来分割
								string[] array = valuestr.Split(']');
								foreach (string tv in array) 
								{
									if (tv.Length>0) 
									{
										Datas.TailValue traiValue = new Datas.TailValue();

										string[] ntvArray = tv.Replace("[","").Split(':');
										traiValue.tailType = GetSkillTailTypeByString(ntvArray[0]);
										traiValue.Value = GetIntLevelDataByString(ntvArray[1]);
										traiValue.buffTarget = tmpTarget;

										traiList.Add(traiValue);
									}
								}
							}
						}
					}
				}
			}

			return traiList;
		}

		/// <summary>
		/// 解析传入的trailstring
		/// </summary>
		/// <param name="trailString"></param>
		public static List<Datas.SkillBuff> DoAnalysisEffectstring(string effectString)
		{
			List<Datas.SkillBuff> skillBuffList = new List<Datas.SkillBuff>();

			//00 检测数据
			if (!string.IsNullOrEmpty(effectString) && effectString != "null")
			{
				//01 一组{}就是一个效果。先分组吧
				string[] tmpArray = effectString.Split('}');
				foreach (string tdata in tmpArray)
				{
					//因为最后末尾应该有一个“”字符串
					if (tdata.Length > 0)
					{
						//再次分割
						string[] typeArray = tdata.Split('|');
						Datas.SkillBuff skillbuff = new Datas.SkillBuff();
						skillbuff.buffValues = new List<Datas.BuffValue>();

						foreach (string typestr in typeArray)
						{
							//开始分类别处理 
							//0A 处理目标
							if (typestr.StartsWith("target"))
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);
								SkillBuffTarget tmpTarget = SkillBuffTarget.目标;
								if (valuestr == "m")
								{
									tmpTarget = SkillBuffTarget.自身;
								}
								else if (valuestr == "t")
								{
									tmpTarget = SkillBuffTarget.目标;
								}
								skillbuff.buffTarget = tmpTarget;
							}
							//0B 处理round
							if (typestr.StartsWith("round"))
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);

								skillbuff.effectiveRounds = int.Parse(valuestr);
							}
							//0C 处理type
							if (typestr.StartsWith("type"))
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);
								//属于特殊的效果code 暂时没法对应上枚举类型
								skillbuff.buffCode = valuestr;

							}
							//0D 处理rate 命中率
							if (typestr.StartsWith("rate"))
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);

								Datas.IntLevel rateLevel = GetIntLevelDataByString(valuestr);
								skillbuff.rate = rateLevel;
							}
							//0E 处理valus 值的数据也可能有多个
							if (typestr.StartsWith("value"))
							{
								int splitIndex = typestr.IndexOf(":") + 1;
								string valuestr = typestr.Substring(splitIndex, typestr.Length - splitIndex);
								if (valuestr!="[]")
								{
									//考虑到有多个值的情况，还得再次按照[]来分割
									string[] array = valuestr.Split(']');
									foreach (string tv in array)
									{
										if (tv.Length > 0)
										{
											Datas.BuffValue buffValue = new Datas.BuffValue();

											string[] ntvArray = tv.Replace("[", "").Split(':');
											if (ntvArray.Length != 2)
											{
												Debug.LogError("数据结构错误：" + tv + " 缺少部分数据！");
												continue;
											}
											buffValue.statusType = GetSkillStatusTypeByString(ntvArray[0]);

											//接下来处理数据，还得看看开头是A!还是B!  A!是加减 B!是系数
											if (ntvArray[1].StartsWith("A!"))
											{
												buffValue.valueType = ValueType.系数;
												string tmp = ntvArray[1].Replace("A!", "");
												buffValue.value = GetIntLevelDataByString(tmp);
											}
											else if (ntvArray[1].StartsWith("B!"))
											{
												buffValue.valueType = ValueType.加减;
												string tmp = ntvArray[1].Replace("B!", "");
												buffValue.value = GetIntLevelDataByString(tmp);
											}
											else
											{
												buffValue.valueType = ValueType.加减;
												buffValue.value = GetIntLevelDataByString(ntvArray[1]);
											}

											skillbuff.buffValues.Add(buffValue);
										}
									}
								}
							}
						}

						skillBuffList.Add(skillbuff);
					}
				}
			}

			return skillBuffList;
		}


		/// <summary>
		/// 临时写死3个字符串对应的状态
		/// </summary>
		/// <param name="stringValue"></param>
		/// <returns></returns>
		public static SkillTailType GetSkillTailTypeByString(string stringValue) 
		{
			switch (stringValue) 
			{
				case "dp":
					return SkillTailType.位移;
				case "mp":
					return SkillTailType.士气;
				case "ip":
					return SkillTailType.伤势;
				default://随便写个默认值
					return SkillTailType.回复生命;
			}
		}

		/// <summary>
		/// 根据策划的简写code 返回 对应的枚举类型
		/// </summary>
		/// <param name="stringValue"></param>
		/// <returns></returns>
		public static SkillStatusTpye GetSkillStatusTypeByString(string stringValue) 
		{
			switch (stringValue) 
			{
				case "hp":
					return SkillStatusTpye.回复生命;
				case "at":
					return SkillStatusTpye.攻击;
				case "do":
					return SkillStatusTpye.闪避;
				case "cr":
					return SkillStatusTpye.暴击;
				case "ac":
					return SkillStatusTpye.精准;
				case "sp":
					return SkillStatusTpye.速度;
				case "ir":
					return SkillStatusTpye.减伤;
				case "mp":
					return SkillStatusTpye.士气;
				case "ip":
					return SkillStatusTpye.伤势;
				case "dp":
					return SkillStatusTpye.位置;
				case "blr":
					return SkillStatusTpye.流血抗性;
				case "por":
					return SkillStatusTpye.中毒抗性;
				case "der":
					return SkillStatusTpye.减益抗性;
				case "ver":
					return SkillStatusTpye.眩晕抗性;
				case "dir":
					return SkillStatusTpye.位移抗性;
				case "dhr":
					return SkillStatusTpye.死亡抗性;
				default://随便写个返回值
					Debug.LogError("SkillStatusTpye:"+ stringValue + " 未定义类型！");
					return SkillStatusTpye.中毒抗性;
			}
		}

		/// <summary>
		/// 从传入的字符串开头拆分1组{}的字符串出来，如果返回为null或者""，表示为没数据了
		/// 同时传入的字符串长度也会被裁断掉
		/// </summary>
		/// <param name="dataString"></param>
		/// <returns></returns>
		public static string GetOneEffectString(ref string dataString)
		{
			if (!string.IsNullOrEmpty(dataString)) 
			{
				int firstLeftIndex = dataString.IndexOf('{');
				int firstRightIndex = dataString.IndexOf('}');
				if (firstLeftIndex >= 0 && firstRightIndex > 0)
				{
					string tmpData = dataString.Substring(firstLeftIndex,firstRightIndex-firstLeftIndex);
					dataString = dataString.Replace(tmpData,"");//偷懒，直接替换掉

					return tmpData;
				}
				else 
				{
					Debug.LogError("数据格式异常："+dataString);
					return null;
				}
			}
			return null;
		}

		#endregion

		/// <summary>
		/// 每个sheet表内 数据开始的行位置不一样
		/// 所以根据每个sheetName来单独配置一下
		/// </summary>
		/// <returns></returns>
		public static int GetDataRowBeginIndexBySheetName(string sheetName)
		{
			int index = 0;
			if ("角色表" == sheetName)
			{
				index = 5;
			}
			else if ("技能表" == sheetName)
			{
				index = 5;
			}
			return index;
		}

		/// <summary>
		/// 通过传入string参数，返回对应的floatLevel对象
		/// </summary>
		/// <param name="floatString"></param>
		/// <returns></returns>
		public static Datas.FloatLevel GetFloatLevelDataByString(string floatString) 
		{
			if (string.IsNullOrEmpty(floatString) || floatString=="null") 
			{
				return null;
			}

			Datas.FloatLevel floatLevel = new Datas.FloatLevel();
			if (floatString.IndexOf("/") > 0)
			{
				string[] array = floatString.Split('/');
				if (array.Length != 5)
				{
					Debug.LogError("FloatLevel数据异常:" + floatString + "  缺少部分参数");
				}
				else 
				{
					floatLevel.level1 = float.Parse(array[0]) / 100f;
					floatLevel.level2 = float.Parse(array[1]) / 100f;
					floatLevel.level3 = float.Parse(array[2]) / 100f;
					floatLevel.level4 = float.Parse(array[3]) / 100f;
					floatLevel.level5 = float.Parse(array[4]) / 100f;
				}
			}
			else 
			{
				//如果有可以转换为int的数字 那就是5个等级全部都是相同数值
				if (int.TryParse(floatString, out int result))
				{
					floatLevel.level1 = result / 100f;
					floatLevel.level2 = result / 100f;
					floatLevel.level3 = result / 100f;
					floatLevel.level4 = result / 100f;
					floatLevel.level5 = result / 100f;
				}
			}
			return floatLevel;
		}

		/// <summary>
		/// 通过传入string参数，返回对应的floatLevel对象
		/// </summary>
		/// <param name="floatString"></param>
		/// <returns></returns>
		public static Datas.IntLevel GetIntLevelDataByString(string intString)
		{
			if (string.IsNullOrEmpty(intString) || intString=="null") 
			{
				return null;
			}

			Datas.IntLevel intLevel = new Datas.IntLevel();
			if (intString.IndexOf("/") > 0)
			{
				string[] array = intString.Split('/');
				if (array.Length != 5)
				{
					Debug.LogError("IntLevel数据异常:" + intString + "  缺少部分参数");
				}
				else
				{
					intLevel.level1 = int.Parse(array[0]);
					intLevel.level2 = int.Parse(array[1]);
					intLevel.level3 = int.Parse(array[2]);
					intLevel.level4 = int.Parse(array[3]);
					intLevel.level5 = int.Parse(array[4]);
				}
			}
			else
			{
				//如果有可以转换为int的数字 那就是5个等级全部都是相同数值
				if (int.TryParse(intString, out int result))
				{
					intLevel.level1 = result;
					intLevel.level2 = result;
					intLevel.level3 = result;
					intLevel.level4 = result;
					intLevel.level5 = result;
				}
			}
			return intLevel;
		}
        */
	}
}

