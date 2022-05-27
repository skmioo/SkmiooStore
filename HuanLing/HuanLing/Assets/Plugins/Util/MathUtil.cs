using UnityEngine;
using System.Globalization;
using System.Collections.Generic;
using SLua;

namespace UYMO
{
    [CustomLuaClass]
    public class MathUtil
    {
        /// <summary>
        /// 游戏效果中的重力加速度
        /// </summary>
        public const float G = 42.0f;

        /// <summary>
        /// 真实的重力加速度
        /// </summary>
        public const float RealG = 10.0f;

        /// <summary>
        /// 极小值
        /// </summary>
        public const float EPS = 0.0001f;

        /// <summary>
        /// 极小值
        /// </summary>
        public const float EPS2 = EPS * 2.0f;

        /// <summary>
        /// 有符号数字间隔符号
        /// </summary>
        public static char[] _DigSpliters = new char[] { ',', ';', '_', ' ', ':', '\t', '|' };
        /// <summary>
        /// 无符号数字分隔符
        /// </summary>
        public static char[] _UDigSpliters = new char[] { ',', ';', '_', ' ', ':', '\t', '|', '-' };
        /// <summary>
        /// 有符号整数间隔符号
        /// </summary>
        public static char[] _IntegerSpliters = new char[] { ',', ';', '_', ' ', ':', '\t', '|', '.' };
        /// <summary>
        /// 无符号整数分隔符
        /// </summary>
        public static char[] _UIntegerSpliters = new char[] { ',', ';', '_', ' ', ':', '\t', '|', '-', '.' };

        /// <summary>
        /// 无效朝向
        /// </summary>
        public static Quaternion ZeroQuaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// 无效Vector3
        /// </summary>
        public static Vector3 invalidVector3 = new Vector3(float.MinValue, float.MinValue, float.MinValue);


        /// <summary>
        /// 判断给定值是否是0（接近0）
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsZero(float v)
        {
            return v > -EPS2 && v < EPS2;
        }
        public static bool LessThanZero(float v)
        {
            return v < -EPS2;
        }
        public static bool GreaterThanZero(float v)
        {
            return v < EPS2;
        }
        /// <summary>
        /// 判断给定的旋转四元数是否有效
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsDirValid(Quaternion q)
        {
            return q.x != 0.0f || q.y != 0.0f || q.z != 0.0f || q.w != 0.0f;
        }
        /// <summary>
        /// 对Vector3求整
        /// </summary>
        /// <param name="v"></param>
        public static void Round(ref Vector3 v)
        {
            v.x = Mathf.Round(v.x);
            v.y = Mathf.Round(v.y);
            v.z = Mathf.Round(v.z);
        }
        /// <summary>
        /// 解析Vector2，如果只有一个数字，解析为[x]；两个数字解析为[x, y]
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Vector2</returns>
        public static Vector2 ParseVector2(string str)
        {
            return ParseVector2(str, Vector2.zero);
        }

        /// <summary>
        /// 解析Vector2，如果只有一个数字，解析为[x]；两个数字解析为[x, y]
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Vector2</returns>
        public static Vector2 ParseVector2(string str, Vector2 defVal)
        {
            if (str == null)
                return defVal;
            string[] nums = str.Split(_DigSpliters);
            Vector2 ret = defVal;
            if (nums.Length > 0)
            {
                float.TryParse(nums[0], out ret.x);
                if (nums.Length > 1)
                {
                    float.TryParse(nums[1], out ret.y);
                }
            }
            return ret;
        }

