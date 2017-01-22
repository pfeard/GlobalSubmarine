using UnityEngine;
using System.Collections;

public class DiveController : AbstractSubmarineController {

	public ToggleButton slowButton;
	public ToggleButton diveButton;

	// Use this for initialization
	void Start () {
		diveButton.onToggle.AddListener(b => {CheckState();});
	}

	void CheckState()
	{
		// 0: slow is off
		// 1: slow is on

		//CheckState is called when the dive button is toggled
		//which means we always end up here after a change of
		//diving/surfacing direction. It doesn't influence
		//the currentState, but it's mandatory that it changes
		//for the check to be done.

		currentState = slowButton.isDefaultState?0:1;
	}
}
