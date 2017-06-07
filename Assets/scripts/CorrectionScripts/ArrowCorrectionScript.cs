using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCorrectionScript : MonoBehaviour {

    public bool isCorrect(ArrowCorrectionStruct acs)
    {
        //let's get our children
        GameObject start, middle, end;
        start = this.transform.Find("depart").gameObject;
        middle = this.transform.Find("milieu").gameObject;
        end = this.transform.Find("arrivee").gameObject;
        if (start == null || middle == null || end == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The ArrowCorrectionScript doesn't have \"depart\" and/or \"milieu\" and/or \"arrivee\" child");
            return false;
        }
        //then their scripts


        //let's get all the arguments
        ArrowCorrectionStruct current_args = new ArrowCorrectionStruct();
        current_args.name_start ="";
        current_args.name_end ="";
        current_args.type_arrow = "";
        current_args.multiplicity_end ="";
        current_args.multiplicity_start ="";
        current_args.middle_link_to_arrow_end ="";
        current_args.middle_link_to_arrow_start = "";

        return current_args.Equals(acs);
    }
}
