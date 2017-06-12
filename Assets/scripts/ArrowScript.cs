using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowScript : MonoBehaviour {
    
    public typearrow type;
    public GameObject depart;
    public GameObject arrivee;
    public GameObject multdep;
    public GameObject multarr;

    public bool is_between_2_boxes;
    private bool has_midpoint_attached;

    public ArrowCorrectionStruct getCorrectionStruct()
    {
        
        is_between_2_boxes = true;
        ArrowCorrectionStruct r = new ArrowCorrectionStruct();
        if (depart == null || arrivee == null)
        {
            //print("depart/arrivee");
            return r;
        }
        ArrowScript s_arrow_script = depart.GetComponent<ArrowScript>();
        ArrowScript e_arrow_script = arrivee.GetComponent<ArrowScript>();

        //----------type gestion
        r.type_arrow = this.type;

        //----------start gestion
        //simple case
        if (s_arrow_script == null)
        {
            //print("s_arrow_script == nul");
            CorrectionOfParentBoxTagScript s_script = depart.GetComponent<CorrectionOfParentBoxTagScript>();
            if (s_script == null)
                return r;
            r.name_start = s_script.getName();
        }
            //association class
        else
        {
            //print("s_arrow_script != nul");
            ArrowCorrectionStruct ends_of_second_arrow = s_arrow_script.getCorrectionStruct();
            r.middle_link_to_arrow_start = ends_of_second_arrow.name_start;
            r.middle_link_to_arrow_end = ends_of_second_arrow.name_end;
            //print("Start=arrow!");           
            is_between_2_boxes = false;
        }
        //----------end gestion
            //simple case
        if (e_arrow_script == null)
        {
            //print("e_arrow_script == nul");
            CorrectionOfParentBoxTagScript e_script = arrivee.GetComponent<CorrectionOfParentBoxTagScript>();
            if (e_script == null)
                return r;
            r.name_end = e_script.getName();
        }
            //association class
        else
        {
            //print("e_arrow_script != nul");
            ArrowCorrectionStruct ends_of_second_arrow = e_arrow_script.getCorrectionStruct();
            r.middle_link_to_arrow_start = ends_of_second_arrow.name_start;
            r.middle_link_to_arrow_end = ends_of_second_arrow.name_end;
            //print("end=arrow!");
            if (!is_between_2_boxes)
            {
                print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
               + "An arrow is placed between 2 other arrows, this is not supported");
                return new ArrowCorrectionStruct(); ;
            }
            is_between_2_boxes = false;
        }

        //Multiplicity gestion
        GameObject go_mul_s = this.gameObject.transform.Find("depart").gameObject;
        GameObject go_mul_e = this.gameObject.transform.Find("arrivee").gameObject;
        if (go_mul_s == null || go_mul_e == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "Can't find the depart and arrivee children of the arrow");
            return r;
        }
        NameBoxScript s_namebox_script = go_mul_s.GetComponent<NameBoxScript>();
        NameBoxScript e_namebox_script = go_mul_e.GetComponent<NameBoxScript>();

        if (s_namebox_script == null  || e_namebox_script == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "One of the start(depart)/end(arrivee) children of the arrow doesn't have a namebox script attached");
            return r;
        }
        //get the name of the namebox
        r.multiplicity_start = s_namebox_script.getName();
        r.multiplicity_end = e_namebox_script.getName();

        return r;
    }

    public bool getHasMidpointAttached()
    {
        return has_midpoint_attached;
    }

    private void Awake()
    {
        //print("AS Awake called! ");
        type = typearrow.UNDEF;
        depart = null;
        arrivee = null;
        multdep = null;
        multarr = null;
        is_between_2_boxes=true;
        has_midpoint_attached = false;
    }

    public void setMidPointAttached(bool b)
    {
        has_midpoint_attached = b;
        if (b)
            this.gameObject.tag = "Untagged";//remove the tag if we are attached
        else
            this.gameObject.tag = "ParentArrowTag";
    }
    public void addMultiplicityStart(GameObject d)
    {
        multdep = d;
    }
    public void addMultiplicityEnd(GameObject d)
    {
        multarr = d;
    }

    public void setArrowProperties(typearrow t,GameObject d,GameObject a)
    {
        type = t;
        depart = d;
        arrivee = a;
        string dump = getCorrectionStruct().dump();
        //print("DUMP:\n"+dump );//to set is_between_2_boxes
    }

    public void deleteArrow()
    {
        Destroy(this.gameObject);
    }
    
}
