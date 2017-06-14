using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionOfParentBoxTagScript : MonoBehaviour, CorrectionOfTagInterface
{

    public string getName()
    {
        string r = "";

        NameBoxScript name_script = this.getNameBoxScript();
        if (name_script == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The \"name\" child of CorrectionOfParentBoxTag doesn't have the right script attached");
            return r;
        }
        //get the name of the namebox

        return name_script.getName();

    }

    public List<string> getNamesInside()
    {
        List<string> r = new List<string>();
        BigBoxScript body_script = getBigBoxScript();
        if (body_script == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The \"body\" children of CorrectionOfParentBoxTag doesn't have the right script attached");
            return r;
        }
        return body_script.getListAsNameList();
    }

    public BigBoxScript getBigBoxScript()
    {
        GameObject body_;
        body_ = this.transform.Find("body").gameObject;
        if (body_ == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The CorrectionOfParentBoxTag doesn't have a \"body\" child");
            return null;
        }
        return body_.GetComponent<BigBoxScript>();
    }


    public NameBoxScript getNameBoxScript()
    {
        GameObject name_;
        name_ = this.transform.Find("name").gameObject;
        if (name_ == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The CorrectionOfParentBoxTag doesn't have a \"name\"child");
            return null;
        }
        return name_.GetComponent<NameBoxScript>();
    }


    public bool isCorrect(TagCorrectionsStruct tcs)
    {
        //start by checking the children and that they have the good type of scripts attached

        //get the name of the namebox

        string name_of_box = getName();
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
            CorrectionManagerScript.addLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
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

        //get the big box script
        BigBoxScript body_script = getBigBoxScript();
        if (body_script == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                  + "The \"body\" children of CorrectionOfParentBoxTag doesn't have the right script attached");
            return false;
        }

        if (body_script.isCorrect((NameCorrectionStruct)good_correction_container))
        {
            //if everything is fine, we have to put is_correct to true and return true
            good_correction_container.is_correct = true;
            CorrectionManagerScript.addLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
            + "The correction with name: " + name_of_box + " for the tag: " + tcs.tag + " is correct !");
            return true;
        }
        CorrectionManagerScript.addLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
            + "The correction with name: " + name_of_box + " for the tag: " + tcs.tag + " is false !");
        return false;
    }
}

