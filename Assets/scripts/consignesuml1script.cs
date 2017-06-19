using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class consignesuml1script : MonoBehaviour {

    public GameObject consignes;
    public int place;
    public int offset;
    public int width;
    public int height;
    static bool active;

    public void Start()
    {
        active = true;
        GameObject cons = GameObject.Instantiate(consignes);
        cons.transform.position = new Vector3(0, 0, -7);
    }
    public static void setboolcons(bool b)
    {
        active = b;
    }
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
            "consignes"
          )
        )
        {
            if (!active)
            {
                GameObject cons = GameObject.Instantiate(consignes);
                cons.transform.position = new Vector3(0, 0, -7);
            }
        }
    }
}
