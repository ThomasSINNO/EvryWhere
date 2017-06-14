using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reunion2script : MonoBehaviour
{

    public static bool haspassedbpmnlvl1 = false;
    private void OnMouseDown()
    {
        if (haspassedbpmnlvl1)
        {
            SceneManager.LoadScene("reunion2_2");
        }
        else
        {
            SceneManager.LoadScene("reunion2_1");
        }
    }
}

