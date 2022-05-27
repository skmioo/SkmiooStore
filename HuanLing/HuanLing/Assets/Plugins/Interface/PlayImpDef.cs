using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UYMO
{
    /// <summary>
    /// 接受sprite的回调函数
    /// </summary>
    /// <param name="spriteHandle">sprite的句柄，保证不为null</param>
    public delegate void AcceptSpriteHandler(ISpriteHandle spriteHandle);

    /// <summary>
    /// 一个sprite句柄
    /// </summary>
    public interface ISpriteHandle
    {
        /// <summary>
        /// 资源id
        /// </summary>
        ResID id { get; }
        /// <summary>
        /// 是否已经准备好（即使加载失败也认为已经准备妥当）
        /// </summary>
        bool ready { get; }
        /// <summary>
        /// 是否有效（注意，有些时候，sprite可能是null，也认为有效）
        /// </summary>
        bool valid { get; }
        /// <summary>
        /// sprite
        /// </summary>
        Sprite sprite { get; }
        /// <summary>
        /// 纹理是否与其它sprite共享
        /// </summary>
        bool textureShared { get; }
        /// <summary>
        /// 普通材质
        /// </summary>
        Material normalMat { get; }
        /// <summary>
        /// 灰度材质
        /// </summary>
        Material grayMat { get; }
        /// <summary>
        /// 叠加材质
        /// </summary>
        Material overlayMat { get; }
        /// <summary>
        /// add材质
        /// </summary>
        Material addMat { get; }
        /// <summary>
        /// 回调函数
        /// </summary>
        AcceptSpriteHandler callback { get; }
    }

    /// <summary>
    /// GameObject资源接收者
    /// </summary>
    public interface IGameObjResAcceptor
    {
        /// <summary>
        /// 接受资源的处理
        /// </summary>
        /// <param name="res">资源对象，null表示加载失败</param>
        /// <param name="id">资源id</param>
        void AcceptGameObjRes(GameObject res, ResID id);
    }
    /// <summary>
    /// 一个适配器
    /// </summary>
    public class GameObjResAdapter : IGameObjResAcceptor
    {
        public delegate void GOCallback(GameObject obj, ResID id);

        private static Stack<GameObjResAdapter> s_pool = new Stack<GameObjResAdapter>();
        public static GameObjResAdapter Fetch(ResID id, GOCallback callback)
        {
            GameObjResAdapter go = s_pool.Count == 0 ? new GameObjResAdapter() : s_pool.Pop();
            go._Callback = callback;
            go._ResID = id;
            PlayInterface.FetchGameObject(id, go);
            return go;
        }
        public static GameObjResAdapter Gabage(GameObjResAdapter go)
        {
            if (go != null)
            {
                PlayInterface.UnloadGameObject(go._ResID, go);
                go._Callback = null;
                if (s_pool.Count < 10)
                    s_pool.Push(go);
            }
            return null;
        }

        private ResID _ResID;
        private GOCallback _Callback;
        private GameObjResAdapter()
        {
        }
        public ResID resID
        {
            get { return _ResID; }
        }
        public void AcceptGameObjRes(GameObject res, ResID id)
        {
            if (_Callback != null)
                _Callback(res, id);
        }
    }
}
