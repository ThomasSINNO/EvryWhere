﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoxScript : MonoBehaviour {

    protected ArrayList listItems ;
    public Vector3 nextPos;
    public float spacer;

    public Vector3 offset;

    public void emptyList()
    {
        while (listItems.Count >0)
        {
            GameObject o = (GameObject)listItems[0];
            DragDropScript dds = o.GetComponent<DragDropScript>();
            if (dds == null)
            {
                DragDropMulScript ddms = o.GetComponent<DragDropMulScript>();
                if (ddms != null)
                   ddms.resetPosition();
                else
                    continue;
            }
            else
                dds.resetPosition();
            removeItem(o);
        }
    }

    public bool isCorrect(NameCorrectionStruct ncs)
    {
        if (ncs.table.Count != this.listItems.Count)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":WARNING:\n"
           + "The correction for the body box doesn't have the right number of arguments:\n"
           + "correct: " + ncs.table.Count + " / current: " + this.listItems.Count);
            return false;
        }
        //get the names of all the things inside our big box and add them to a List that we'll sort:
        List<string> names_currently_inside = getListAsNameList();
        // sort this list
        names_currently_inside.Sort();
        //check one by one the content
        for (int i = 0; i < ncs.table.Count; i++)
        {

            if (!names_currently_inside[i].Equals(ncs.table[i]))
            {
                print("--> failed comparing:" + names_currently_inside[i] + " and: " + ncs.table[i]);
                return false;
            }
        }
        return true;
    }

    public BigBoxScript()
    {
        listItems = new ArrayList();
    }

    public ArrayList getList()
    {
        return listItems;
    }

    public List<string> getListAsNameList()
    {
        List<string> names_currently_inside = new List<string>();
        foreach (GameObject s in this.listItems)
        {
            names_currently_inside.Add(s.name);
        }
        return names_currently_inside;
    }

    private void Awake()
    {
        Collider2D col = this.gameObject.GetComponent<Collider2D>();
        float y = col.bounds.size.y;
        nextPos = transform.position+new Vector3(0,y/2-0.3f,-1);
        listItems = new ArrayList();


    }

    public virtual void addItem(GameObject gobj)
    {
        listItems.Add(gobj);
        //gobj.transform.SetParent(this.transform);
        gobj.transform.position = nextPos+offset;

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
        //print("REMOVE: "+gobj.name+" from "+this.name+":"+this.GetInstanceID());
        int i = listItems.IndexOf(gobj);
        if (i < 0)
            print("item  " + gobj.name + " not found in array" + " from " + this.name + ":" + this.GetInstanceID());
        else
        {
            float num = 0f;
            DragDropScript dds = gobj.GetComponent<DragDropScript>();
            if (dds == null)
            {
                DragDropMulScript ddms = gobj.GetComponent<DragDropMulScript>();
                if (ddms != null)
                    num = ddms.getHeight();
                else
                    return;
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
            
        }
        
    }

    void OnMouseDown()
    {
        //print("onmousedown bbs!");
        //print(" from " + this.name + ":" + this.GetInstanceID());
    }
}
