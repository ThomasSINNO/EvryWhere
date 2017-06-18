using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameBoxScript : BigBoxScript {

    bool isFree;
   

    public string getName()
    {
        List<string> l = this.getListAsNameList();
        if (l.Count != 1)
        {
            CorrectionManagerScript.addLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
              + this.gameObject.name + " :There is not one and only one name inside this nameboxscript");
           // print("getName() on "+this.gameObject.name+" => returns \"\"");
            return "";
        }
        //print("getName() " + this.gameObject.name + "=> returns " + debug_name);
        return l[0];
    }


    // Use this for initialization
    void Awake () {
        isFree = true;
        nextPos = transform.position;
	}


    private void Start()
    {
        isFree = true;

        nextPos = transform.position;
    }

    public override void addItem(GameObject gobj)
    {
        if (isFree)
        {
            base.addItem(gobj);
            isFree = false;
        }

        else
        {
            GameObject i = (GameObject)listItems[0];
            base.removeItem(i);
            DragDropScript dds = i.GetComponent<DragDropScript>();
            if (!dds)
            {
                DragDropMulScript ddms = i.GetComponent<DragDropMulScript>();
                if (!ddms)
                {
                    print("erreur getcomponent");
                } else
                {
                    ddms.resetPosition();
                }
            } else
            {
                dds.resetPosition();
            }
            base.addItem(gobj);
        }
    }

    public override void removeItem(GameObject gobj)
    {
        base.removeItem(gobj);
        isFree = true;
    }
    
}
