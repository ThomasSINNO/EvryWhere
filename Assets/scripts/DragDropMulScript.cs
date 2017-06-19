using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropMulScript : DragDropScript
{
    private void Start()
    {
        box_collider = this.gameObject.GetComponent<BoxCollider2D>();
        if (box_collider == null)
        {
            print("ERROR:could not find box colldier on drag drop script");
            return;
        }
        initial_box_colldier_size = box_collider.size;
        short_box_colldier_size = new Vector3(0.5f, 0.5f, 0.5f);
        defaultFather = GameObject.Find("Liste2");
        currentFather = defaultFather;
        if (defaultFather == null)
        {
            print("ERREUR DE L'ESPACE");
        }
        
        else
        {
            print("list2 ok");
            BigBoxScript bbs = defaultFather.GetComponent<BigBoxScript>();
            if (bbs == null)
                print("error bbs null");
            else
                bbs.addItem(gameObject);
        }
    }

    //private void OnMouseDown()
    //{
    //    GameObject[] spots = GameObject.FindGameObjectsWithTag("muldrop");
    //    foreach (GameObject g in spots)
    //    {
    //        NameBoxScript nbs = g.GetComponent<NameBoxScript>();
    //        SpriteRenderer rend = g.gameObject.GetComponent<SpriteRenderer>();
    //        rend.color = Color.red;

    //    }
    //    base.OnMouseDown();
    //}

    //private void OnMouseUp()
    //{
    //    GameObject[] spots = GameObject.FindGameObjectsWithTag("muldrop");
    //    foreach (GameObject g in spots)
    //    {
    //        NameBoxScript nbs = g.GetComponent<NameBoxScript>();
    //        SpriteRenderer rend = g.gameObject.GetComponent<SpriteRenderer>();
    //        rend.sprite = g.GetComponent<NameBoxScript>().spr;
    //    }
    //    base.OnMouseUp();
    //}



}
