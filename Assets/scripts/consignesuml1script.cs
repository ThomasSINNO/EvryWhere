using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class consignesuml1script : MonoBehaviour {

    public GameObject consignes;
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
              (Screen.height) - 3*(buttonHeight) - 30,
              buttonWidth,
              buttonHeight
            ),
            "consignes"
          )
        )
        {
            GameObject cons = GameObject.Instantiate(consignes);
            cons.transform.position = new Vector3(0, 0, -7);
        }
    }
}
