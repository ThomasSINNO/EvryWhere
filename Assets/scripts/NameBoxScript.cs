using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameBoxScript : BigBoxScript {

    bool isFree;


	// Use this for initialization
	void Awake () {
        isFree = true;
        print("awake nbs");
        nextPos = transform.position;
	}

    public override void addItem(GameObject gobj)
    {
        if (isFree)
        {
            base.addItem(gobj);
            isFree = false;
        }

        else
        {
            GameObject i = (GameObject)listItems[0];
            base.removeItem(i);
            i.GetComponent<DragDropScript>().resetPosition();
            base.addItem(gobj);
        }
    }

    public override void removeItem(GameObject gobj)
    {
        base.removeItem(gobj);
        isFree = true;
    }
    
}
