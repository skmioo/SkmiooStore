using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 插件里的一些工具函数
    /// </summary>
    public class PluginUtil
    {
        private static char[] _PathSeparators = new char[] { '/', '\\' };
        /// <summary>
        /// 使任何路径合法化
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>合法路径</returns>
        public static string ValidatePath(string path, bool autoAppendSlashIfFolder = true)
        {
            string[] parts = path.Split(_PathSeparators);
            string ret = string.Empty;
            int lastIdx = parts.Length - 1;
            while (lastIdx >= 0)
            {
                if (parts[lastIdx].Length > 0)
                {
                    break;
                }
                --lastIdx;
            }
            if (lastIdx < 0)
                return "/";
            for (int i = 0; i < lastIdx; ++i)
            {
                if (parts[i].Length > 0)
                    ret += parts[i] + "/";
            }
            string lastPart = parts[lastIdx];
            ret += lastPart;
            if (autoAppendSlashIfFolder && !IsFilePath(lastPart))
            {
                ret += "/";
            }
            return ret;
        }
        /// <summary>
        /// 将给定路径转换为windows系统上的路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>windows系统路径</returns>
        public static string AdjustAsWindowsPath(string path)
        {
            path = ValidatePath(path);
            return path.Replace('/', '\\');
        }
        /// <summary>
        /// 判断给定路径是否是一个文件路径（仅仅是根据有没有后缀来判断）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>是否是一个文件路径</returns>
        public static bool IsFilePath(string path)
        {
            int dotIdx = path.LastIndexOf('.');
            int slashIdx = path.LastIndexOf('/');
            return slashIdx < dotIdx;
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="anyPath">一个路径，或者一个带路径的文件</param>
        /// <returns>创建成功返回true</returns>
        public static bool CreateFolder(string anyPath)
        {
            string path = ValidatePath(anyPath);
            if (IsFilePath(path))
                path = SubstructParentPath(path);
            DirectoryInfo info = Directory.CreateDirectory(path);
            return info != null && info.Exists;
        }
        /// <summary>
        /// 获取给定路径的后缀
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>后缀，没有后缀返回""</returns>
        public static string GetExtention(string path)
        {
            int idx = path.LastIndexOf('.');
            if (idx == -1)
                return string.Empty;
            if (idx == path.Length - 1)
                return string.Empty;
            int slashIdx = path.LastIndexOf('/');
            if (slashIdx > idx)
                return string.Empty;
            return path.Substring(idx + 1);
        }
        /// <summary>
        /// 移除文件路径中的后缀（包括 .  ）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>纯路径</returns>
        public static string RemoveExtention(string path)
        {
            int idx = path.LastIndexOf('.');
            if (idx == -1)
                return path;
            if (idx == path.Length - 1)
                return path.Substring(0, idx);
            int slashIdx = path.LastIndexOf('/');
            if (slashIdx > idx)
                return path;
            return path.Substring(0, idx);
        }
        /// <summary>
        /// 为给定文件路径追加后缀
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="extention">后缀（不包含.）</param>
        /// <param name="replaceExist">是否替换已经存在的后缀</param>
        /// <returns>新路径</returns>
        public static string AppendExtention(string path, string extention, bool replaceExist)
        {
            if (extention[0] == '.')
            {
                extention = extention.Substring(1);
            }
            if (replaceExist)
                return RemoveExtention(path) + "." + extention;
            int idx = path.LastIndexOf('.');
            if (idx == -1)
                return path + "." + extention;
            if (idx == path.Length - 1)
                return path + extention;
            int slashIdx = path.LastIndexOf('/');
            if (slashIdx == path.Length - 1)
                return path;
            if (slashIdx > idx)
                return path + "." + extention;
            return path;
        }
        /// <summary>
        /// 移除路径的最后一个斜杠
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>移除最后一个斜杠的路径</returns>
        public static string RemoveLastSlash(string path)
        {
            if (path.Length == 0)
                return path;
            int idx = path.LastIndexOf('/');
            if (idx == path.Length - 1)
                return path.Substring(0, idx);
            return path;
        }
        /// <summary>
        /// 在路径后面加上斜杠
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>路径</returns>
        public static string AppendSlash(string path)
        {
            if (path == null || path == "")
                return "";
            int idx = path.LastIndexOf('/');
            if (idx == -1)
                return path + "/";
            if (idx == path.Length - 1)
                return path;
            return path + "/";
        }
        /// <summary>
        /// 提取路径中的纯文件名（包括后缀，如果是文件夹，提取最后的文件夹名）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件（夹）名</returns>
        public static string SubstructPureName(string path)
        {
            int idx = path.LastIndexOf('/');
            if (idx == -1)
                return path;
            if (path.Length == 1)
                return "";
            if (idx == path.Length - 1)
            {//最后一个/
                int idx2 = path.LastIndexOf('/', path.Length - 2);
                return path.Substring(idx2 + 1, idx - idx2 - 1);
            }
            return path.Substring(idx + 1);
        }
        /// <summary>
        /// 从给定路径抽取出父路径（包括最后的/）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>父路径，没有父路径就返回""</returns>
        public static string SubstructParentPath(string path)
        {
            path = RemoveLastSlash(path);
            int slashIdx = path.LastIndexOf('/');
            if (slashIdx == -1)
                return "";
            return path.Substring(0, slashIdx + 1);
        }
        /// <summary>
        /// 抽取出给定路径的第一级父路径和剩下的路径
        /// </summary>
        /// <param name="path">给定路径</param>
        /// <param name="parentPath">父路径（不包含/），如果抽取失败，返回""</param>
        /// <param name="subPath">子路径</param>
        /// <returns>抽取成功返回true</returns>
        public static bool SplitParentPath(string path, out string parentPath, out string subPath)
        {
            int slashIdx = path.IndexOf('/');
            if (slashIdx == -1)
            {
                parentPath = "";
                subPath = path;
                return false;
            }
            if (slashIdx == path.Length - 1)
            {
                parentPath = "";
                subPath = path.Substring(0, slashIdx);
                return false;
            }
            parentPath = path.Substring(0, slashIdx);
            subPath = path.Substring(slashIdx + 1);
            return true;
        }

        /// <summary>
        /// 抽取出路径名最开头的id，如果没有，返回-1
        /// </summary>
        /// <param name="path">路径名</param>
        /// <returns>id</returns>
        public static int SubstructID(string path)
        {
            string name = SubstructPureName(path);
            int numEnd = 0;
            for (; numEnd < name.Length; ++numEnd)
            {
                char c = name[numEnd];
                if (c < '0' || c > '9')
                    break;
            }
            if (numEnd == 0)
                return -1;
            return MathUtil.ParseInt(name.Substring(0, numEnd));
        }
        /// <summary>
        /// 以某种方式遍历给定的文件夹中文件
        /// </summary>
        /// <param name="files">用于返回的文件列表，可以传递null</param>
        /// <param name="folder">根文件夹</param>
        /// <param name="searchPattern">搜索模式，比如"*.xml"等</param>
        /// <param name="recursive">是否递归，默认否</param>
        /// <param name="ppath">无效参数，不要传递</param>
        /// <returns>遍历的文件列表</returns>
        public static List<string> CollectFiles(List<string> files, string folder, string searchPattern, bool recursive = false, string ppath = "")
        {
            folder = AppendSlash(folder);
            ppath = AppendSlash(ppath);
            if (files == null)
                files = new List<string>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folder);
            foreach (var file in dir.GetFiles(searchPattern))
            {
                files.Add(ppath + file.Name);
            }
            if (recursive)
            {
                foreach (var sub in dir.GetDirectories())
                {
                    files = CollectFiles(files, folder + sub.Name, searchPattern, recursive, ppath + sub.Name);
                }
            }
            return files;
        }
        /// <summary>
        /// 以某种方式遍历给定的文件夹中的子文件夹
        /// </summary>
        /// <param name="folders">用于返回的文件列表，可以传递null</param>
        /// <param name="rootFolder">根文件夹</param>
        /// <param name="recursive">是否递归，默认否</param>
        /// <param name="ppath">无效参数，不要传递</param>
        /// <returns>遍历的子文件夹</returns>
        public static List<string> CollectFolders(List<string> folders, string rootFolder, bool recursive, string ppath = "")
        {
            rootFolder = AppendSlash(rootFolder);
            ppath = AppendSlash(ppath);
            if (folders == null)
                folders = new List<string>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(rootFolder);
            foreach (var file in dir.GetDirectories())
            {
                folders.Add(ppath + file.Name);
            }
            if (recursive)
            {
                foreach (var sub in dir.GetDirectories())
                {
                    folders = CollectFolders(folders, rootFolder + sub.Name, recursive, ppath + sub.Name);
                }
            }
            return folders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ValidResFilePath(string filePath, bool ignorePath, bool ignoreExtension, bool supportWWWPath)
        {
            filePath = PluginUtil.ValidatePath(filePath, false);
#if UNITY_EDITOR
            return Path.GetFullPath(filePath);
#else
            if (ignorePath)
                filePath = PluginUtil.SubstructPureName(filePath);
            if (ignoreExtension)
                filePath = PluginUtil.RemoveExtention(filePath) + ".ab";
            string path;
            if (Application.platform == RuntimePlatform.WindowsPlayer
                || Application.platform == RuntimePlatform.WindowsEditor
                || Application.platform == RuntimePlatform.OSXEditor)
            {
                path = Path.GetFullPath(Path.Combine("./Data/ExtRes", filePath));
            }
            else
            {
                path = Path.Combine(Application.persistentDataPath + "/ExtRes", filePath);
            }
            if (File.Exists(path))
            {
                if (supportWWWPath)
                    path = "file://" + path;
            }
            else
            {
                path = Path.Combine(Application.streamingAssetsPath, filePath);
                if (Application.platform != RuntimePlatform.Android && supportWWWPath)
                {
                    path = "file://" + path;
                }
            }
            return path;
#endif
        }
    }
}
