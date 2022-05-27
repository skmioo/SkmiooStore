using UnityEngine;
using System.Collections;

public class AnimationSpriteSheet : MonoBehaviour {

    public float m_FPS = 24.0f;
    public float m_uvX = 4;
    public float m_uvY = 2;
    Vector2 m_vecSize = new Vector2();
    Vector2 m_vecOffset = new Vector2();

    Renderer m_renderComponent;
	// Use this for initialization
	void Start () {
        m_renderComponent = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        int Index = (int)(Time.time * m_FPS);
        Index = Index % ((int)m_uvX * (int)m_uvY);

        m_vecSize.x = 1.0f / m_uvX;
        m_vecSize.y = 1.0f / m_uvY;

		int uIndex = Index % (int)m_uvX;
		int vIndex = Index / (int)m_uvX;

        m_vecOffset.x = uIndex * m_vecSize.x;
        m_vecOffset.y = 1.0f - m_vecSize.y - vIndex * m_vecSize.y;

        if (m_renderComponent != null)
        {
            m_renderComponent.material.SetTextureOffset("_MainTex", m_vecOffset);
            m_renderComponent.material.SetTextureScale("_MainTex", m_vecSize);
        }
        

	}
}
