using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCorrectionScript : MonoBehaviour, CorrectionOfTagInterface
{
    protected bool isCorrect(ArrowCorrectionStruct acs)
    {
        //let's get all our argument arguments
        ArrowScript AS = this.gameObject.GetComponent<ArrowScript>();
        if (AS == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
           + "the arrow doesn't have an ArrowScript attached to get the values we need");
            return false;
        }
        ArrowCorrectionStruct current_args = AS.getCorrectionStruct();
        CorrectionManagerScript.addLog("Comparing:\n->Mine:\n" + current_args.dump() + "AND:\n->Correction\n" + acs.dump());
        bool r= current_args.Equals(acs);
        CorrectionManagerScript.addLog("==>Result: " + r);
        return r;
    }

    public bool isCorrect(TagCorrectionsStruct tcs)
    {
        ArrowScript AS = this.gameObject.GetComponent<ArrowScript>();
        if (AS == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
           + "the arrow doesn't have an ArrowScript attached to get the values we need");
            return false;
        }
        foreach (LastLevelCorrectionStruct llcs in tcs.table)
        {
            if (!llcs.is_correct)
            {
                ArrowCorrectionStruct acs = (ArrowCorrectionStruct)llcs;
                if (isCorrect(acs))
                {
                    acs.is_correct = true;
                    return true;
                }
            }
        }
        return false;
    }
}
