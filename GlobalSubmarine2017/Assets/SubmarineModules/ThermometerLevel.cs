using UnityEngine;
using System.Collections;

public class ThermometerLevel : AbstractSubmarineLevel {

	public MultiLEDMeter meter;

	// Use this for initialization
	void Start () {
	
	}
	
	override public void UpdateDisplay()
	{
		meter.level = level;
	}
}
