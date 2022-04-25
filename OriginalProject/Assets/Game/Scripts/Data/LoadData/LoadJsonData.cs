using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;
using System.IO;
using LitJson;
using System.Text.RegularExpressions;
using System;

/// <summary>
/// 保留了Json加载与存档,响应式触发
/// </summary>
public class LoadJsonData
{
   //所有数据取值都用响应式触发方式
    public static LoadJsonData Instance
    {
        get
        {
            if (_instince == null)
            {
                _instince = new LoadJsonData();
                return _instince;
            }
            return _instince;
        } 
    }

    static LoadJsonData _instince;

    //[Header("以下路径为在Assets中的路径")]
    //public string jsonDataFolderPath;//Resources下的地址！！！！
    //public string assetDataFolderPath;//弃用
    public Dictionary<string, object> dic = new Dictionary<string, object>();
    Dictionary<string, object> Blist = new Dictionary<string, object>();

    //暂时不用
    public static T GetDictById<T>(int id) where T : DataBase
    {
        Dictionary<int, T> subdic = GetDict<T>();
        if (subdic != null)
        {
            if (!subdic.ContainsKey(id))
            {
                Debug.Log("不存在" + id);
                return null;
            }
            return subdic[id];
        }

        else
        {
            Debug.Log("字典为空");
            return null;
        }
    }
    //暂时不用，只能取基类为DataBase的值
    public static Dictionary<int, T> GetDict<T>() where T : DataBase
    {
        string classname = typeof(T).ToString();
        if (Instance.dic.ContainsKey(classname))
        {

            return Instance.dic[classname] as Dictionary<int, T>;
        }

        else
        {

            Dictionary<int, T> subdic = new Dictionary<int, T>();
            TextAsset obj = Resources.Load<TextAsset>( "json/" + classname);

            List<T> ls = JsonMapper.ToObject<List<T>>(obj.text);

            foreach (var i in ls)
            {
                subdic.Add(i.id, i);
            }

            Instance.dic.Add(classname, subdic);
            return subdic;
        }
    }


    /// <summary>
    /// 通过文件名称取List类型的数据，若取不到请检查/Resources/json 下文件夹名称是否一致
    /// </summary>
    /// <typeparam name="T">取值类型</typeparam>
    /// <param name="fileName">文件名</param>
    /// <returns></returns>
    public static List<T> GetList<T>(string fileName)
    {
        if (Instance.Blist.ContainsKey(fileName))
        {
            return Instance.Blist[fileName] as List<T>;
        }
        List<T> ls = new List<T>();
        TextAsset obj = Resources.Load<TextAsset>("json/" + fileName);
        ls = JsonMapper.ToObject<List<T>>(obj.text);

        Instance.Blist.Add(fileName, ls);
        return ls;
    }
    /// <summary>
    /// 通过文件名称取数据，若取不到请检查/Resources/json 下文件夹名称是否一致
    /// </summary>
    /// <typeparam name="T">取值类型</typeparam>
    /// <param name="fileName">文件名</param>
    /// <returns></returns>
    public static T GetT<T>(string fileName)
    {
        if (Instance.Blist.ContainsKey(fileName))
        {
            return (T)Instance.Blist[fileName];
        }

        TextAsset obj = Resources.Load<TextAsset>( "json/" + fileName);
        T t = JsonMapper.ToObject<T>(obj.text);

        Instance.Blist.Add(fileName, t);
        return t;
    }

    /// <summary>
    /// 将数据保存为json文件
    /// </summary>
    /// <param name="obj">要保存的对象</param>
    /// <param name="_name">要保存的名称</param>
    public static void SetJson(object obj,string _name)
    {
        string json = JsonMapper.ToJson(obj);
        //文件位置及文件名
        //File.WriteAllText("json/ModeData1.json", json.ToString());
        FileInfo file = new FileInfo(Application.dataPath + "/Game/Resources/json/" +_name + ".json");
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //转码
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        //ToJson接口将你的列表类传进去，，并自动转换为string类型
        //string Json = JsonMapper.ToJson(obj);
        //将转换好的字符串存进文件，
        json = reg.Replace(json, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        sw.WriteLine(json);
        //注意释放资源
        sw.Close();
        sw.Dispose();
    }

}
