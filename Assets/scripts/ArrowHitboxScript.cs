using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHitboxScript : MonoBehaviour {

    private bool isActive;
    private bool isClicked;
    private GameObject callingArrow;

    //private Color rouge = new Color(128, 0, 0, 1);
    // Use this for initialization
    void Awake () {
        isActive = false;
        callingArrow = null;
        gameObject.tag = "ArrowHitbox";
        SpriteRenderer rend = this.gameObject.GetComponent<SpriteRenderer>();
        rend.color = Color.clear;
        this.Deactivate();
    }

    public void Activate(GameObject g)
    {
        isActive = true;
        callingArrow = g;
        //MeshRenderer goRenderer = this.gameObject.GetComponent<MeshRenderer>();
        //Material newMaterial = new Material(Shader.Find("Whatever name of the shader you want to use"));
        SpriteRenderer rend = this.gameObject.GetComponent<SpriteRenderer>();
        rend.color = Color.red;
        gameObject.layer = 0;//default layer to make it clickable again
    }

    public void Deactivate()
    {
        isActive = false;
        callingArrow = null;
        SpriteRenderer rend = this.gameObject.GetComponent<SpriteRenderer>();
        rend.color = Color.clear;
        gameObject.layer = 2;//ignoreRaycast_layer to stop it from being clickable
    }

    public void OnMouseDown()
    {
        if (callingArrow == null)
            return;
        if (callingArrow.GetComponent < FlecheScript >()== null)
        {
            print("error find flechescript");
        }
        callingArrow.GetComponent<FlecheScript>().EndArrow(this.gameObject);
        //print("onmousedown arrowhitbox");
    }

    //public void OnMouseUp()
    //{
    //    callingArrow.GetComponent<FlecheScript>().EndArrow(this.gameObject);
    //    print("onmouseup arrowhitbox");
    //}

    // Update is called once per frame
    void Update () {
	}
}
