using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public typearrow type;
    private GameObject depart;
    private GameObject arrivee;
    private GameObject multdep;
    private GameObject multarr;

    private void Start()
    {
        type = typearrow.UNDEF;
        depart = null;
        arrivee = null;
        multdep = null;
        multarr = null;
    }

    public void setthings(typearrow t,GameObject d,GameObject a)
    {
        type = t;
        depart = d;
        arrivee = a;
    }

    public void deletearrow()
    {
        Destroy(this.gameObject);
    }

}
