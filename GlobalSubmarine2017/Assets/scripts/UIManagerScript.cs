using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {
	
	public string post;
	public PlayerBehavior player;

	public void ChoseRadar() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 0;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Radar";
		if(PlayerMgr.Instance.IsEveryoneReady())
		{
			StartRound();
		}		
	}
	public void ChosePilot() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 1;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Pilot";
		if(PlayerMgr.Instance.IsEveryoneReady())
		{
			StartRound();
		}
	}
	public void ChoseEngine() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 2;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Engine";
		if(PlayerMgr.Instance.IsEveryoneReady())
		{
			StartRound();
		}
	}
	public void ChoseBedroom() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 3;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Bedroom";
		if(PlayerMgr.Instance.IsEveryoneReady())
		{
			StartRound();
		}
	}
	public void ChoseRadio() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 4;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Radio";
		if(PlayerMgr.Instance.IsEveryoneReady())
		{
			StartRound();
		}
	}
	
	public void StartRound()
	{
		SceneManager.LoadScene(post);
	}
}
