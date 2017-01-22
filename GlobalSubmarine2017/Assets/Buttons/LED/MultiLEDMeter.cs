using UnityEngine;
using System.Collections;

public class MultiLEDMeter : MonoBehaviour {

	public float _level; //0->1
	public float level{
		get { return _level; }
		set
		{
			_level = Mathf.Clamp01(value);
			UpdateLevels();
		}
	}

	LEDMeter[] meters;

	float noiseOffset = 0.0f;
	public float noiseSpeed;

	// Use this for initialization
	void Start () {
		meters = GetComponentsInChildren<LEDMeter>();
	}

	void Update()
	{
		noiseOffset += Time.deltaTime * noiseSpeed;
		UpdateLevels();
	}

	void UpdateLevels () {
		for(int i = 0; i < meters.Length; i++)
		{
			float meterLevel = Mathf.PerlinNoise(i*10, noiseOffset) * level;

			if(level > 0.80)
			{
				meterLevel += 0.3f;
			}

			meters[i].level = Mathf.Clamp01(meterLevel);
		}
	}
}
