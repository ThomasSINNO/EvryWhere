using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCollider : MonoBehaviour {

    public GameObject test1;
    public Rigidbody2D original;
    public Rigidbody clone;
    private bool boul=false;
 
    Vector2 Position()
    {
        return this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        GameObject.Destroy(collision.gameObject);


    }



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (boul)
        {
            //if original.gameObject.
           // Rigidbody2D clone = (Rigidbody2D)Instantiate(original, this.transform.position, this.transform.rotation);
           // Destroy(original);
        }
	}
}
