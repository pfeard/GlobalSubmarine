using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
    public Text m_IpAddress;
    public GameObject m_Popup;

    public void OnCreateGame()
    {
        PlayerPrefs.SetString("IsHost", "True");
        SceneManager.LoadScene("Lobby");
    }

    public void OnJoinGame()
    {
        m_Popup.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void JoinGame()
    {
        NetworkManager.singleton.networkAddress = m_IpAddress.text;
        PlayerPrefs.SetString("IsHost", "False");
        SceneManager.LoadScene("Lobby");
    }
}

