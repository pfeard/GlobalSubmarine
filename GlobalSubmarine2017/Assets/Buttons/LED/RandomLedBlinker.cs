using UnityEngine;
using System.Collections;

public class RandomLedBlinker : MonoBehaviour {

	LEDLight[] lights;
	// Use this for initialization
	void Start () {
		lights = GetComponentsInChildren<LEDLight>();
	}
	
	// Update is called once per frame
	void Update () {
		//ToggleOneRandomLed();
	}

	public void ToggleAllLedsRandomly()
	{
		for(int i = 0; i < lights.Length; i++)
		{
			if(Random.Range(0.0f, 1.0f) > 0.4f)
			{
				lights[i].Toggle();
			}
		}
	}

	public void ToggleOneRandomLed()
	{
		lights[Random.Range(0, lights.Length)].Toggle();
	}
}
