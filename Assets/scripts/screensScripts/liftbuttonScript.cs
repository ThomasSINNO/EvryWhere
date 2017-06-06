using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class liftbuttonScript : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("lift");
    }
}
