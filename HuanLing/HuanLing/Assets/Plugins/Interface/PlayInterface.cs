using System;
using System.Collections.Generic;
using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 插件与游戏功能之间的接口
    /// </summary>
    public class PlayInterface
    {
        public delegate void InvokeCameraShakeHandler(float time, Vector3 shakeAxial, float fps = 30, float decayPow = 4);

        /// <summary>
        /// 创角帧timer
        /// </summary>
        public static Func<UYTimerHandler, int, UYTimerBase> CreateFramer;
        /// <summary>
        /// 创角定时器
        /// </summary>
        public static Func<UYTimerHandler, float, int, UYTimerBase> CreateTimer;
        /// <summary>
        /// 删除定时器
        /// </summary>
        public static Func<UYTimerBase, UYTimerBase> DestroyTimer;

        /// <summary>
        /// 克隆gameobject
        /// </summary>
        public static Func<GameObject, GameObject> InstantiateAlone;
        /// <summary>
        /// 克隆gameobject
        /// </summary>
        public static Func<GameObject, Transform, GameObject> InstantiateToParent;
        /// <summary>
        /// 克隆gameobject
        /// </summary>
        public static Func<GameObject, Vector3, Quaternion, GameObject> InstantiateToGeom;
        /// <summary>
        /// 克隆gameobject
        /// </summary>
        public static Func<string, GameObject, Transform, GameObject> InstantiateFromPool;
        /// <summary>
        /// 回收gameobject
        /// </summary>
        public static Action<GameObject> GabageToPool;

        /// <summary>
        /// 加载prefab对象
        /// </summary>
        public static Func<ResID, IGameObjResAcceptor, GameObject> FetchGameObject;
        /// <summary>
        /// 卸载prefab对象
        /// </summary>
        public static Action<ResID, IGameObjResAcceptor> UnloadGameObject;

        /// <summary>
        /// 加载sprite
        /// </summary>
        public static Func<ResID, AcceptSpriteHandler, ISpriteHandle> LoadSprite;
        /// <summary>
        /// 卸载sprite
        /// </summary>
        public static Func<ISpriteHandle, ISpriteHandle> UnloadSprite;

        public static Func<Material> GetUINormalMat;
        public static Func<Material> GetUIGrayMat;
        public static Func<Material> GetUIOverlayMat;
        public static Func<Material> GetUIAddMat;
        public static Func<Material> GetUIBlackFocusMat;

        public static Action<ResID, Action<UnityEngine.Object, ResID>, Type> LoadRes;
        public static Action<ResID, Action<UnityEngine.Object, ResID>> CancelRes;

        /// <summary>
        /// 获取已经准备好的资源
        /// </summary>
        public static Func<ResID, System.Type, UnityEngine.Object> FindPreparedRes;
        /// <summary>
        /// 在编辑器模式下直接获取资源对象
        /// </summary>
        public static Func<ResID, System.Type, UnityEngine.Object> GetResInEditor;

        /// <summary>
        /// 获取shader
        /// </summary>
        public static Func<string,Shader> FindShader;

        /// <summary>
        /// 注册全局窗口点击事件
        /// </summary>
        public static Action<Window> RegisterClickCheckWindow;
        /// <summary>
        /// 注销全局窗口点击事件
        /// </summary>
        public static Action<Window> RemoveClickCheckWindow;
        /// <summary>
        /// 显示窗口
        /// </summary>
        public static Action<Window, bool> ShowWindow;
        /// <summary>
        /// 判断当前是否需要停止帧动画
        /// </summary>
        public static Func<bool> StopYSpriteAnimation;
        public static Func<ResID, bool> CheckIsImageRes;
        public static Action<ResID> PlayUISoundAction;
        public static Func<float> GetUIScaleFactor;
        public static Func<Vector2> GetScreenSizeDelta;
        public static Func<GameObject> GetUIPoolRoot;
        public static Func<bool> CheckIsMemWarning;
        public static Func<string, GameObject, GameObject> LoadGuiObject;
        public static Func<string, Color> GetColorByName;
        public static Func<string, string, object,object>  NotifyLua;
        public static InvokeCameraShakeHandler InvokeCameraShake;
        public static Func<string, string> LanTrans;
        public static Func<SLua.LuaState> GetLuaState;

        public static bool inStory = false;
        /// <summary>
        /// 判断当前是否在运行中
        /// </summary>
        public static bool running
        {
            get { return Application.isPlaying; }
        }
        /// <summary>
        /// 判断当前是否是游戏运行中
        /// </summary>
        public static bool gameRunning
        { get; set; }

        public static bool IsImageResID(ResID id)
        {
            if (CheckIsImageRes != null)
            {
                return CheckIsImageRes(id);
            }
            else
            {
                throw new InvalidOperationException("Hasn't indicate the CheckIsImageRes func!");
            }
        }

        public static T FindPreparedResT<T>(ResID id) where T: UnityEngine.Object
        {
            return FindPreparedRes(id, typeof(T)) as T;
        }
        public static T GetResInEditorT<T>(ResID id) where T: UnityEngine.Object
        {
            return GetResInEditor(id, typeof(T)) as T;
        }


        public static void PlayUISound(ResID sound)
        {
            if (PlayUISoundAction != null)
            {
                PlayUISoundAction(sound);
            }
            else
            {
                throw new InvalidOperationException("Hasn't indicate the PlayUISoundAction!");
            }
        }

        public static GameObject uiPoolRoot
        {
            get
            {
                if (GetUIPoolRoot == null)
                {
                    throw new InvalidOperationException("Hasn't indicate the GetUIPoolRoot!");
                }
                return GetUIPoolRoot();
            }
        }

        public static float scaleFactor
        {
            get
            {
                if (GetUIScaleFactor != null)
                {
                    return GetUIScaleFactor();
                }
                else
                {
                    throw new InvalidOperationException("Hasn't indicate the GetUIScaleFactor!");
                }
            }
        }

        public static Vector2 sceneSizeDelta
        {
            get
            {
                if (GetScreenSizeDelta != null)
                {
                    return GetScreenSizeDelta();
                }
                else
                {
                    throw new InvalidOperationException("Hasn't indicate the GetUIScaleFactor!");
                }
            }
        }

        public static bool isMemWarning
        {
            get
            {
                if (CheckIsMemWarning == null)
                {
                    throw new InvalidOperationException("Hasn't indicate the CheckIsMemWarning!");
                }
                return CheckIsMemWarning();
            }
        }
    }
}
