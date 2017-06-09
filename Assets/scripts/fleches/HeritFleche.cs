using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeritFleche : FlecheScript {

    void Start()
    {
        isActive = false;
        tab = new List<GameObject>();
        arrow = GameObject.Find("Arrow");
        type = typearrow.HERIT;
        gameObject.tag = "ArrowButton";
    }
}
