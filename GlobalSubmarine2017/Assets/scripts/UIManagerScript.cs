using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {
	
	public string post;
	public PlayerBehavior player;
	public GameObject textBox;

	
	void Start ()
    {
		textBox.SetActive(false);
		player = PlayerMgr.Instance.GetMyPlayer();
		player._onNextTurn = onNextTurn;
		player._Conflict = Conflict;
	}
	
	public void ChooseRadar() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 0;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Radar";	
	}
	public void ChoosePilot() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 1;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Pilot";
	}
	public void ChooseEngine() 
	{
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 2;
		player.m_CurrentState = 0;
		player.SetReady();
		post = "Engine";
	}
	
	void onNextTurn()
	{
		SceneManager.LoadScene(post);
	}
	
	void Conflict()
	{
		textBox.SetActive(true);
	}
}
