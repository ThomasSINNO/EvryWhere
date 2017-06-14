using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reunion1script : MonoBehaviour {

    public static bool haspassedumllvl1 = false;
    private void OnMouseDown()
    {
        if (haspassedumllvl1)
        {
            SceneManager.LoadScene("reunion1_2");
        } else
        {
            SceneManager.LoadScene("reunion1_1");
        }
    }
}
