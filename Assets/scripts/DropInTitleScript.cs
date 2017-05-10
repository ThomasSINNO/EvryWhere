using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropInTitleScript : MonoBehaviour {

    private void OnCollisionEnter(Collision coll)
    {
        print("collision enter");
        coll.gameObject.GetComponent<DragDropScript>().getDragging();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
