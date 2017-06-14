using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back1salleScript : MonoBehaviour
{

    void OnGUI()
    {
        const int buttonWidth = 70;
        const int buttonHeight = 30;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              10,
              (Screen.height) - (buttonHeight) - 10,
              buttonWidth,
              buttonHeight
            ),
            "Retour"
          )
        )
        {
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            SceneManager.LoadScene("salle1");
        }
    }
}
