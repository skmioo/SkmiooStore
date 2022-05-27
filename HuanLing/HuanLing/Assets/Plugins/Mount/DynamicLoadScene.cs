#if open_sub_scene
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UYMO
{
    public class DynamicLoadScene : MonoBehaviour
    {
        /// <summary>
        /// 开启动态场景加载
        /// </summary>
        public static bool OpenDynScene = true;
        /// <summary>
        /// 立马加载所有子场景
        /// </summary>
        public static bool loadAllSubSceneAtOnce = false;

        /// <summary>
        /// 加载子场景是否忽略内存警告
        /// </summary>
        public static bool s_IgnoreMemoryWarning = true;

        /// <summary>
        /// 加载的场景名字
        /// </summary>
        public string levelName;

        /// <summary>
        /// 距离中心点距离 开始加载
        /// </summary>
        public float loadDist;

        /// <summary>
        /// 是否必须加载
        /// </summary>
        public bool mustLoad;

        public static GameObject sSubSceneEnter;

        //静态场景物件
        private List<ShowQuality> _SubSceneStaticObject = new List<ShowQuality>();

        private Vector3 pos;
        private AsyncOperation subSceneAsyncOp = null;
        private GameObject _SceneRoot = null;
        private string _SubSceneABName = "";
        private bool _Loaded = false;
        private bool _Request = false;
        private float _LoadedTime = 0;
        //所属的场景名字
        private string _SceneName = null;
        //跨场景是否清除
        private bool _DestroyLoadLevel = false;

        /// <summary>
        /// 保留最少多长时间 10s
        /// </summary>
        private float _LifeTime = 10;

        private float _UnloadDist = 0;

        /// <summary>
        /// 由于切换后加载的子场景必须强制删除
        /// </summary>
        private bool _ForceDelete = false;

        public string sceneABName
        {
            get { return _SubSceneABName; }
        }

        /// <summary>
        /// 调整显示
        /// </summary>
        /// <param name="qualityLvl"></param>
        public void AdjustSceneStaticQuality(int qualityLvl)
        {
            for (int idx = 0; idx < _SubSceneStaticObject.Count; idx++)
            {
                bool vis = _SubSceneStaticObject[idx].qualityLvl <= qualityLvl;
                Renderer[] renderers = _SubSceneStaticObject[idx].gameObject.GetComponents<Renderer>();
                if (renderers != null)
                {
                    for (int jdx = 0; jdx < renderers.Length; jdx++)
                    {
                        renderers[jdx].enabled = vis;
                    }
                }
            }
        }

        /// <summary>
        /// 立马加载场景
        /// </summary>
        public void LoadAtOnce()
        {
            if (!_Request)
            {
                ClearStaticObjectQualityCom();
                _SubSceneStaticObject.Clear();
                if (subSceneAsyncOp == null)
                {
#if LOAD_FROM_RESOURCES && UNITY_EDITOR
                    subSceneAsyncOp = Application.LoadLevelAdditiveAsync(levelName);
#else
                    _SubSceneABName = PlayInterface.abMgr.LoadSubSceneAssetBundle(levelName, OnLoadSceneABComplete);
                    if(_SubSceneABName == null)
                    {//没有场景的ab包，直接尝试加载
                        subSceneAsyncOp = Application.LoadLevelAdditiveAsync(levelName);
                    }
#endif
                    //若开始加载子场景，则将这个置为不可销毁，以防还没加载完就跳了场景
                    _SceneName = Application.loadedLevelName;
                    _DestroyLoadLevel = false;
                }
                _Request = true;
            }
        }

        void Awake()
        {
            pos = transform.position;
            _UnloadDist = loadDist + 20;
        }
        void Start()
        {
            if (sSubSceneEnter == null)
            {
                sSubSceneEnter = new GameObject("DynmicSubSceneRoot");
                U3DUtil.DontDestroyOnLoad(sSubSceneEnter);
            }
            gameObject.transform.SetParent(sSubSceneEnter.transform);
            U3DUtil.DontDestroyOnLoad(gameObject);
            _DestroyLoadLevel = true;
        }

        void OnLevelWasLoaded(int level)
        {//Awake => OnLevelWasLoaded => Start
            if (_DestroyLoadLevel)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            if (_ForceDelete)
            {
                Destroy(gameObject);
                return;
            }

            if (loadAllSubSceneAtOnce)
            {
                if (!_Loaded)
                {
                    if (subSceneAsyncOp != null && subSceneAsyncOp.isDone)
                    {
                        _SceneRoot = GameObject.Find(levelName);
                        _Loaded = true;
                        _LoadedTime = Time.time;
                        LoadSceneStaticObject();
                    }
                }
            }
            else
            {
                ///剧情状态不进行动态场景的处理
                if (PlayInterface.inStory || !OpenDynScene)
                    return;

                if (!_Loaded)
                {
                    if (s_IgnoreMemoryWarning || !PlayInterface.isMemWarning || mustLoad)
                    {
                        float dist = Vector3.Distance(PlayInterface.playerPos, pos);
                        if (dist <= loadDist)
                        {
                            if (!_Request)
                            {
                                //Debug.LogFormat("请求加载子场景：{0}",levelName);
                                ClearStaticObjectQualityCom();
                                _SubSceneStaticObject.Clear();
                                if (subSceneAsyncOp == null)
                                {
#if LOAD_FROM_RESOURCES && UNITY_EDITOR
                                    subSceneAsyncOp = Application.LoadLevelAdditiveAsync(levelName);
#else
                                    _SubSceneABName = PlayInterface.abMgr.LoadSubSceneAssetBundle(levelName, OnLoadSceneABComplete);
                                    if (_SubSceneABName == null)
                                    {//没有场景的ab包，直接尝试加载
                                        subSceneAsyncOp = Application.LoadLevelAdditiveAsync(levelName);
                                    }
#endif
                                    //若开始加载子场景，则将这个置为不可销毁，以防还没加载完就跳了场景
                                    _SceneName = Application.loadedLevelName;
                                    _DestroyLoadLevel = false;
                                }
                                _Request = true;
                            }
                        }
                    }


                    if (subSceneAsyncOp != null && subSceneAsyncOp.isDone)
                    {
                        _SceneRoot = GameObject.Find(levelName);
                        _Loaded = true;
                        _LoadedTime = Time.time;
                        LoadSceneStaticObject();
                        _DestroyLoadLevel = true;

#if LOAD_FROM_RESOURCES && UNITY_EDITOR
                        //
#else
                        PlayInterface.abMgr.UnloadSubSceneAssetBundle(levelName,false);
#endif
                        if (_SceneName != Application.loadedLevelName)
                        {//已经换场景了
                            Unload();
                            _ForceDelete = true;
                        }
                    }
                }
                else
                {
                    float dist = Vector3.Distance(PlayInterface.playerPos, pos);
                    if (dist > _UnloadDist)
                    {
                        float passTime = Time.time - _LoadedTime;
                        if (passTime >= _LifeTime)
                        {
                            Unload();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 卸载
        /// </summary>
        public void Unload()
        {
            if (subSceneAsyncOp != null && subSceneAsyncOp.isDone)
            {
                UnloadScene();
            }
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (!PlayInterface.gameRunning)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, loadDist);
            }
        }
#endif

        private void UnloadScene()
        {
            ClearStaticObjectQualityCom();
            if (_SceneRoot != null)
            {
                GameObject.Destroy(_SceneRoot);
                _SceneRoot = null;
            }
            else
            {
#if LOAD_FROM_RESOURCES && UNITY_EDITOR
                Application.UnloadLevel(levelName);
#else
                PlayInterface.abMgr.UnloadSubSceneAssetBundle(levelName,true);
#endif
            }

            subSceneAsyncOp = null;
            _Loaded = false;
            _Request = false;
        }

        /// <summary>
        /// 场景ab准备ok
        /// </summary>
        /// <param name="ab"></param>
        private void OnLoadSceneABComplete(AssetBundle ab)
        {
            if (ab != null)
            {
                subSceneAsyncOp = Application.LoadLevelAdditiveAsync(levelName);
            }
        }

        /// <summary>
        /// 加载子场景中的静态物件
        /// </summary>
        private void LoadSceneStaticObject()
        {
            if (_SceneRoot != null)
            {
                PrefabLightmapData prefabLightmapData = _SceneRoot.GetComponent<PrefabLightmapData>();
                if (prefabLightmapData != null)
                {
                    prefabLightmapData.SetUpLightmap();
                }

                ShowQuality[] children = _SceneRoot.GetComponentsInChildren<ShowQuality>();
                if (children != null && children.Length > 0)
                {
                    for (int idx = 0; idx < children.Length; idx++)
                    {
                        _SubSceneStaticObject.Add(children[idx]);
                    }
                }
            }
        }


        /// <summary>
        /// 清理
        /// </summary>
        private void ClearStaticObjectQualityCom()
        {
            for (int idx = 0; idx < _SubSceneStaticObject.Count; idx++)
            {
                if (_SubSceneStaticObject[idx] != null)
                    GameObject.Destroy(_SubSceneStaticObject[idx].gameObject);
                _SubSceneStaticObject[idx] = null;
            }
            _SubSceneStaticObject.Clear();
        }
    }
}
#endif
