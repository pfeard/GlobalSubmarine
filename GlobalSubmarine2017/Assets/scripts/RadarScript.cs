using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class RadarScript : MonoBehaviour {

	// Use this for initialization
	public PlayerBehavior player;
	public float IndicatorSonar;
	public ToggleButton button;
    SonarLevel m_Sonar;
	
	void Start () {
		
		player = PlayerMgr.Instance.GetMyPlayer();
		player._setInstrumentValue = setInstrumentValue;
		
	}
	
	public void Toggle(bool toggle)
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		//player.buttons["Toggle"]=toggle;
		//player.changeButton("Toggle",toggle);
	}
	
	void setInstrumentValue(string instrument, float value )
	{
        m_Sonar.level = value;
	}
	
	
}
