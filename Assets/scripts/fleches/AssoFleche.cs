using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssoFleche : FlecheScript {

    void Start()
    {
        isActive = false;
        tab = new List<GameObject>();
        arrow = GameObject.Find("Arrow");
        type = typearrow.ASSO;
        gameObject.tag = "ArrowButton";
    }
}
