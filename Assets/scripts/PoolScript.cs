using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour {

    private bool isActive;
    private typeobject activetype;

    private GameObject Signenv;
    private GameObject Signrec;
    private GameObject Messenv;
    private GameObject Messrec;
    private GameObject Signfin;
    private GameObject Activite;
    private GameObject Xor;
    private GameObject And;
    private GameObject Minut;
    private GameObject Oui;
    private GameObject Non;
    private GameObject Arrow;

    private Camera c;

    private void Awake()
    {
        Signenv = GameObject.Find("SignalEmission");
        Signrec = GameObject.Find("SignalReception");
        Messenv = GameObject.Find("MessageEmission");
        Messrec = GameObject.Find("MessageReception");
        Signfin = GameObject.Find("SignalFin");
        Activite = GameObject.Find("Activite");
        Xor = GameObject.Find("Xor");
        And = GameObject.Find("And");
        Minut = GameObject.Find("Minuterie");
        Oui = GameObject.Find("Oui");
        Non = GameObject.Find("Non");

        c = Camera.main;
    }

    public void Activate(typeobject type)
    {
        isActive = true;
        activetype = type;
        print("activate !");
    }

    public void Unactivate()
    {
        isActive = false;
        print("desactivate");
    }

    public void OnMouseDown()
    {
        if (isActive)
        {
            print("on mouse down !");
            if (activetype == typeobject.ACTIV)
            {
                GameObject act = GameObject.Instantiate(Activite);
                act.transform.position = c.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,5);
            }
            if (activetype == typeobject.AND)
            {
                GameObject a = GameObject.Instantiate(And);
                a.transform.position = c.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 5);
            }

            Unactivate();
        } 
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
