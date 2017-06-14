using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour {

    protected GameObject currentFather;
    protected GameObject defaultFather;

    protected BoxCollider2D box_collider;
    protected Vector3 initial_box_colldier_size;
    protected Vector3 short_box_colldier_size;

    protected void shortenCollider()
    {
        box_collider.size = short_box_colldier_size;
    }
    protected void resetCollider()
    {
        box_collider.size = initial_box_colldier_size;
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
        if (coll.gameObject.GetComponent<BigBoxScript>() != null)
        {
            currentFather = coll.gameObject;
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
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(0);
        transform.position = rayPoint;
    }


}