        /// <summary>
        /// 解析Vector3，如果只有一个数字，解析为[x]；两个数字解析为[x, y]；三个数字按[x, y, z]解析
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Vector3</returns>
        public static Vector3 ParseVector3(string str)
        {
            if (str == null)
                return Vector3.zero;
            string[] nums = str.Split(_DigSpliters);
            Vector3 ret = Vector3.zero;
            if (nums.Length > 0)
            {
                float.TryParse(nums[0], out ret.x);
                if (nums.Length > 1)
                {
                    float.TryParse(nums[1], out ret.y);
                    if (nums.Length > 2)
                    {
                        float.TryParse(nums[2], out ret.z);
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// 解析欧拉角
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Vector3 ParseEuler(string str)
        {
            return ParseVector3(str);
        }
        public static Vector4 ParseVector4(string str)
        {
            if (string.IsNullOrEmpty(str))
                return Vector4.zero;
            string[] nums = str.Split(_DigSpliters);
            Vector4 vec = Vector4.zero;
            if (nums.Length > 3)
            {
                float.TryParse(nums[0], out vec.x);
                float.TryParse(nums[1], out vec.y);
                float.TryParse(nums[2], out vec.z);
                float.TryParse(nums[3], out vec.w);
            }
            return vec;
        }
        public static Vector4 ParseVector4i(string str)
        {
            if (string.IsNullOrEmpty(str))
                return Vector4.zero;
            string[] nums = str.Split(_DigSpliters);
            Vector4 vec = Vector4.zero;
            if (nums.Length > 3)
            {
                int x, y, z, w;
                int.TryParse(nums[0], out x);
                int.TryParse(nums[1], out y);
                int.TryParse(nums[2], out z);
                int.TryParse(nums[3], out w);
                vec.x = x;
                vec.y = y;
                vec.z = z;
                vec.w = w;
            }
            return vec;
        }

        /// <summary>
        /// 解析Rect
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Rect</returns>
        public static Rect ParseRect(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Rect(0, 0, 0, 0);
            float x, y, w, h;
            string[] nums = str.Split(_DigSpliters);
            if (nums.Length > 3)
            {
                if (float.TryParse(nums[0], out x)
                    && float.TryParse(nums[1], out y)
                    && float.TryParse(nums[2], out w)
                    && float.TryParse(nums[3], out h))
                {
                    return new Rect(x, y, w, h);
                }
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 解析Rect
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Rect</returns>
        public static Rect ParseRecti(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Rect(0, 0, 0, 0);
            int x, y, w, h;
            string[] nums = str.Split(_DigSpliters);
            if (nums.Length > 3)
            {
                if (int.TryParse(nums[0], out x)
                    && int.TryParse(nums[1], out y)
                    && int.TryParse(nums[2], out w)
                    && int.TryParse(nums[3], out h))
                {
                    return new Rect(x, y, w, h);
                }
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 解析Position，如果只有一个数字，解析为[x]；两个数字解析为[x, z]；三个数字按[x,z,y]解析
        /// </summary>
        /// <param name="str">待解析字符串</param>
        /// <returns>Vector3</returns>
        public static Vector3 ParsePosition(string str)
        {
            if (str == null)
                return Vector3.zero;
            string[] nums = str.Split(_DigSpliters);
            Vector3 ret = Vector3.zero;
            if (nums.Length > 0)
            {
                float.TryParse(nums[0], out ret.x);
                if (nums.Length > 1)
                {
                    float.TryParse(nums[1], out ret.z);
                    if (nums.Length > 2)
                        float.TryParse(nums[2], out ret.y);
                }
            }
            return ret;
        }
        public static Vector3 TryParsePosition(string str, Vector3 defVal)
        {
            if (str == null)
                return defVal;
            Vector3 ret = defVal;
            string[] nums = str.Split(_DigSpliters);
            if (nums.Length > 0)
            {
                float.TryParse(nums[0], out ret.x);
                if (nums.Length > 1)
                {
                    float.TryParse(nums[1], out ret.z);
                    if (nums.Length > 2)
                        float.TryParse(nums[2], out ret.y);
                }
            }
            return ret;
        }

        public static Quaternion ParseQuaternion(string str)
        {
            return ParseQuaternion(str, Quaternion.identity);
        }
        public static Quaternion ParseQuaternion(string str, Quaternion defVal)
        {
            if (str == null || str == "")
                return defVal;
            string[] nums = str.Split(_DigSpliters);
            Quaternion ret = defVal;
            if (nums.Length > 3)
            {
                float.TryParse(nums[0], out ret.x);
                float.TryParse(nums[1], out ret.y);
                float.TryParse(nums[2], out ret.z);
                float.TryParse(nums[3], out ret.w);
            }
            else
            {
                float pitch = 0.0f;
                float yaw = 0.0f;
                float roll = 0.0f;
                if (nums.Length > 0)
                    float.TryParse(nums[0], out pitch);
                if (nums.Length > 1)
                    float.TryParse(nums[1], out yaw);
                if (nums.Length > 2)
                    float.TryParse(nums[2], out roll);
                ret = Quaternion.Euler(pitch, yaw, roll);
            }
            return ret;
        }

        public static ResID ParseResID(string s)
        {
            if (s == "" || s == null)
                return ResID.zero;
            uint[] nums = MathUtil.ParseUints(s);
            int pack = nums.Length > 0 ? System.Convert.ToInt32(nums[0]) : 0;
            int grp = nums.Length > 1 ? System.Convert.ToInt32(nums[1]) : 0;
            int pic = nums.Length > 2 ? System.Convert.ToInt32(nums[2]) : 0;
            return new ResID(pack, grp, pic);
        }

        public static List<ResID> ParseResIDList(string s)
        {
            List<ResID> _ResIDArr = new List<ResID>();
            if (s == "" || s == null)
            {
                _ResIDArr.Add(ResID.zero);
                return _ResIDArr;
            }
            uint[] nums = MathUtil.ParseUints(s);
            int pack = nums.Length > 0 ? System.Convert.ToInt32(nums[0]) : 0;
            int grp = nums.Length > 1 ? System.Convert.ToInt32(nums[1]) : 0;
            int pic = nums.Length > 2 ? System.Convert.ToInt32(nums[2]) : 0;
            if (nums.Length >= 3)
            {
                for (int i = 2; i < nums.Length; i++)
                {
                    pic = System.Convert.ToInt32(nums[i]);
                    _ResIDArr.Add(new ResID(pack, grp, pic));
                }
            }
            else
            {
                _ResIDArr.Add(new ResID(pack, grp, pic));
            }
            return _ResIDArr;
        }

        /// <summary>
        /// 判断是否是零四元数
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsZeroQuaternion(Quaternion q)
        {
            return q.x == 0.0f
                && q.y == 0.0f
                && q.z == 0.0f
                && q.w == 0.0f;
        }
        public static string Recti2CfgStr(Rect rect)
        {
            return string.Format("{0} {1} {2} {3}", (int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        }
        public static string Vec4i2CfgStr(Vector4 v)
        {
            return string.Format("{0} {1} {2} {3}", (int)v.x, (int)v.y, (int)v.z, (int)v.w);
        }
        /// <summary>
        /// 将vector3转换为策划配置需要的字符串（x z y）
        /// </summary>
        /// <param name="v"></param>
        /// <param name="precise">精确度（默认小数点后两位）</param>
        /// <returns></returns>
        public static string Vec3ToCfgStr(Vector3 v, int precise = 2)
        {
            if (precise <= 0)
            {
                return string.Format("{0:0},{1:0},{2:0}", v.x, v.z, v.y);
            }
            else if (precise == 1)
            {
                return string.Format("{0:0.0},{1:0.0},{2:0.0}", v.x, v.z, v.y);
            }
            else if (precise == 2)
            {
                return string.Format("{0:0.00},{1:0.00},{2:0.00}", v.x, v.z, v.y);
            }
            else if (precise == 3)
            {
                return string.Format("{0:0.000},{1:0.000},{2:0.000}", v.x, v.z, v.y);
            }
            else
            {
                return string.Format("{0:0.0000},{1:0.0000},{2:0.0000}", v.x, v.z, v.y);
            }
        }
        public static string Vec3ToStr(Vector3 v, int precise =2)
        {
            if (precise <= 0)
            {
                return string.Format("{0:0},{1:0},{2:0}", v.x, v.y, v.z);
            }
            else if (precise == 1)
            {
                return string.Format("{0:0.0},{1:0.0},{2:0.0}", v.x, v.y, v.z);
            }
            else if (precise == 2)
            {
                return string.Format("{0:0.00},{1:0.00},{2:0.00}", v.x, v.y, v.z);
            }
            else if (precise == 3)
            {
                return string.Format("{0:0.000},{1:0.000},{2:0.000}", v.x, v.y, v.z);
            }
            else
            {
                return string.Format("{0:0.0000},{1:0.0000},{2:0.0000}", v.x, v.y, v.z);
            }
        }
        /// <summary>
        /// 欧拉角输出到配置
        /// </summary>
        /// <param name="e"></param>
        /// <param name="precise"></param>
        /// <returns></returns>
        public static string Euler2CfgStr(Vector3 e, int precise =2)
        {
            if (precise <= 0)
            {
                return string.Format("{0:0},{1:0},{2:0}", e.x, e.y, e.z);
            }
            else if (precise == 1)
            {
                return string.Format("{0:0.0},{1:0.0},{2:0.0}", e.x, e.y, e.z);
            }
            else if (precise == 2)
            {
                return string.Format("{0:0.00},{1:0.00},{2:0.00}", e.x, e.y, e.z);
            }
            else if (precise == 3)
            {
                return string.Format("{0:0.000},{1:0.000},{2:0.000}", e.x, e.y, e.z);
            }
            else
            {
                return string.Format("{0:0.0000},{1:0.0000},{2:0.0000}", e.x, e.y, e.z);
            }
        }
        /// <summary>
        /// 将vector2转换为策划配置需要的字符串（x y）
        /// </summary>
        /// <param name="v"></param>
        /// <param name="precise">精确度（默认小数点后两位）</param>
        /// <returns></returns>
        public static string Vec2ToCfgStr(Vector2 v, int precise = 2)
        {
            if (precise <= 0)
            {
                return string.Format("{0:0} {1:0}", v.x, v.y);
            }
            else if (precise == 1)
            {
                return string.Format("{0:0.0} {1:0.0}", v.x, v.y);
            }
            else if (precise == 2)
            {
                return string.Format("{0:0.00} {1:0.00}", v.x, v.y);
            }
            else if (precise == 3)
            {
                return string.Format("{0:0.000} {1:0.000}", v.x, v.y);
            }
            else
            {
                return string.Format("{0:0.0000} {1:0.0000}", v.x, v.y);
            }
        }
        public static string QuaternionToCfgStr(Quaternion val, int precise = 6)
        {
            return string.Format("{0},{1},{2},{3}", Float2CfgStr(val.x, precise), Float2CfgStr(val.y, precise), Float2CfgStr(val.z, precise), Float2CfgStr(val.w, precise));
        }
        public static string Float2CfgStr(float v, int precise = 2)
        {
            if (precise <= 0)
            {
                return string.Format("{0:0}", v);
            }
            else if (precise == 1)
            {
                return string.Format("{0:0.0}", v);
            }
            else if (precise == 2)
            {
                return string.Format("{0:0.00}", v);
            }
            else if (precise == 3)
            {
                return string.Format("{0:0.000}", v);
            }
            else
            {
                return string.Format("{0:0.0000}", v);
            }
        }
        public static float float2fix(float val, int precision)
        {
            float p = Mathf.Pow(10.0f, precision);
            return ((int)(val * p)) / p;
        }


        public static bool ParseBool(string str)
        {
            if (str == null)
                return false;
            str = str.Trim();
            str = str.ToLower();
            if (str == "" || str == "0" || str == "false")
                return false;
            return true;
        }

        public static byte ParseByte(string str)
        {
            byte ret;
            if (!byte.TryParse(str, out ret))
            {
                ret = 0;
            }
            return ret;
        }
        public static ushort ParseUShort(string str)
        {
            ushort ret;
            if(!ushort.TryParse(str, out ret))
            {
                ret = 0;
            }
            return ret;
        }
        public static int ParseInt(string str)
        {
            int ret;
            if (!int.TryParse(str, out ret))
            {
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// 解析int数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="ignoreMinus">是否忽略减号（即中划线），默认不忽略</param>
        /// <returns></returns>
        public static int[] ParseInts(string str, bool ignoreMinus = false)
        {
            if (str == null || str == "")
            {
                return new int[0];
            }
            string[] nums = str.Split(ignoreMinus ? _UIntegerSpliters : _IntegerSpliters);
            int[] ret = new int[nums.Length];
            for (int idx = 0; idx < ret.Length; ++idx)
            {
                ret[idx] = ParseInt(nums[idx]);
            }
            return ret;
        }

        /// <summary>
        /// 更智能的解析int数组，它会忽略中间的一些空白字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="ignoreMinus">是否忽略减号（即中划线），默认不忽略</param>
        /// <returns></returns>
        public static List<int> SmartParseInts(string str, bool ignoreMinus = false)
        {
            List<int> ret = new List<int>();
            if (str == null || str == "")
            {
                return ret;
            }
            string[] nums = str.Split(ignoreMinus ? _UIntegerSpliters : _IntegerSpliters);
            for (int i = 0; i < nums.Length; ++i)
            {
                var s = nums[i].Trim();
                if (s != "")
                    ret.Add(ParseInt(s));
            }
            return ret;
        }

        public static uint ParseUint(string str)
        {
            uint ret;
            uint.TryParse(str, out ret);
            return ret;
        }

        /// <summary>
        /// 解析uint数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="ignoreMinus">是否忽略减号，默认忽略</param>
        /// <returns></returns>
        public static uint[] ParseUints(string str, bool ignoreMinus = true)
        {
            if (str == null || str == "")
            {
                return new uint[0];
            }
            string[] nums = str.Split(ignoreMinus ? _UDigSpliters : _DigSpliters);
            uint[] ret = new uint[nums.Length];
            for (int idx = 0; idx < ret.Length; ++idx)
            {
                ret[idx] = ParseUint(nums[idx]);
            }
            return ret;
        }

        public static ulong ParseULong(string str)
        {
            ulong ret = 0;
            ulong.TryParse(str, out ret);
            return ret;
        }

        public static long ParseLong(string str)
        {
            long ret = 0;
            long.TryParse(str, out ret);
            return ret;
        }

        public static float ParseFloat(string str)
        {
            float ret = 0;
            float.TryParse(str, out ret);
            return ret;
        }
        public static float[] ParseFloats(string str)
        {
            if (str == null || str == "")
            {
                return new float[0];
            }
            string[] nums = str.Split(_DigSpliters);
            float[] ret = new float[nums.Length];
            for (int idx = 0; idx < ret.Length; ++idx)
            {
                ret[idx] = ParseFloat(nums[idx]);
            }
            return ret;
        }

        //传入16进制字符串，返回10进制Int
        public static int ParseHex(string str)
        {
            int ret = 0;
            var ci = new CultureInfo("zh-CN");
            int.TryParse(str, NumberStyles.HexNumber, ci, out ret);
            return ret;
        }

        public static int[] ParseHexs(string str)
        {
            var ci = new CultureInfo("zh-CN");
            if (str == null || str == "")
            {
                return new int[0];
            }
            string[] nums = str.Split(_DigSpliters);
            int[] ret = new int[nums.Length];
            for (int idx = 0; idx < ret.Length; ++idx)
            {
                ret[idx] = ParseHex(nums[idx]);
            }
            return ret;

        }

        public static Color ParseColor(string str)
        {
            Color ret = new Color();
            if (str == null || str == "")
            {
                return ret;
            }

            str = str.Replace("#", "");

            string[] nums = str.Split(_DigSpliters);

            if (nums.Length == 1 && (str.Length == 6 || str.Length == 8))
            {
                //十六进制,FFFFFF ARGB
                int[] rgba = str.Length == 6 ? new int[3] : new int[4];

                for (int idx = 0, cIdx = 0; idx < str.Length; idx += 2, ++cIdx)
                {
                    string temp = str.Substring(idx, 2);
                    rgba[cIdx] = ParseHex(temp);
                }

                if (str.Length == 6)
                {
                    ret = new Color(rgba[0] / 255.0f, rgba[1] / 255.0f, rgba[2] / 255.0f);
                }
                else
                {
                    ret = new Color(rgba[1] / 255.0f, rgba[2] / 255.0f, rgba[3] / 255.0f, rgba[0] / 255.0f);
                }
            }
            else if (nums.Length == 3)
            {
                //RGB,255,255,255
                ret = new Color(ParseFloat(nums[0]) / 255.0f, ParseFloat(nums[1]) / 255.0f, ParseFloat(nums[2]) / 255.0f);
            }
            else if (nums.Length > 3)
            {
                //RGBA,255,255,255,255
                ret = new Color(ParseFloat(nums[0]) / 255.0f, ParseFloat(nums[1]) / 255.0f, ParseFloat(nums[2]) / 255.0f, ParseFloat(nums[3]) / 255.0f);
            }

            return ret;
        }

        public static Color ParseColor(uint hexClr)
        {
            float a = (float)(hexClr >> 24 & 0xff) / 255.0f;
            float r = (float)(hexClr >> 16 & 0xff) / 255.0f;
            float g = (float)(hexClr >> 8 & 0xff) / 255.0f;
            float b = (float)(hexClr & 0xff) / 255.0f;
            return new Color(r, g, b, a);
        }
        /// <summary>
        /// 将颜色转成16进制表示的字符串  ARGB FFFFFFFF
        /// </summary>
        /// <param name="clr">颜色</param>
        public static string Color2HexStr(Color clr)
        {
            System.Func<float, string> toHex = mem =>
                {
                    string ret = System.Convert.ToString((int)(mem * 255), 16);
                    for (int idx = ret.Length; idx < 2; ++idx)
                    {
                        ret = "0" + ret;
                    }
                    return ret;
                };
            return string.Format("{0}{1}{2}{3}", toHex(clr.a), toHex(clr.r), toHex(clr.g), toHex(clr.b));
        }

        public static string Colors2HexStr(Color[] clrs)
        {
            if (clrs == null)
            {
                return "";
            }
            System.Text.StringBuilder clrStr = new System.Text.StringBuilder(clrs.Length * 9);
            for (int idx = 0; idx < clrs.Length; ++idx)
            {
                clrStr.Append(Color2HexStr(clrs[idx]));
                if (idx != clrs.Length - 1)
                {
                    clrStr.Append(',');
                }
            }
            return clrStr.ToString();
        }

        public static string Color2CfgStr(Color clr)
        {
            return string.Format("{0},{1},{2},{3}", (int)(clr.r * 255), (int)(clr.g * 255), (int)(clr.b * 255), (int)(clr.a * 255));
        }

        /// <summary>
        /// 解析多个颜色值，只支持16进制的格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Color[] ParseColors(string str)
        {
            if (str == null || str == "")
            {
                return new Color[0];
            }
            string[] hexs = str.Split(_DigSpliters);
            Color[] clrs = new Color[hexs.Length];
            for (var idx = 0; idx < clrs.Length; ++idx)
            {
                clrs[idx] = ParseColor(hexs[idx]);
            }
            return clrs;
        }

        public static long Max(long lhs, long rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        public static int Max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        public static ulong Max(ulong lhs, ulong rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        public static uint Max(uint lhs, uint rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        public static float Max(float lhs, float rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        public static double Max(double lhs, double rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }

        public static long Min(long lhs, long rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }
        public static int Min(int lhs, int rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }
        public static ulong Min(ulong lhs, ulong rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }
        public static uint Min(uint lhs, uint rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }
        public static float Min(float lhs, float rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }
        public static double Min(double lhs, double rhs)
        {
            return lhs < rhs ? lhs : rhs;
        }

        public static Vector3 Max(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                Max(v1.x, v2.x),
                Max(v1.y, v2.y),
                Max(v1.z, v2.z)
                );
        }

        public static Vector3 Min(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                Min(v1.x, v2.x),
                Min(v1.y, v2.y),
                Min(v1.z, v2.z)
                );
        }

        /// <summary>
        /// 计算期望值
        /// </summary>
        /// <param name="expVal">期望值，如果本次随机达到期望，返回true，如果期望值大于等于1，则永远返回true</param>
        /// <returns></returns>
        public static bool MakeExp(float expVal)
        {
            return MathUtil.Random(0.0f, 1.0f) < expVal;
        }

        /// <summary>
        /// 随机数，浮点
        /// </summary>
        /// <param name="min">最小范围</param>
        /// <param name="max">最大范围</param>
        /// <returns>随机数</returns>
        public static float Random(float min, float max)
        {
            return min > max ? UnityEngine.Random.Range(max, min)
                : UnityEngine.Random.Range(min, max);
        }
        /// <summary>
        /// 随机数，整型, [min, max)
        /// </summary>
        /// <param name="min">最小</param>
        /// <param name="max">最大值（但是不包含该值）</param>
        /// <returns></returns>
        public static int Random(int min, int max)
        {
            return min > max ? UnityEngine.Random.Range(max, min)
                : UnityEngine.Random.Range(min, max);
        }
        public static float ToQuadRatio(float r)
        {
            if (r < 0.0f)
                return 0.0f;
            if (r > 1.0f)
                return 1.0f;
            if (r > 0.5f)
            {
                r = 1.0f - 2.0f * (1.0f - r) * (1.0f - r);
            }
            else
            {
                r = r * r * 2.0f;
            }
            return r;
        }
        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static float Lerp(float start, float end, float ratio)
        {
            return start + (end - start) * ratio;
        }
        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static Vector3 LerpVec3(Vector3 start, Vector3 end, float ratio)
        {
            return start + (end - start) * ratio;
        }
        /// <summary>
        /// 将给定数值截取在给定范围内
        /// </summary>
        /// <param name="val"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static float Clamp(float val, float minVal, float maxVal)
        {
            return UnityEngine.Mathf.Clamp(val, minVal, maxVal);
        }

        public static ulong Clamp(ulong val, ulong minVal, ulong maxVal)
        {
            val = Max(minVal, val);
            val = Min(maxVal, val);
            return val;
        }
        [DoNotToLua]
        public static int Clamp(int val, int minVal, int maxVal)
        {
            return UnityEngine.Mathf.Clamp(val, minVal, maxVal);
        }
        [DoNotToLua]
        public static Vector3 Clamp(Vector3 val, Vector3 minVal, Vector3 maxVal)
        {
            return new Vector3(
                Clamp(val.x, minVal.x, maxVal.x),
                Clamp(val.y, minVal.y, maxVal.y),
                Clamp(val.z, minVal.z, maxVal.z)
                );
        }
        /// <summary>
        /// 极坐标转换为笛卡尔坐标（二维空间）
        /// </summary>
        /// <param name="radian">极坐标的角（弧度制）</param>
        /// <param name="radius">极坐标的半径</param>
        /// <returns>笛卡尔坐标</returns>
        public static Vector2 Polar2cartesian(float radian, float radius)
        {
            Vector2 ret;
            ret.x = Mathf.Cos(radian) * radius;
            ret.y = Mathf.Sin(radian) * radius;
            return ret;
        }
        /// <summary>
        /// 笛卡尔坐标转换为极坐标（二维空间）
        /// </summary>
        /// <param name="x">笛卡尔x坐标</param>
        /// <param name="y">笛卡尔y坐标</param>
        /// <returns>极坐标（x表示弧度角，y表示半径）</returns>
        public static Vector2 Cartesian2polar(float x, float y)
        {
            Vector2 ret;
            ret.y = Mathf.Sqrt(x * x + y * y);
            ret.x = Mathf.Atan2(y, x);
            return ret;
        }
        /// <summary>
        /// 在笛卡尔坐标系下旋转给定角度
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector2 CatesianRotate(Vector2 v, float angle)
        {
            var v1 = Cartesian2polar(v.x, v.y);
            v1.x += Mathf.Deg2Rad * angle;
            return Polar2cartesian(v1.x, v1.y);
        }
        /// <summary>
        /// 以给定点为中心随机一个位置
        /// </summary>
        /// <param name="center">给定点</param>
        /// <param name="maxRadius">离给定点最远距离</param>
        /// <param name="minRadius">离给定点最近距离（默认0）</param>
        /// <param name="startAngle">以X轴为基准的随机扇形的起始角度，默认0</param>
        /// <param name="endAngle">以X轴为基准的随机扇形的结束角度，默认360</param>
        /// <returns>随机点</returns>
        public static Vector3 RandomCenter(Vector3 center, float maxRadius, float minRadius = 0.0f, float startAngle = 0.0f, float endAngle = 360.0f)
        {
            float radian = Mathf.Deg2Rad * Random(startAngle, endAngle);
            float radius = Random(minRadius, maxRadius);
            Vector2 p2d = Polar2cartesian(radian, radius);
            return new Vector3(center.x + p2d.x, center.y, center.z + p2d.y);
        }
        /// <summary>
        /// 给定起始点和终点，在这条线上离终点一定距离范围内随机一点
        /// </summary>
        /// <param name="from">起始点</param>
        /// <param name="to">结束点</param>
        /// <param name="maxDistance">离结束点最远的距离</param>
        /// <param name="minDistance">离结束点最近的距离，默认0</param>
        /// <returns>随机点</returns>
        public static Vector3 RandomOrient(Vector3 from, Vector3 to, float maxDistance, float minDistance = 0.0f)
        {
            Vector3 dir = to - from;
            dir.Normalize();
            float distance = Random(minDistance, maxDistance);
            return to - dir * distance;
        }


        /// <summary>
        /// 确认数字value是否在num1 和num2之间
        /// </summary>
        /// <param name="value"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static bool InRange(float value, float num1, float num2)
        {
            return num1 > num2
                ? value <= num1 && value >= num2
                : value <= num2 && value >= num1;
        }
        public static bool InRange(Vector2 pt, Vector2 pt1, Vector2 pt2)
        {
            return InRange(pt.x, pt1.x, pt2.x) && InRange(pt.y, pt1.y, pt2.y);
        }
        public static Vector2 ToVec2(Vector3 val)
        {
            return new Vector2(val.x, val.z);
        }
        public static Vector3 ToVec3(Vector2 val, float y =0.0f)
        {
            return new Vector3(val.x, y, val.y);
        }
        public static void EstimateY(ref Vector3 pt, Vector3 pt1, Vector3 pt2)
        {
            float y = pt1.y;
            if (!IsZero(pt1.x -pt2.x))
            {
                y = (pt.x - pt1.x) * (pt2.y - pt1.y) / (pt2.x - pt1.x) + pt1.y;
            }
            else if (!IsZero(pt1.z -pt2.z))
            {
                y = (pt.z - pt1.z) * (pt2.y - pt1.y) / (pt2.z - pt1.z) + pt1.y;
            }
            pt.y = y;
        }
        /// <summary>
        /// 两个Vector3相乘
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 Multiply(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        }
        /// <summary>
        /// 两个vector2相乘
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector2 MultiplyV2(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x * rhs.x, lhs.y * rhs.y);
        }
        public static Vector2 DivV2(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x / rhs.x, lhs.y / rhs.y);
        }
        public static Vector3 Div(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        }
        /// <summary>
        /// 求平方
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float Square(float val)
        {
            return val * val;
        }
        /// <summary>
        /// 计算给定两点的距离的平方
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float SqrDistance(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x - rhs.x) * (lhs.x - rhs.x)
                + (lhs.y - rhs.y) * (lhs.y - rhs.y)
                + (lhs.z - rhs.z) * (lhs.z - rhs.z);
        }
        public static float SqrDistance(Vector3 offset)
        {
            return offset.x * offset.x + offset.y * offset.y + offset.z * offset.z;
        }
        /// <summary>
        /// 计算给定两点的距离平方
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float SqrDistance(Vector2 lhs, Vector2 rhs)
        {
            return (lhs - rhs).sqrMagnitude;
        }
        /// <summary>
        /// 棋盘距离
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float ChessDistance(Vector3 lhs, Vector3 rhs)
        {
            return Mathf.Abs(lhs.x - rhs.x)
                + Mathf.Abs(lhs.y - rhs.y)
                + Mathf.Abs(lhs.z - rhs.z);
        }
        /// <summary>
        /// 棋盘距离
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float ChessDistance(Vector2 lhs, Vector2 rhs)
        {
            return Mathf.Abs(lhs.x - rhs.x)
                + Mathf.Abs(lhs.y - rhs.y);
        }
        /// <summary>
        /// 棋盘距离
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float ChessDistance(Vector3 offset)
        {
            return Mathf.Abs(offset.x) + Mathf.Abs(offset.y) + Mathf.Abs(offset.z);
        }
        /// <summary>
        /// 棋盘距离
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float ChessDistance(Vector2 offset)
        {
            return Mathf.Abs(offset.x) + Mathf.Abs(offset.y);
        }
        /// <summary>
        /// 递归计算表达式中的乘/除运算
        /// </summary>
        /// <param name="numbers">表达式中的数字集合</param>
        /// <param name="operaters">操作符集合</param>
        private static void CalcMultiplyDivide(List<double> numbers, List<char> operaters)
        {
            for (int i = 0; i < operaters.Count; i++)
            {
                bool temp = false;
                double n = 0;
                if (operaters[i] == '*')
                {
                    n = numbers[i] * numbers[i + 1];
                    temp = true;
                }
                else if (operaters[i] == '/')
                {
                    n = numbers[i] / numbers[i + 1];
                    temp = true;
                }
                if (temp)
                {
                    operaters.RemoveAt(i);
                    numbers.RemoveRange(i, 2);
                    numbers.Insert(i, n);
                    CalcMultiplyDivide(numbers, operaters);
                    break;
                }
            }
        }

        /// <summary>
        /// 递归计算加减
        /// </summary> 
        /// <param name="numbers">表达式中的数字集合</param>
        /// <param name="operaters">操作符集合</param>
        /// <returns>计算的结果</returns>
        private static double CalcAddSubduction(List<double> numbers, List<char> operaters)
        {
            for (int i = 0; i < operaters.Count; i++)
            {
                bool temp = false;
                double n = 0;
                if (operaters[i] == '+')
                {
                    n = numbers[i] + numbers[i + 1];
                    temp = true;
                }
                else if (operaters[i] == '-')
                {
                    n = numbers[i] - numbers[i + 1];
                    temp = true;
                }
                if (temp)
                {
                    operaters.RemoveAt(i);
                    numbers.RemoveRange(i, 2);
                    numbers.Insert(i, n);
                    CalcAddSubduction(numbers, operaters);
                    break;
                }
            }
            double result = 0;
            if (operaters.Count == 0)
                result = numbers[0];
            return result;
        }

        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <param name="express">表达式</param>
        /// <returns>表达式结果</returns>
        public static double CalcExpress(string express)
        {
            char[] optChar = new char[] { '+', '-', '*', '/' };
            List<double> numbers = new List<double>(); //表达式中的数字
            List<char> operaters = new List<char>();   //表达式中的操作符
            string word = "";
            for (int idx = 0; idx < express.Length; idx++)
            {
                string temp = express[idx].ToString();
                if (temp.IndexOfAny(optChar) == -1)
                {
                    word += temp;
                }
                else
                {
                    numbers.Add(double.Parse(word));
                    operaters.Add(express[idx]);
                    word = "";
                }
            }
            numbers.Add(double.Parse(word));

            //开始计算
            double result = 0;
            if (operaters.Count == 0)
            {
                return double.Parse(express);
            }
            else
            {
                CalcMultiplyDivide(numbers, operaters); //计算乘除
                result = CalcAddSubduction(numbers, operaters); //计算加减
            }
            return result;
        }
        /// <summary>
        /// 计算一个点在不在球内部
        /// </summary>
        /// <param name="sphereCenter">球心</param>
        /// <param name="radius">球的半径</param>
        /// <param name="pos">一个点</param>
        /// <returns>是否在球内</returns>
        public static bool IsInSphere(Vector3 sphereCenter, float radius, Vector3 pos)
        {
            return Vector3.Distance(pos, sphereCenter) <= radius;
        }
        public static bool CheckValueChanged(float v1, float v2)
        {
            return Mathf.Abs(v1 - v2) >= 0.01f;
        }
        public static bool CheckValueChanged(Vector3 v1, Vector3 v2)
        {
            return CheckValueChanged(v1.x, v2.x)
                || CheckValueChanged(v1.y, v2.y)
                || CheckValueChanged(v1.z, v2.z);
        }
        public static bool CheckValueChanged(Quaternion v1, Quaternion v2)
        {
            return CheckValueChanged(v1.x, v2.x)
                || CheckValueChanged(v1.y, v2.y)
                || CheckValueChanged(v1.z, v2.z)
                || CheckValueChanged(v1.w, v2.w);
        }
        public static float Power2(float val)
        {
            return val * val;
        }

        [DoNotToLua]
        public static Rect Floor(Rect rect)
        {
            rect.x = Mathf.Floor(rect.x);
            rect.y = Mathf.Floor(rect.y);
            rect.width = Mathf.Floor(rect.width);
            rect.height = Mathf.Floor(rect.height);
            return rect;
        }
        [DoNotToLua]
        public static Vector2 Floor(Vector2 v)
        {
            v.x = Mathf.Floor(v.x);
            v.y = Mathf.Floor(v.y);
            return v;
        }
        [DoNotToLua]
        public static Vector3 Floor(Vector3 v)
        {
            v.x = Mathf.Floor(v.x);
            v.y = Mathf.Floor(v.y);
            v.z = Mathf.Floor(v.z);
            return v;
        }

        /// <summary>
        /// 线段和圆的交点
        /// </summary>
        /// <param name="segPt0">线段端点1</param>
        /// <param name="segPt1">线段端点2</param>
        /// <param name="center">圆心</param>
        /// <param name="radius">半径</param>
        /// <param name="intersectPt">返回：交点</param>
        /// <returns>是否有交点</returns>
        public static bool SegmentIntersectRound(Vector2 segPt0, Vector2 segPt1, Vector2 center, float radius, out Vector2 intersectPt)
        {
            Vector2 intersectPt2;
            int count = LineIntersectRound(segPt0, segPt1, center, radius, out intersectPt, out intersectPt2);
            if (count == 0)
            {//无交点
                return false;
            }
            if (MathUtil.InRange(intersectPt, segPt0, segPt1))
            {//第一个点符合
                return true;
            }
            if (MathUtil.InRange(intersectPt2, segPt0, segPt1))
            {//第二个点符合
                intersectPt = intersectPt2;
                return true;
            }
            //不符合
            return false;
        }

        /// <summary>
        /// 直线与圆的交点
        /// </summary>
        /// <param name="linePt0">定义直线的点1</param>
        /// <param name="linePt1">定义直线的点2</param>
        /// <param name="center">圆心</param>
        /// <param name="radius">圆半径</param>
        /// <param name="intersectPt0">返回：交点1</param>
        /// <param name="intersectPt1">返回：交点2</param>
        /// <returns>交点数目：0表示无交点，1表示相切（一个交点），2表示两个交点</returns>
        public static int LineIntersectRound(Vector2 linePt0, Vector2 linePt1, Vector2 center, float radius, out Vector2 intersectPt0, out Vector2 intersectPt1)
        {
            int intersectCount = 0;
            intersectPt0 = linePt0;
            intersectPt1 = linePt0;
            Vector2 D = linePt1 - linePt0;
            D.Normalize();
            Vector2 P = linePt0 - center;
            float dot = D.DotProduct(P);
            float thetaSqr = Power2(dot) - (P.sqrMagnitude - Power2(radius));
            if (thetaSqr < 0.0f)
            {//小于0，无交点
                return intersectCount;
            }
            float theta = Mathf.Sqrt(thetaSqr);
            float t0 = -dot - theta;
            float t1 = -dot + theta;
            intersectPt0 = P + t0 * D;
            if (IsZero(thetaSqr))
            {
                intersectPt1 = intersectPt0;
                intersectCount = 1;
            }
            else
            {
                intersectPt1 = P + t1 * D;
                intersectCount = 2;
            }
            intersectPt0 += center;
            intersectPt1 += center;
            return intersectCount;
        }
    }
}
