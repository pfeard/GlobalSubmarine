﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour {
	
	public PlayerBehavior player;
    public NeedleMeter m_Barometer;

	// Use this for initialization
	void Start () {
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = setInstrumentValue;
		
	}
	
	void setInstrumentValue(string instrument, float value )
	{
        m_Barometer.level = value;
	}
}
