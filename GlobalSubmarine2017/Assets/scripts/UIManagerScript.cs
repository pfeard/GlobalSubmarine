using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {

	public string post;
	public bool ready = false;

	public void ChoseRadar() 
	{
		post = "Radar"; 
		ready = true;
	}
	public void ChosePilot() 
	{
		post = "Pilot";
		ready = true;
	}
	public void ChoseEngine() 
	{
		post = "Engine";
		ready = true;
	}
	public void ChoseBedroom() 
	{
		post = "Bedroom";
		ready = true;
	}
	public void ChoseRadio() 
	{
		post = "Radio";
		ready = true;
	}
	
	public void StartRound()
	{
		SceneManager.LoadScene(post);
	}
}
