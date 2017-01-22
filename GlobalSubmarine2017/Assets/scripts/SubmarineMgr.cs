using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMgr : Singleton<SubmarineMgr>
{
	float rulerChangeCooldown = 4.0f;
	float currentRulerCountdown = 0.0f;
	private float m_Temperature;
	public float Temperature
	{
		get{return m_Temperature;}
		set
		{
			if(value!=m_Temperature)
			{
				m_Temperature = value;
				DispatchTemperature();
			}	
		}
	}	
	
	private float m_Pressure;
	public float Pressure
	{
		get{return m_Pressure;}
		set
		{
			if(value!=m_Pressure)
			{
				m_Pressure = value;
				DispatchPressure();
			}
		}
	}
	
	private float m_Direction;
	public float Direction
	{
		get{return m_Direction;}
		set
		{
			if(value!=m_Direction)
			{
				m_Direction = value;
				DispatchDirection();
			}
		}
	}
	
	private int m_Controller1;
	public int Controller1
	{
		get{return m_Controller1;}
		set
		{
			if(value!=m_Controller1)
			{
				m_Controller1 = value;
				DispatchController1();
			}
		}
	}
	
	private int m_Controller2;
	public int Controller2
	{
		get{return m_Controller2;}
		set
		{
			if(value!=m_Controller2)
			{
				m_Controller2 = value;
				DispatchController2();
			}
		}
	}
	
	private int m_Controller3;
	public int Controller3
	{
		get{return m_Controller3;}
		set
		{
			if(value!=m_Controller3)
			{
				m_Controller3 = value;
				DispatchController3();
			}
		}
	}
	
	private int m_Info1;
	public int Info1
	{
		get{return m_Info1;}
		set
		{
			if(value!=m_Info1)
			{
				m_Info1 = value;
				DispatchInfo1();
			}
		}
	}
	
	private int m_Info2;
	public int Info2
	{
		get{return m_Info2;}
		set
		{
			if(value!=m_Info2)
			{
				m_Info2 = value;
				DispatchInfo2();
			}
		}
	}
	
	private int m_Info3;
	public int Info3
	{
		get{return m_Info3;}
		set
		{
			if(value!=m_Info3)
			{
				m_Info3 = value;
				DispatchInfo3();
			}
		}
	}
	
	bool IsServer()
    {
        if (PlayerMgr.Instance && PlayerMgr.Instance.GetMyPlayer())
        {
            if (PlayerMgr.Instance.GetMyPlayer().isServer)
            {
                return true;
            }
        }

        return false;
    }
	
	public void Update(){
		if (!IsServer())
			return;
		
		float thermometerDirection = 1.0f;
		if(Info1 == Controller1 || Controller1 == -1)
		{
			thermometerDirection = 1.0f;
		} else 
		{
			thermometerDirection = -1.0f;
		}
		Temperature += thermometerDirection * Time.deltaTime;

		float sonarDirection = 1.0f;
		if(Info2 == Controller2)
		{
			sonarDirection = 1.0f;
		} else 
		{
			sonarDirection = -1.0f;
		}
		Direction += sonarDirection * Time.deltaTime;

		float pressureDirection = 1.0f;
		if(Info3 == Controller3)
		{
			pressureDirection = 1.0f;
		} else 
		{
			pressureDirection = -1.0f;
		}
		Pressure += pressureDirection * Time.deltaTime;
		
		currentRulerCountdown -= Time.deltaTime;
		
		if(currentRulerCountdown <= 0.0f)
		{
			currentRulerCountdown = Random.Range(0.0f, rulerChangeCooldown);
			Debug.Log("Rules changed! next change in:"+currentRulerCountdown);

			//Randomly pick one of the ruler and reverse its state
			//(but don't change those who are problematic at the moment,
			//so that the problem don't fix themselves)
			int pick = Mathf.FloorToInt(Random.Range(0.0f, 2.99f));
			switch(pick)
			{
					case 0:
					//Sonar is doing fine... Let's fuck it up.
					if(sonarDirection < 0.0f)
					{
						Info2 = Info2==1?0:1;
					}

					break;
					case 1:
					//Thermometer is doing fine... Let's fuck it up.
					if(thermometerDirection < 0.0f)
					{
						Info1 = Info1==1?0:1;
					}
					break;
					case 2:
					//Pressure is doing fine... Let's fuck it up.
					if(pressureDirection < 0.0f)
					{
						Info3 = Info3==1?0:1;
					}
					break;
			}
		}
	}
	
	void DispatchTemperature()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInstrumentValue("Thermometer", m_Temperature);
		}
	}
	
	
	void DispatchPressure()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInstrumentValue("Pressure", m_Pressure);
		}
	}
	
	void DispatchDirection()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInstrumentValue("Direction", m_Direction);
		}
	}
	
	void DispatchController1()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetControllerValue("Controller1", m_Controller1);
		}
	}
	
	void DispatchController2()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetControllerValue("Controller2", m_Controller2);
		}
	}
	
	void DispatchController3()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetControllerValue("Controller3", m_Controller3);
		}
	}
	
	void DispatchInfo1()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInfoValue("Info1",m_Info1);
		}
	}
	
	void DispatchInfo2()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInfoValue("Info2",m_Info2);
		}
	}
	
	void DispatchInfo3()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			player.SetInfoValue("Info3",m_Info3);
		}
	}
}