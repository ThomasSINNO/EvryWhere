using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back1salleScript : MonoBehaviour
{
    public int place;
    public int offset;
    public int width;
    public int height;

    void OnGUI()
    {
        int buttonWidth = width;
        int buttonHeight = height;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              10,
              (Screen.height) - place*((buttonHeight) + offset),
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
