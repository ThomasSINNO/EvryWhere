using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkFleche : FlecheScript {

    void Start()
    {
        isActive = false;
        tab = new List<GameObject>();
        arrow = GameObject.Find("Arrow");
        type = typearrow.LINK;
        gameObject.tag = "ArrowButton";
    }
}
