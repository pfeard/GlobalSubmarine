using UnityEngine;
using System.Collections;

public class PropellersRuler : AbstractSubmarineRuler {

	//0: right propeller is on
	//1: left propeller is on

	public LEDLight rightPropellerLED;
	public LEDLight leftPropellerLED;

	// Use this for initialization
	void Start () {
		state = 0;
	}

	override public void UpdateDisplay()
	{
		rightPropellerLED.Set(state == 0);
		leftPropellerLED.Set(state == 1);
	}
}
