using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoFleche : FlecheScript {

    void Start()
    {
        isActive = false;
        tab = new List<GameObject>();
        arrow = GameObject.Find("Arrow");
        type = typearrow.COMPO;
        gameObject.tag = "ArrowButton";
    }
}
