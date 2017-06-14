using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeobject
{
    ACTIV,AND,XOR,FINERR,MESSENV,MESSREC,TIME,SIGNFIN,SIGNREC,SIGNENV,OUI,NON,ARROW
};

public class GenerateScript : MonoBehaviour {

    public typeobject type;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        GameObject[] l = GameObject.FindGameObjectsWithTag("Pool");
        foreach (GameObject i in l)
        {
            PoolScript ps = i.GetComponent<PoolScript>();
            ps.Activate(type);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
