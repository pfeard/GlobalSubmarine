using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMgr : Singleton<SubmarineMgr>
{
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
	
	private int m_info1;
	public int info1
	{
		get{return m_info1;}
		set
		{
			if(value!=m_info1)
			{
				m_info1 = value;
				DispatchInfo1();
			}
		}
	}
	
	private int m_info2;
	public int info2
	{
		get{return m_info2;}
		set
		{
			if(value!=m_info2)
			{
				m_info2 = value;
				DispatchInfo2();
			}
		}
	}
	
	private int m_info3;
	public int info3
	{
		get{return m_info3;}
		set
		{
			if(value!=m_info3)
			{
				m_info3 = value;
				DispatchInfo3();
			}
		}
	}
	
	void DispatchTemperature()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 1)
			{
				player.setInstrumentValue("Thermometer", m_Temperature);
			}
		}
	}
	
	
	void DispatchPressure()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 2)
			{
				player.setInstrumentValue("Pressure", m_Pressure);
			}
		}
	}
	
	void DispatchDirection()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 0)
			{
				player.setInstrumentValue("Direction", m_Direction);
			}
		}
	}
	
	void DispatchController1()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 0)
			{
				//TODO send controller1 to player
			}
		}
	}
	
	void DispatchController2()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 1)
			{
				//TODO send controller2 to player
			}
		}
	}
	
	void DispatchController3()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 2)
			{
				//TODO send controller3 to player
			}
		}
	}
	
	void DispatchInfo1()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 2)
			{
				//TODO send info1 to player
			}
		}
	}
	
	void DispatchInfo2()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 0)
			{
				//TODO send info2 to player
			}
		}
	}
	
	void DispatchInfo3()
	{
		foreach(PlayerBehavior player in PlayerMgr.Instance.m_Players)
		{
			if(player.m_CurrentActivity == 1)
			{
				//TODO send info3 to player
			}
		}
	}
}