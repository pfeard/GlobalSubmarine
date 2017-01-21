using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
  void OnGUI()
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
		Application.LoadLevel("Salon");
		
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
		Application.LoadLevel("Salon");
    }
  }
}

