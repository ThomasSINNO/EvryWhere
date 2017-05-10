using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour {

    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    private GameObject currentFather;

    public void resetFather()
    {
        currentFather = GameObject.Find("Liste");
        if (currentFather == null)
        {
            print("father not found");
        }
    }

    public void setParent(GameObject p)
    {
        transform.SetParent(p.transform);
    }

    public void resetParent()
    {
        transform.SetParent(GameObject.Find("Liste").transform);
    }

    private void Start()
    {
        resetFather();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        print("inside");
        if (coll.gameObject.GetComponent<BigBoxScript>() != null)
        {
            currentFather = coll.gameObject;
        }
        

    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        print("outside");
        if (coll.gameObject.GetComponent<BigBoxScript>() != null)
        {
            resetFather();
        }
       
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        print("onmousedown !");
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        resetParent();
        dragging = true;
        
    }


    public bool getDragging()
    {
        return dragging;
    }


    void OnMouseUp()
    {
        dragging = false;
        BigBoxScript bbs = currentFather.GetComponent<BigBoxScript>();
        print("currentfather test");
        if (bbs == null)
        {
            ListScript ls = currentFather.GetComponent<ListScript>();
            print("list test");
            if (ls == null)
            {
                print("error drop father bidule");
            } else
            {
                ls.putInbox(this.gameObject);
                print("list drop");
            }
            
        }
        else
        {
            if (bbs.getFree() == true)
            {
                bbs.putInBox(this.gameObject);
            } else
            {
                resetFather();
            }
           

        }
        
        
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
