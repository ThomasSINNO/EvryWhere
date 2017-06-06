using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class salle1script : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("salle1");
    }
}
