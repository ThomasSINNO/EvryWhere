using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionOfParentBoxTagScript : MonoBehaviour, CorrectionOfTagInterface
{
    public bool isCorrect(TagCorrectionsStruct tcs)
    {
        //start by checking the children and that they have the good type of scripts attached
        GameObject name_, body_;
        name_ = this.transform.Find("name").gameObject;
        body_ = this.transform.Find("body").gameObject;
        if (name_ == null || body_ == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The CorrectionOfParentBoxTag doesn't have \"name\" and/or \"body\" child");
            return false;
        }
        NameBoxScript name_script = name_.GetComponent<NameBoxScript>();
        BigBoxScript body_script = body_.GetComponent<BigBoxScript>();
        if (name_script == null || body_script == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The \"name\" and/or \"body\" children of CorrectionOfParentBoxTag don't have the right script attached");
            return false;
        }
        //get the name of the namebox
        ArrayList al = name_script.getList();
        if (al.Count != 1 || ((GameObject)al[0]).name.Equals(""))
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                 + "The \"name\"child of CorrectionOfParentBoxTag doesn't has listItems.Count!=1");
            return false;
        }
        string name_of_box = ((GameObject)al[0]).name;
        //we find the corresponding name in the tcs
        LastLevelCorrectionStruct good_correction_container = null;
        foreach (LastLevelCorrectionStruct possible_correction_container in tcs.table)
        {
            if (possible_correction_container.name.Equals(name_of_box))
            {
                good_correction_container = possible_correction_container;
                break;
            }
        }
        if (good_correction_container == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
             + "Couldn't find the name of the box: " + name_of_box + " in the correction table for the tag: " + tcs.tag);
            return false;
        }
        else if (good_correction_container.is_correct)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":WARNING/ERROR:\n"
            + "The correction with name: " + name_of_box + " for the tag: " + tcs.tag + " has already been completed => double somewhere");
            return false;
        }
        else if (((NameCorrectionStruct)good_correction_container).table == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":WARNING/ERROR:\n"
            + "The correction with name: " + name_of_box + " for the tag: " + tcs.tag + " has an empty correction table");
            return false;
        }

        if (body_script.isCorrect((NameCorrectionStruct)good_correction_container))
        {
            //if everything is fine, we have to put is_correct to true and return true
            good_correction_container.is_correct = true;
            //print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
           //+ "The correction with name: " + name_of_box + " for the tag: " + tcs.tag + " is correct !");
            return true;
        }
        return false;
    }
}
