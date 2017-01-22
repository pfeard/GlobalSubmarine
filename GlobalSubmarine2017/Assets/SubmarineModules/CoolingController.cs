using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CoolingController : AbstractSubmarineController {

	public ToggleButton button1;
	public ToggleButton button2;
	public ToggleButton button3;
	public ToggleButton button4;

	// Use this for initialization
	void Start () {
		button1.onToggle.AddListener(b => {CheckState();});
		button2.onToggle.AddListener(b => {CheckState();});
		button3.onToggle.AddListener(b => {CheckState();});
		button4.onToggle.AddListener(b => {CheckState();});
	}

	void CheckState()
	{
		//Even buttons are both pressed, Odd buttons aren't
		if(button1.isDefaultState && button3.isDefaultState &&
			!button2.isDefaultState && !button4.isDefaultState)
		{
			currentState = 0;
		} else
		//Odd buttons are both pressed, Even buttons aren't
		if (!button1.isDefaultState && !button3.isDefaultState &&
			button2.isDefaultState && button4.isDefaultState)
		{
			currentState = 1;
		} else
		//Any other case
		{
			currentState = -1;
		}
	}
}
