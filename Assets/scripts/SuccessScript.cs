using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        level0.activate(false);
        SceneManager.LoadScene("salle1");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
