using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoxScript : MonoBehaviour {

    bool isFree = true;

    public bool getFree()
    {
        return isFree;
    }
	public void putInBox(GameObject a)
    {

        print("putinbox!");
            a.GetComponent<DragDropScript>().setParent(transform.parent.gameObject);
            print("setParent!");
            a.transform.position = transform.position;
            isFree = false;
        
    }

    public void removeFromBox(GameObject a)
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
