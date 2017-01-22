using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScript : MonoBehaviour {
	
	public ThermometerLevel thermometer;
	public DirectionController directionController;
	public DiveSpeedRuler diveSpeedRuler;
	public PlayerBehavior player;

	// Use this for initialization
	void Start () {
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = setInstrumentValue;
		player._setInfoValue = setInfoValue;
		player._setControllerValue = setControllerValue;
	}
	
	
	public void Toggle(bool toggle)
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		//player.changeButton("Toggle",toggle);
	}
	
	void setInstrumentValue(string instrument, float value )
	{
		if(instrument == "Thermometer")
		{
			thermometer.level = value;	
		}
	}
	
	void setInfoValue(string info, int value )
	{
		if(info == "Info3")
		{
			diveSpeedRuler.state = value;	
		}
	}
	
	void setControllerValue(string controller, int value )
	{
		if(controller == "Controller2")
		{
			directionController.currentState = value;	
		}
	}
	
	public void OnClick()
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.CmdSetControllerValue("Controller2",directionController.currentState);
	}
}
