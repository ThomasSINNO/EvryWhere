using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0 : MonoBehaviour {
    CorrectionContainer cc;
    CorrectionManagerScript cms;
    // Use this for initialization
    void Start () {

        cc = new CorrectionContainer();
        cc.level_name = "level0";

        int i=0, j = 0;
        cc.table.Add(new TagCorrectionsStruct());
        cc.table[0].tag = "ParentBoxTag";

            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "Duree";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Ville");
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NbPlaceMax");

            j++;
            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "Telephone";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Reservation");
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Pays");

        cms = this.gameObject.GetComponent<CorrectionManagerScript>();
        if(cms == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "Could not find the CorrectionManagerScript on the item with the level0 script");
            return;
        }
        if(!cms.loadCorrection(cc))
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "Load correction failure");
            return;
        }
        print("Level0 OK");
    }
	
	void OnMouseDown()
    {
        bool r=cms.isCorrect();
        print("=============>Is correct: " + (r ? "true" : "false"));
    }
}
