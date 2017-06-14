using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropMulScript : DragDropScript
{

    private void Start()
    {
        defaultFather = GameObject.Find("Liste2");
        currentFather = defaultFather;
        if (defaultFather == null)
        {
            print("ERREUR DE L'ESPACE");
        }
        else
        {
            BigBoxScript bbs = defaultFather.GetComponent<BigBoxScript>();
            if (bbs == null)
                print("error bbs null");
            else
                bbs.addItem(gameObject);
        }
    }

    //public void resetPosition()
    //{
    //    currentFather2 = defaultFather2;
    //    BigBoxScript bbs = defaultFather2.GetComponent<BigBoxScript>();
    //    bbs.addItem(this.gameObject);

    //}
    //public float getHeight()
    //{
    //    Collider2D coll = gameObject.GetComponent<Collider2D>();
    //    if (coll == null)
    //    {
    //        print("error getting collider");
    //        return (-1);
    //    }
    //    else
    //    {
    //        return (coll.bounds.size.y);
    //    }

    //}


    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    print("inside");
    //    if (coll.gameObject.GetComponent<BigBoxScript>() != null)
    //    {
    //        currentFather2 = coll.gameObject;
    //    }


    //}


    //private void OnTriggerExit2D(Collider2D coll)
    //{
    //    print("outside");
    //    if (coll.gameObject.GetComponent<BigBoxScript>() != null)
    //    {
    //        currentFather2 = defaultFather2;
    //    }

    //}









    //void OnMouseDown()
    //{
    //    print("onmousedown !");

    //    BigBoxScript bbs = currentFather2.GetComponent<BigBoxScript>();
    //    bbs.removeItem(this.gameObject);

    //}











    //void OnMouseUp()
    //{
    //    BigBoxScript bbs = currentFather2.GetComponent<BigBoxScript>();
    //    if (bbs == null)
    //    {
    //        print("erreur bbs=null");
    //    }
    //    else
    //    {
    //        bbs.addItem(this.gameObject);
    //    }
    //}







    //private void OnMouseDrag()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Vector3 rayPoint = ray.GetPoint(0);
    //    transform.position = rayPoint;
    //}


}
