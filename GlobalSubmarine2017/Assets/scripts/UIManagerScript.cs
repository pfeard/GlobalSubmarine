using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	
	public string post;
	public PlayerBehavior player;
	public GameObject textBox;
    public GameObject ready1;
    public GameObject ready2;
    public GameObject ready3;

    void Start ()
    {

        textBox.SetActive(false);
        ready1.SetActive(false);
        ready2.SetActive(false);
        ready3.SetActive(false);
        player = PlayerMgr.Instance.GetMyPlayer();
        player._onTurnStart = onNextTurn;
		/*player._onNextTurn = onNextTurn;
		player._Conflict = Conflict;*/
    }

    private void Update()
    {
        player = PlayerMgr.Instance.GetMyPlayer();
        if (player.m_ReadyForNextTurn)
        {
            switch (player.m_CurrentActivity)
            {
                case 0:
                    ready1.SetActive(true);
                    break;
                case 1:
                    ready2.SetActive(true);
                    break;
                case 2:
                    ready3.SetActive(true);
                    break;
            }
        }
    }
	
	public void ChooseRadar() 
	{
		textBox.SetActive(false);
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 0;
		player.SetReady();
		post = "Radar";	
	}
	public void ChoosePilot() 
	{
		textBox.SetActive(false);
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 1;
		player.SetReady();
		post = "Pilot";
	}
	public void ChooseEngine() 
	{
		textBox.SetActive(false);
		player = PlayerMgr.Instance.GetMyPlayer();
		player.m_CurrentActivity = 2;
		player.SetReady();
		post = "Engine";
	}
	
	void onNextTurn()
	{
		SceneManager.LoadScene(post);
	}
	
	/*void Conflict()
	{
		textBox.SetActive(true);
	}*/
}
