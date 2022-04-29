﻿using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class GaussianBlur : MonoBehaviour
{
    #region Variables  
    [SerializeField]
    private Shader gaussianBlurShader = null;
    private Material BlurBoxMaterial = null;

    [Range(0.0f, 1.0f)]
    public float fBlurSize = 0f;
    #endregion

    #region Properties  

    Material material
    {
        get
        {
            if (BlurBoxMaterial == null)
            {
                BlurBoxMaterial = new Material(gaussianBlurShader);
                BlurBoxMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return BlurBoxMaterial;
        }
    }
    #endregion

    void OnEnable()
    {
        //高度适配
        rate = Screen.height / 512f;
        // Disable if we don't support image effects  
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }

        // Disable the image effect if the shader can't  
        // run on the users graphics card  
        if (!gaussianBlurShader || !gaussianBlurShader.isSupported)
            enabled = false;
        return;
    }

    private float rate = 2;
    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {

        if (fBlurSize != 0 && gaussianBlurShader != null)
        {
            int rtW = (int)(sourceTexture.width / rate);
            int rtH = (int)(sourceTexture.height / rate);


            RenderTexture rtTempA = RenderTexture.GetTemporary(rtW, rtH, 0, sourceTexture.format);
            rtTempA.filterMode = FilterMode.Bilinear;


            Graphics.Blit(sourceTexture, rtTempA);

            for (int i = 0; i < 2; i++)
            {
                // float iteraionOffs = i * 1.0f;
                material.SetFloat("_blurSize", fBlurSize);

                //vertical blur  
                RenderTexture rtTempB = RenderTexture.GetTemporary(rtW, rtH, 0, sourceTexture.format);
                rtTempB.filterMode = FilterMode.Bilinear;
                Graphics.Blit(rtTempA, rtTempB, material, 0);
                RenderTexture.ReleaseTemporary(rtTempA);
                rtTempA = rtTempB;

                //horizontal blur  
                rtTempB = RenderTexture.GetTemporary(rtW, rtH, 0, sourceTexture.format);
                rtTempB.filterMode = FilterMode.Bilinear;
                Graphics.Blit(rtTempA, rtTempB, material, 1);
                RenderTexture.ReleaseTemporary(rtTempA);
                rtTempA = rtTempB;

            }
            Graphics.Blit(rtTempA, destTexture);

            RenderTexture.ReleaseTemporary(rtTempA);
        }

        else
        {
            Graphics.Blit(sourceTexture, destTexture);

        }

    }

#if UNITY_EDITOR
    // Update is called once per frame  
    void Update()
    {
        rate = Screen.height / 512f;
    }
#endif

    public void OnDisable()
    {
        if (BlurBoxMaterial)
            DestroyImmediate(BlurBoxMaterial);
    }
}