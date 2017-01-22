using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class MutuallyExclusiveToggleButtons : MonoBehaviour {

	List<ToggleButton> buttons = new List<ToggleButton>();

	[System.Serializable]
	public class MutuallyExclusiveToggleButtonEvent : UnityEvent<int>{}
	[SerializeField]
	public MutuallyExclusiveToggleButtonEvent onAnyToggle = new MutuallyExclusiveToggleButtonEvent();

	public GameObject parentObject;
	public int currentActiveButton;

	// Use this for initialization
	void Start () {
		ToggleButton[] availableButtons = parentObject.GetComponentsInChildren<ToggleButton>();
		for(int i = 0; i < availableButtons.Length; i++)
		{
			ToggleButton button = availableButtons[i];

			int temp = i;

			button.onToggle.AddListener( v => HandleAnyToggle(temp) );

			buttons.Add(button);
		}

		HandleAnyToggle(currentActiveButton);
	}

	void HandleAnyToggle(int id)
	{
		if(currentActiveButton == id)
		{
			//No re-press!
			//The button WILL be Toggled, untoggle it asap
			//WARNING: its onToggle event will be fired!
			//Ignore all the onToggle events from MutuallyExclusiveToggleButtons
			// to avoid any weird behaviour.
			buttons[id].Set(false);
			return;
		}
		for(int i = 0; i < buttons.Count; i++)
		{
			buttons[i].Set(i != id);
		}
		currentActiveButton = id;
		onAnyToggle.Invoke(currentActiveButton);
	}


}
