using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

////后续Compute Shader优化 把计算放到GPU direct X11上 
public class Script_Eleven_Water_Wave : MonoBehaviour
{
	public int waveWidth = 128;
	public int waveHeigth = 128;

	float[,] waveA;
	float[,] waveB;
	//水波半径
	int radius = 8;
	Texture2D tex_uv;
	bool isComputeWave = true;

	Color[] colorBuffer;
	
	// Start is called before the first frame update
	void Start()
    {
		waveA = new float[waveWidth, waveHeigth];
		waveB = new float[waveWidth, waveHeigth];
		tex_uv = new Texture2D(waveWidth, waveHeigth);
		colorBuffer = new Color[waveWidth * waveHeigth];
		GetComponent<Renderer>().material.SetTexture("_WaveTex", tex_uv);
		Thread th = new  Thread(new ThreadStart(ComputeWave));
		th.Start();
	}

    // Update is called once per frame
    void Update()
    {
		sleepTime = (int)(Time.deltaTime * 1000);
		tex_uv.SetPixels(colorBuffer);
		tex_uv.Apply();
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.name == transform.name)
				{
					//Debug.Log(hit.point);
					Vector3 pos = transform.worldToLocalMatrix.MultiplyPoint(hit.point);
					Debug.Log(pos);
					//-0.5~0.5 => 0~128
					Putpop((int)((pos.x + 0.5) * waveWidth) - 1, (int)((pos.y + 0.5) * waveHeigth) - 1, 1.0f);
				}
			}
		}

    }

	private void OnEnable()
	{
		isComputeWave = true;
	}

	private void OnDisable()
	{
		isComputeWave = false;
	}

	private void OnDestroy()
	{
		isComputeWave = false;
	}

	/// <summary>
	/// 扔石子
	/// </summary>
	void Putpop(int x, int y ,float height)
	{
		
		float dist;
		for (int i = -radius; i < radius; i++)
		{
			for (int j = -radius; j < radius; j++)
			{
				if ((x + i >= 0) && (x + i < waveWidth - 1) && (y + j >= 0) && (y + j < waveHeigth - 1))
				{
					dist = Mathf.Sqrt(i * i + j * j);
					if (dist < radius)
						waveA[x + i, y + j] = Mathf.Cos((dist / radius) * Mathf.PI ) * height;
				}
			}
		}

	}
	int sleepTime;
	/// <summary>
	/// 计算波
	/// </summary>
	void ComputeWave()
	{
		while (isComputeWave)
		{
			for (int h = 1; h < waveHeigth - 1; h++)
			{
				for (int w = 1; w < waveWidth - 1; w++)
				{
					waveB[w, h] = (waveA[w - 1, h - 1] + waveA[w - 1, h] + waveA[w - 1, h + 1]
								+ waveA[w, h - 1] + waveA[w, h + 1]
								+ waveA[w + 1, h - 1] + waveA[w + 1, h] + waveA[w + 1, h + 1]) * 0.25f
								- waveB[w, h];
					float value = waveB[w, h];
					waveB[w, h] = Mathf.Clamp(waveB[w, h], -1, 1);

					//范围-1~1
					float offset_u = (waveB[w - 1, h] - waveB[w + 1, h]) * 0.5f;
					float offset_v = (waveB[w, h - 1] - waveB[w, h + 1]) * 0.5f;
					//压缩到0~1，并存储到texture中
					//红色通道
					float r = offset_u * 0.5f + 0.5f;
					//绿色通道
					float g = offset_v * 0.5f + 0.5f;
					//tex_uv.SetPixel(w, h, new Color(r, g, 0));
					colorBuffer[w + waveWidth * h] = new Color(r, g, 0);
					//衰减到0
					waveB[w, h] -= waveB[w, h] * 0.0025f;
				}
			}

			//tex_uv.Apply();

			//数组引用交换
			float[,] tmp = waveA;
			waveA = waveB;
			waveB = tmp;

			Thread.Sleep(sleepTime);
		}
		
	}

}
