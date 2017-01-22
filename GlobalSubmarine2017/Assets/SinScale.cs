using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinScale : MonoBehaviour
{
    public float m_Speed = 1.0f;
    public float m_MinScale = 0.5f;
    public float m_MaxScale = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float scale = (Mathf.Sin(Time.realtimeSinceStartup * m_Speed * Mathf.PI) + 1.0f) / 2.0f;
        scale *= (m_MaxScale - m_MinScale);
        scale += m_MinScale;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
	}
}
