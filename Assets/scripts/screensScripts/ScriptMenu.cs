
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Jouer!"
          )
        )
        {
            // Sur le clic, on démarre le jeu
            // "accueil" est le nom de la première scène que nous avons créés.
            SceneManager.LoadScene("accueil");
        }
    }
}
