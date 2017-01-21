using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MatchMakingMgr : MonoBehaviour {

    public UnityEngine.UI.Image[] m_Leds;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey("IsHost"))
        {
            if (PlayerPrefs.GetString("IsHost") == "True")
                NetworkManager.singleton.StartHost();
            else
                NetworkManager.singleton.StartClient();
        }
        else
        {
            NetworkManager.singleton.StartClient();
        }

        for (int i = 0; i < 4; i++)
            PlayerMgr.Instance.m_POk[i] = m_Leds[i];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerMgr.Instance.GetPlayerCount() == 4)
            SceneManager.LoadScene("SelectPost");
	}
}
