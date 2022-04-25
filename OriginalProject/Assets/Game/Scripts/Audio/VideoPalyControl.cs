using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPalyControl : MonoSingleton<VideoPalyControl>
{
    public GameObject m_oVideo;
    public VideoPlayer m_oVideoPlayer;
    public float m_fClickTick = 0f;
    private float m_fCurTick = 0f;
    private bool m_bCanClick = false;
    private bool m_bClick = false;
    protected override void Awake()
    {
        base.Awake();
        bool bPlay = AudioManager.Instance.GetPlayOpenVideo();
        if(bPlay)
        {
            if(m_oVideo != null)
            {
                m_oVideo.SetActive(true);
                m_oVideoPlayer.Play();
                UIEventManager.AddTriggersListener(m_oVideo).onClick = (go) => {
                    OnClose();
                };
            }
        }
        else
        {
            m_bClick = true;
        }
    }

    public void Update()
    {
        if(m_bClick)
            return;

        if(m_bCanClick && m_oVideoPlayer != null && !m_oVideoPlayer.isPlaying)
        {
            OnClose();
        }

        m_fCurTick += Time.deltaTime;
        if(m_fCurTick >= m_fClickTick)
        {
            m_bCanClick = true;
        }
    }

    public void OnClose()
    {
        if(!m_bCanClick || m_bClick)
            return;

        NewbieGuideMag.Instance.startGuide();
        m_oVideo.SetActive(false);
        m_bClick = true;
        AudioManager.Instance.SetPlayOpenVideo(false);
    }
}
