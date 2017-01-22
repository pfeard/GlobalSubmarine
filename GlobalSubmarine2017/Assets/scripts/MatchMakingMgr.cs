using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MatchMakingMgr : MonoBehaviour {

    public UnityEngine.UI.Image[] m_Leds;
    public Text m_IpInfo;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey("IsHost"))
        {
            if (PlayerPrefs.GetString("IsHost") == "True")
            {
                NetworkManager.singleton.StartHost();
                m_IpInfo.text = Network.player.ipAddress;
            }
            else
                NetworkManager.singleton.StartClient();
        }
        else
        {
            NetworkManager.singleton.StartClient();
        }

        for (int i = 0; i < PlayerMgr.sPlayerCount; i++)
            PlayerMgr.Instance.m_POk[i] = m_Leds[i];

    }

    // Update is called once per frame
    void Update ()
    {
        if (PlayerMgr.Instance.GetPlayerCount() == PlayerMgr.sPlayerCount)
            SceneManager.LoadScene("SelectPost");
	}

    public void LeaveLobby()
    {
        PlayerMgr.Instance.RemoveMe();

        if (PlayerPrefs.HasKey("IsHost"))
        {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }

        SceneManager.LoadScene("Menu");
    }
}
