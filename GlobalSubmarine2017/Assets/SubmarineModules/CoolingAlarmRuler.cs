using UnityEngine;
using System.Collections;

public class CoolingAlarmRuler : AbstractSubmarineRuler {

	//0: alarm is off
	//1: alarm is on

	public LEDLight led;

	// Use this for initialization
	void Start () {
		state = 0;
	}

	override public void UpdateDisplay()
	{
		led.Set(state == 1);
	}
}
