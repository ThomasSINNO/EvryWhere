using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoxScript : MonoBehaviour {

    protected ArrayList listItems ;
    protected Vector3 nextPos;
    float spacer;

    public BigBoxScript()
    {
        listItems = new ArrayList();
    }

    private void Awake()
    {
        Collider2D col = this.gameObject.GetComponent<Collider2D>();
        float y = col.bounds.size.y;
        nextPos = transform.position+new Vector3(0,y/2-0.3f,-1);
        listItems = new ArrayList();
        spacer = 0.0f;
        print("awake bbs !");

    }

    public virtual void addItem(GameObject gobj)
    {
        listItems.Add(gobj);
        //gobj.transform.SetParent(this.transform);
        gobj.transform.position = nextPos;

        DragDropScript dds = gobj.GetComponent<DragDropScript>();
        if (dds == null)
        {
            DragDropMulScript ddms = gobj.GetComponent<DragDropMulScript>();
            nextPos.y = nextPos.y - ddms.getHeight() - spacer;
        }
        else
        {
            nextPos.y = nextPos.y - dds.getHeight() - spacer;
        }
    }

    public virtual void removeItem(GameObject gobj)
    {
        int i = listItems.IndexOf(gobj);
        if (i < 0)
            print("item not found in array");
        else
        {
            float num = 0f;
            DragDropScript dds = gobj.GetComponent<DragDropScript>();
            if (dds == null)
            {
                DragDropMulScript ddms = gobj.GetComponent<DragDropMulScript>();
                num = ddms.getHeight();
            }else
            {
                num = dds.getHeight();
            }
            Vector3 removedheight = new Vector3(0, num+spacer, 0);
            listItems.RemoveAt(i);
            for (int j = i; j < listItems.Count; j++)
            {
                GameObject a = (GameObject)listItems[j];
                a.transform.position = a.transform.position + removedheight;
            }
            nextPos = nextPos + removedheight;
            //gobj.GetComponent<DragDropScript>().resetParent();
        }
        
    }

    void OnMouseDown()
    {
        print("onmousedown bbs!");
       
    }
}
