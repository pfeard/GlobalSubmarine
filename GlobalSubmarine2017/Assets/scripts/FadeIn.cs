using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float m_FadeDuration;
    public Image m_Black;

    float m_CurrentTime;

	// Use this for initialization
	void Start ()
    {
        m_CurrentTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (m_CurrentTime < m_FadeDuration)
        {
            m_CurrentTime += Time.deltaTime;

            if (m_CurrentTime > m_FadeDuration)
            {
                m_CurrentTime = m_FadeDuration;
                m_Black.enabled = false;
            }
            else
            {
                Color col = m_Black.color;
                col.a = Mathf.Lerp(1.0f, 0.0f, m_CurrentTime / m_FadeDuration);
                m_Black.color = col;
            }
        }
	}
}
