using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        level0.activate(false);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
