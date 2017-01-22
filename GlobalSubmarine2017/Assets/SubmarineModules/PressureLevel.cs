using UnityEngine;
using System.Collections;

public class PressureLevel : AbstractSubmarineLevel {

	public NeedleMeter meter;

	float maxCooldown = 2.0f;
	float currentTimeout = 0.0f;
	float targetMeterLevel;

	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{
		if(currentTimeout <= 0.0f)
		{
			meter.level = targetMeterLevel;
			currentTimeout = Random.Range(0.0f, maxCooldown);
		}
		currentTimeout -= Time.deltaTime;
	}

	override public void UpdateDisplay ()
	{
		targetMeterLevel = level;
	}
}
