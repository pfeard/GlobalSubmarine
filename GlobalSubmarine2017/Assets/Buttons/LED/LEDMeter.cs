using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LEDMeter : MonoBehaviour {

	public float _level; //0->1
	public bool reversed;
	public float level{
		get { return _level; }
		set
		{
			_level = value;
			UpdateDisplay();
		}
	}

	LEDLight[] lights;


	// Use this for initialization
	void Start () {
		lights = GetComponentsInChildren<LEDLight>();
	}

	void Update()
	{
	}

	public void SetRandomLevel()
	{
		level = Random.Range(0.0f, 1.0f);
	}

	void UpdateDisplay () {

		int limit = Mathf.RoundToInt(level * lights.Length);

		for(int i = 0; i < lights.Length; i++)
		{
			int index = reversed?lights.Length-1-i:i;
			if(i <= limit)
			{
				lights[index].isOn = true;
			} else 
			{
				lights[index].isOn = false;
			}
		}
	}
}
