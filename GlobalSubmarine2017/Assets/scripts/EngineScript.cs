using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour {
	
	PlayerBehavior player;

    public PressureLevel m_Barometer;
    public CoolingController m_CoolingController;
    public PropellersRuler m_PropellerRuler;
    int previousCoolingState;

    // Use this for initialization
    void Start ()
    {
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = SetInstrumentValue;
        player._setInfoValue = SetRulerValue;
        previousCoolingState = m_CoolingController.currentState;

    }

    private void Update()
    {
        if (previousCoolingState != m_CoolingController.currentState)
        {
            previousCoolingState = m_CoolingController.currentState;
            player.CmdSetControllerValue("Controller1", m_CoolingController.currentState);
        }
    }

    void SetRulerValue(string ruler, int value)
    {
        if (ruler == "Info2")
        {
            m_PropellerRuler.state = value;
        }
    }

    void SetInstrumentValue(string instrument, float value )
	{
        if (instrument == "Pressure")
            m_Barometer.level = value;
	}
}
