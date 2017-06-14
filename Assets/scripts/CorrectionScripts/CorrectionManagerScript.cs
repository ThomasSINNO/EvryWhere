using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface CorrectionOfTagInterface
{
    bool isCorrect(TagCorrectionsStruct tcs);
}

public class CorrectionManagerScript : MonoBehaviour
{
    protected static string static_log;

    static CorrectionManagerScript()
    {
        static_log = "";
    }

    public static void addLog(string to_add)
    {
        static_log += "\n" + to_add;
    } 
    public static string getStaticLog()
    {
        return static_log;
    }
    public static void printStaticLog()
    {
        print(static_log);
        static_log = "";
    }

    private CorrectionContainer cc;
    // Use this for initialization
    void Awake()
    {
        cc = null;
        print("CMS AWAKE!");
    }

    public bool loadCorrection(CorrectionContainer cc_)
    {
        if (cc_ == null || cc_.table == null || cc_.level_name.Equals("") || cc_.table.Count <= 0)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "Trying to load a malformed container");
            return false;
        }
        cc = cc_;
        //we have to sort the table of the NameCorrectionStruct which is located in the table of the tag ParentBoxTag
        //first we have to find this table with the tag ParentBoxTag
        foreach (TagCorrectionsStruct tcs in cc.table)
        {
            if (tcs == null || tcs.tag.Equals(""))
            {
                print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                        + "TagCorrectionStruct not set or has empty tag name");
                return false;
            }
            else if (tcs.tag.Equals("ParentBoxTag"))
            {
                // now we check it, then we sort it
                foreach (LastLevelCorrectionStruct llcs in tcs.table)
                {
                    NameCorrectionStruct ncs = (NameCorrectionStruct)llcs;
                    if ((ncs.table == null || ncs.table.Count <= 0))
                    {
                        print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                                + "Trying to sort a malformed table inside ParentBoxTag");
                        return false;
                    }
                    ncs.table.Sort();
                }
                break;
            }
        }
        //  print("name=" + cc.level_name + " table.tag= " + cc.table[0].tag);
        return true;
    }
    public CorrectionContainer getCorrection()
    {
        return cc;
    }

    public bool isCorrect()
    {
        if (cc == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                                   + "CC==null !!!");
            return false;
        }
        if (cc.table == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                                   + "CC.table==null !!!");
            return false;
        }
        bool r = (cc.table.Count > 0);
        CorrectionContainer cc_copy = new CorrectionContainer(cc);//copy because our functions are going to modify it !
        foreach (TagCorrectionsStruct tcs in cc_copy.table)
        {
            r = r & isCorrectTag(tcs);
            if (!r)
                return false;
        }
        if (r)
            cc.is_correct = true;
        return r;
    }


    private bool isCorrectTag(TagCorrectionsStruct tcs)
    {

        //stupid error checking
        if (tcs == null || tcs.tag.Equals(""))
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "TagCorrectionStruct not set or has empty tag name");
            return false;
        }
        else if (tcs.is_correct)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":WARNING/ERROR:\n"
                                + "TagCorrectionStruct " + tcs.tag + " has already been completed => double !");
            return false;
        }

        //search for our tagged name
        GameObject[] tagged_array = GameObject.FindGameObjectsWithTag(tcs.tag);
        if (tagged_array == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "No objects tagged with : " + tcs.tag);
            return false;
        }

        if (tagged_array.Length != tcs.table.Count)
        {
            CorrectionManagerScript.addLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":LOG:\n"
                    + "For the tag: " + tcs.tag + " number of objects mismatch: currently:" + tagged_array.Length + " needed:" + tcs.table.Count);
            return false;
        }
        CorrectionManagerScript.addLog("TAGGED LENGTH: " + tagged_array.Length);
        // we will pass to each object the struct will all the corrections for this type of tag and each will modify it (say if its content is ok)
        bool r = (tagged_array.Length > 0);
        foreach (GameObject go in tagged_array)
        {
            CorrectionOfTagInterface correction = go.GetComponent<CorrectionOfTagInterface>();
            if (correction == null)
            {
                print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                   + "Object tagged as : " + tcs.tag + " has no CorrectionOfTagInterface script attached");
                return false;
            }
            r = r & correction.isCorrect(tcs);// logical ANDing

            CorrectionManagerScript.addLog("current tagged object==>Is correct: " + (r ? "true" : "false"));
            if (r == false)//to skip the correction process of the rest of this tag
                return false;
        }
        CorrectionManagerScript.addLog("TAG:"+ tcs.tag +" ======>Is correct: " + (r ? "true" : "false"));
        if (r == true)
            tcs.is_correct = true;
        return r;
    }

}