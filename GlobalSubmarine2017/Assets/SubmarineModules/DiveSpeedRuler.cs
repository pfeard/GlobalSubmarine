using UnityEngine;
using System.Collections;

public class DiveSpeedRuler : AbstractSubmarineRuler {

	//0: speed is below 50
	//1: speed is over 50

	public SegmentsDisplay display;

	// Use this for initialization
	void Start () {
		state = 0;
	}

	override public void UpdateDisplay()
	{
		int value = Random.Range(
			(state == 0)?10:60,
			(state == 0)?40:90
		);
		display.SetValue(value.ToString());
	}
}
