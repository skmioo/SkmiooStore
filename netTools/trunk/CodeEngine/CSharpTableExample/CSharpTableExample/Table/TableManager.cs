//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;
 using System.Xml;

namespace GCGame.Table{

public interface ITableOperate
 {
 IEnumerator LoadTable(Hashtable _tab);
 string GetInstanceFile();
 }

 public delegate void SerializableTable(ArrayList valuesList, string skey, Hashtable _hash);
 
[Serializable]
 public class TableManager
{
 public static bool ReaderPList(String xmlFile, SerializableTable _fun, Hashtable _hash)
 {
 XmlDocument xml = new XmlDocument();
 xml.Load(xmlFile);
 XmlNode rootNode = xml.SelectSingleNode("plist");
 if (rootNode == null) return false;
 rootNode = rootNode.SelectSingleNode("dict");
 if (rootNode == null) return false;
 XmlNodeList xnl = rootNode.ChildNodes;
 foreach (XmlNode xnf in xnl)
 {
 string skey = "";
 if (xnf.Name == "key")
 {
 skey = xnf.InnerText;
 }
 if (string.IsNullOrEmpty(skey)) return false;
 ArrayList valuesList = new ArrayList();
 XmlNode skeys = xnf.NextSibling;
 XmlNodeList subList = skeys.ChildNodes;
 foreach (XmlNode values in subList)
 {
 valuesList.Add(values.InnerText);
 }
 _fun(valuesList, skey, _hash);
 }
 return true;
 }


public static Hashtable g_AniId = new Hashtable();

public static Hashtable g_BuildingCooldown = new Hashtable();

public static Hashtable g_BuildingFunction = new Hashtable();

public static Hashtable g_BuildingPrice = new Hashtable();

public static Hashtable g_BuildingRule = new Hashtable();

public static Hashtable g_Captain = new Hashtable();

public static Hashtable g_CaptainAvtarId = new Hashtable();

public static Hashtable g_CaptainExp = new Hashtable();

public static Hashtable g_CaptainPos = new Hashtable();

public static Hashtable g_CaptainPrice = new Hashtable();

public static Hashtable g_CaptainUpgraderPercent = new Hashtable();

public static Hashtable g_ClockRule = new Hashtable();

public static Hashtable g_GroupEnemy = new Hashtable();

public static Hashtable g_ItemPrice = new Hashtable();

public static Hashtable g_ItemRule = new Hashtable();

public static Hashtable g_ItemUpgraderPercent = new Hashtable();

public static Hashtable g_Ship = new Hashtable();

public static Hashtable g_ShipPrice = new Hashtable();

public static Hashtable g_ShipUpgraderPercent = new Hashtable();

public static Hashtable g_SingleEnemy = new Hashtable();

public static Hashtable g_SkillBase = new Hashtable();

public static Hashtable g_StoryMap = new Hashtable();

public IEnumerator InitTable()
 {
 yield return new Tab_AniId().LoadTable(g_AniId);
yield return new Tab_BuildingCooldown().LoadTable(g_BuildingCooldown);
yield return new Tab_BuildingFunction().LoadTable(g_BuildingFunction);
yield return new Tab_BuildingPrice().LoadTable(g_BuildingPrice);
yield return new Tab_BuildingRule().LoadTable(g_BuildingRule);
yield return new Tab_Captain().LoadTable(g_Captain);
yield return new Tab_CaptainAvtarId().LoadTable(g_CaptainAvtarId);
yield return new Tab_CaptainExp().LoadTable(g_CaptainExp);
yield return new Tab_CaptainPos().LoadTable(g_CaptainPos);
yield return new Tab_CaptainPrice().LoadTable(g_CaptainPrice);
yield return new Tab_CaptainUpgraderPercent().LoadTable(g_CaptainUpgraderPercent);
yield return new Tab_ClockRule().LoadTable(g_ClockRule);
yield return new Tab_GroupEnemy().LoadTable(g_GroupEnemy);
yield return new Tab_ItemPrice().LoadTable(g_ItemPrice);
yield return new Tab_ItemRule().LoadTable(g_ItemRule);
yield return new Tab_ItemUpgraderPercent().LoadTable(g_ItemUpgraderPercent);
yield return new Tab_Ship().LoadTable(g_Ship);
yield return new Tab_ShipPrice().LoadTable(g_ShipPrice);
yield return new Tab_ShipUpgraderPercent().LoadTable(g_ShipUpgraderPercent);
yield return new Tab_SingleEnemy().LoadTable(g_SingleEnemy);
yield return new Tab_SkillBase().LoadTable(g_SkillBase);
yield return new Tab_StoryMap().LoadTable(g_StoryMap);

 }

public static Tab_AniId GetAniIdByID(int nIdex)
 {
 if( g_AniId.ContainsKey(nIdex))
 {
 return g_AniId[nIdex] as Tab_AniId;
 }
 return null;
 }

public static Tab_BuildingCooldown GetBuildingCooldownByID(int nIdex)
 {
 if( g_BuildingCooldown.ContainsKey(nIdex))
 {
 return g_BuildingCooldown[nIdex] as Tab_BuildingCooldown;
 }
 return null;
 }

public static Tab_BuildingFunction GetBuildingFunctionByID(int nIdex)
 {
 if( g_BuildingFunction.ContainsKey(nIdex))
 {
 return g_BuildingFunction[nIdex] as Tab_BuildingFunction;
 }
 return null;
 }

public static Tab_BuildingPrice GetBuildingPriceByID(int nIdex)
 {
 if( g_BuildingPrice.ContainsKey(nIdex))
 {
 return g_BuildingPrice[nIdex] as Tab_BuildingPrice;
 }
 return null;
 }

public static Tab_BuildingRule GetBuildingRuleByID(int nIdex)
 {
 if( g_BuildingRule.ContainsKey(nIdex))
 {
 return g_BuildingRule[nIdex] as Tab_BuildingRule;
 }
 return null;
 }

public static Tab_Captain GetCaptainByID(int nIdex)
 {
 if( g_Captain.ContainsKey(nIdex))
 {
 return g_Captain[nIdex] as Tab_Captain;
 }
 return null;
 }

public static Tab_CaptainAvtarId GetCaptainAvtarIdByID(int nIdex)
 {
 if( g_CaptainAvtarId.ContainsKey(nIdex))
 {
 return g_CaptainAvtarId[nIdex] as Tab_CaptainAvtarId;
 }
 return null;
 }

public static Tab_CaptainExp GetCaptainExpByID(int nIdex)
 {
 if( g_CaptainExp.ContainsKey(nIdex))
 {
 return g_CaptainExp[nIdex] as Tab_CaptainExp;
 }
 return null;
 }

public static Tab_CaptainPos GetCaptainPosByID(int nIdex)
 {
 if( g_CaptainPos.ContainsKey(nIdex))
 {
 return g_CaptainPos[nIdex] as Tab_CaptainPos;
 }
 return null;
 }

public static Tab_CaptainPrice GetCaptainPriceByID(int nIdex)
 {
 if( g_CaptainPrice.ContainsKey(nIdex))
 {
 return g_CaptainPrice[nIdex] as Tab_CaptainPrice;
 }
 return null;
 }

public static Tab_CaptainUpgraderPercent GetCaptainUpgraderPercentByID(int nIdex)
 {
 if( g_CaptainUpgraderPercent.ContainsKey(nIdex))
 {
 return g_CaptainUpgraderPercent[nIdex] as Tab_CaptainUpgraderPercent;
 }
 return null;
 }

public static Tab_ClockRule GetClockRuleByID(int nIdex)
 {
 if( g_ClockRule.ContainsKey(nIdex))
 {
 return g_ClockRule[nIdex] as Tab_ClockRule;
 }
 return null;
 }

public static Tab_GroupEnemy GetGroupEnemyByID(int nIdex)
 {
 if( g_GroupEnemy.ContainsKey(nIdex))
 {
 return g_GroupEnemy[nIdex] as Tab_GroupEnemy;
 }
 return null;
 }

public static Tab_ItemPrice GetItemPriceByID(int nIdex)
 {
 if( g_ItemPrice.ContainsKey(nIdex))
 {
 return g_ItemPrice[nIdex] as Tab_ItemPrice;
 }
 return null;
 }

public static Tab_ItemRule GetItemRuleByID(int nIdex)
 {
 if( g_ItemRule.ContainsKey(nIdex))
 {
 return g_ItemRule[nIdex] as Tab_ItemRule;
 }
 return null;
 }

public static Tab_ItemUpgraderPercent GetItemUpgraderPercentByID(int nIdex)
 {
 if( g_ItemUpgraderPercent.ContainsKey(nIdex))
 {
 return g_ItemUpgraderPercent[nIdex] as Tab_ItemUpgraderPercent;
 }
 return null;
 }

public static Tab_Ship GetShipByID(int nIdex)
 {
 if( g_Ship.ContainsKey(nIdex))
 {
 return g_Ship[nIdex] as Tab_Ship;
 }
 return null;
 }

public static Tab_ShipPrice GetShipPriceByID(int nIdex)
 {
 if( g_ShipPrice.ContainsKey(nIdex))
 {
 return g_ShipPrice[nIdex] as Tab_ShipPrice;
 }
 return null;
 }

public static Tab_ShipUpgraderPercent GetShipUpgraderPercentByID(int nIdex)
 {
 if( g_ShipUpgraderPercent.ContainsKey(nIdex))
 {
 return g_ShipUpgraderPercent[nIdex] as Tab_ShipUpgraderPercent;
 }
 return null;
 }

public static Tab_SingleEnemy GetSingleEnemyByID(int nIdex)
 {
 if( g_SingleEnemy.ContainsKey(nIdex))
 {
 return g_SingleEnemy[nIdex] as Tab_SingleEnemy;
 }
 return null;
 }

public static Tab_SkillBase GetSkillBaseByID(int nIdex)
 {
 if( g_SkillBase.ContainsKey(nIdex))
 {
 return g_SkillBase[nIdex] as Tab_SkillBase;
 }
 return null;
 }

public static Tab_StoryMap GetStoryMapByID(int nIdex)
 {
 if( g_StoryMap.ContainsKey(nIdex))
 {
 return g_StoryMap[nIdex] as Tab_StoryMap;
 }
 return null;
 }


}
}

