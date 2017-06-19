using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour {

    private bool isActive;

    private GameObject recu;


    private Camera c;

    private void Awake()
    {
        
        c = Camera.main;
    }

    public void Activate(GameObject g)
    {
        isActive = true;
        recu = g;
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
            GameObject gobj = GameObject.Instantiate(recu);
            //NameBoxScript nbs = gobj.GetComponent<NameBoxScript>();
            
            gobj.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0)+new Vector3(0,0,5);
            //if (nbs)
            //{
            //    nbs.nextPos = gobj.transform.position;
            //}
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
