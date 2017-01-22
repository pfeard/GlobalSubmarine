using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScript : MonoBehaviour {
	
	public MultiLEDMeter thermometer;
	public PlayerBehavior player;

	// Use this for initialization
	void Start () {
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = setInstrumentValue;
	}
	
	
	public void Toggle(bool toggle)
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.changeButton("Toggle",toggle);
	}
	
	void setInstrumentValue(string instrument, float value )
	{
		thermometer.level = value;
	}
}
