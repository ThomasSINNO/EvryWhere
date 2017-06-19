using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back2sallescript : MonoBehaviour
{
    public int offset;
    public int place;
    public int width;
    public int height;

    void OnGUI()
    {
        int buttonWidth = width;
        int buttonHeight = height;

        if (
          GUI.Button(
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
            SceneManager.LoadScene("salle2");
        }
    }
}
