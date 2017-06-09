using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back2script : MonoBehaviour
{

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              (Screen.width - (buttonWidth)),
              (Screen.height) - (buttonHeight),
              buttonWidth,
              buttonHeight
            ),
            "Retour"
          )
        )
        {
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            SceneManager.LoadScene("couloir1");
        }
    }
}
