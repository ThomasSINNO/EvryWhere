using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour {

    public GameObject currentFather;
    protected GameObject defaultFather;

    protected BoxCollider2D box_collider;
    protected Vector3 initial_box_colldier_size;
    protected Vector3 short_box_colldier_size;

    protected bool is_active;

    protected void shortenCollider()
    {
        box_collider.size = short_box_colldier_size;
    }
    protected void resetCollider()
    {
        //tehre might be a colliding problem when we re grow it to its actual size so let's backup the current father and re apply it afterwards
        GameObject currentFather_back= currentFather;
        //print("resetCollider before: " + currentFather.name + ":" + currentFather.GetInstanceID());
        box_collider.size = initial_box_colldier_size;
        currentFather = currentFather_back;
        //print("resetCollider after: " + currentFather.name + ":" + currentFather.GetInstanceID());
    }

    private void Start()
    {
        box_collider = this.gameObject.GetComponent<BoxCollider2D>();
        if(box_collider==null)
        {
            print("ERROR:could not find box colldier on drag drop script");
            return;
        }
        initial_box_colldier_size = box_collider.size;
        short_box_colldier_size = new Vector3(0.5f,0.5f,0.5f);
        defaultFather = GameObject.Find("Liste");
        currentFather = defaultFather;
        if (defaultFather == null)
        {
            print("Could not find defaultFather on DragDropScript");
        }
        else
        {
            //print("trouvé");
            BigBoxScript bbs = defaultFather.GetComponent<BigBoxScript>();
            if (bbs == null)
                print("error bbs null");
            else
                bbs.addItem(gameObject);

        }
        is_active = false;
    }

    public void resetPosition()
    {
        currentFather = defaultFather;
        BigBoxScript bbs = defaultFather.GetComponent<BigBoxScript>();
        bbs.addItem(this.gameObject);

    }
    public float getHeight()
    {
        Collider2D coll = gameObject.GetComponent<Collider2D>();
        if (coll == null)
        {
            print("error getting collider");
            return (-1);
        } else
        {
            return (coll.bounds.size.y);
        }
        
    }

   
    void OnTriggerEnter2D(Collider2D coll)
    {
        //print("inside");
        if (coll.gameObject.GetComponent<BigBoxScript>() != null && is_active)
        {
            //print("OnTriggerEnter2D before: " + currentFather.name + ":" + currentFather.GetInstanceID());
            currentFather = coll.gameObject;
           // print("OnTriggerEnter2D after: " + currentFather.name + ":" + currentFather.GetInstanceID());
        } 
    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        //print("outside");
        if (coll.gameObject.GetComponent<BigBoxScript>() != null)
        {
            currentFather = defaultFather;
        }
       
    }

    
    void OnMouseDown()
    {
        //print("onmousedown !");

        BigBoxScript bbs = currentFather.GetComponent<BigBoxScript>();
        bbs.removeItem(this.gameObject);
        shortenCollider();
        is_active = true;
    }  
    void OnMouseUp()
    {
        BigBoxScript bbs = currentFather.GetComponent<BigBoxScript>();
        resetCollider();
        if (bbs == null)
        {
            print("erreur bbs=null");
        } else
        {
            bbs.addItem(this.gameObject);
        }
        is_active = false;
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(0);
        transform.position = rayPoint;
    }


}
