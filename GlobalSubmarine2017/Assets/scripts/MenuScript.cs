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
        /*PlayerPrefs.SetString("IsHost", "False");
        SceneManager.LoadScene("Lobby");*/
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
  /*void OnGUI()
  {
    const int buttonWidth = 84;
    const int buttonHeight = 60;

    // Affiche un bouton pour démarrer la partie
    if (
      GUI.Button(
        // Centré en x, 1/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (1 * Screen.height / 3) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Start game"
      )
    )
	{
		PlayerPrefs.SetString("IsHost", "True");

        SceneManager.LoadScene("Lobby");
		
	}
	//Affiche un bouton pour rejoindre une partie
	if (
      GUI.Button(
        // Centré en x, 2/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 3) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Join game"
      )
    )
    {
		PlayerPrefs.SetString("IsHost", "False");
        SceneManager.LoadScene("Lobby");
    }
  }*/
}

