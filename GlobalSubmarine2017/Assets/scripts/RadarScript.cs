using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class RadarScript : MonoBehaviour {

	// Use this for initialization
	PlayerBehavior player;

    public SonarLevel m_SonarLevel;
    public DiveController m_DiveController;
    public CoolingAlarmRuler m_CoolingAlarmRuler;

    int previousDiveState;

    void Start ()
    {
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = setInstrumentValue;
        player._setInfoValue = SetRulerValue;

        previousDiveState = m_DiveController.currentState;
    }

    public void Update()
    {
        if (previousDiveState != m_DiveController.currentState)
        {
            previousDiveState = m_DiveController.currentState;
            player.CmdSetControllerValue("Controller1", m_DiveController.currentState);
        }
    }
	
	void setInstrumentValue(string instrument, float value )
	{
        if (instrument == "Radar")
            m_SonarLevel.level = value;
        //m_Sonar.level = value;
    }

    void SetRulerValue(string ruler, int value)
    {
        if (ruler == "Info1")
        {
            m_CoolingAlarmRuler.state = value;
        }
    }
	
	
}
