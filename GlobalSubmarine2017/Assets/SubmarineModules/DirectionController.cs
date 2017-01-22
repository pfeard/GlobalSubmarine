using UnityEngine;
using System.Collections;

public class DirectionController : AbstractSubmarineController {

	public MutuallyExclusiveToggleButtons buttons;

	// Use this for initialization
	void Start () {
		buttons.onAnyToggle.AddListener(i => DirectionChanged(i));
	}

	void DirectionChanged(int direction)
	{
		// 0: left
		// 1: right
		currentState = direction;
	}
}
