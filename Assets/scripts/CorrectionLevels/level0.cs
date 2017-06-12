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
        /*
        cc.table.Add(new TagCorrectionsStruct());
        cc.table[i].tag = "ParentBoxTag";

            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "Duree";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Ville");
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NbPlaceMax");

            j++;
            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "Telephone";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Reservation");
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Mail");

            j++;
            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "Pays";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NomClient");

            j++;
            cc.table[i].table.Add(new NameCorrectionStruct());
            cc.table[i].table[j].name = "DateDepart";
                ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("CodePostal");

        i++; j = 0;
        */
        cc.table.Add(new TagCorrectionsStruct());        
        cc.table[i].tag = "ParentArrowTag";
        ArrowCorrectionStruct current = null;

            //a simple arrow between 2 boxes
            cc.table[i].table.Add(new ArrowCorrectionStruct());
            cc.table[i].table[j].name = "";
            current = (ArrowCorrectionStruct)cc.table[i].table[j];
                current.name_start = "Duree";
                current.name_end = "Telephone";
                current.multiplicity_start = "Destination";
            j++;
        /*
            //a simple arrow between 2 boxes
            cc.table[i].table.Add(new ArrowCorrectionStruct());
            cc.table[i].table[j].name = "";
            current = (ArrowCorrectionStruct)cc.table[i].table[j];
                current.name_start = "Duree";
                current.name_end = "Pays";
            j++;
*/
            //an association class : note that only the point of view of the association class is here and it will check EVERYTHING
            // /!\NO a simple arrow between 2 boxes to be put for the link on which the assocaition class stands
            cc.table[i].table.Add(new ArrowCorrectionStruct());
            cc.table[i].table[j].name = "";
            current = (ArrowCorrectionStruct)cc.table[i].table[j];
                current.name_start = "Pays";
                current.name_end = "";
                current.middle_link_to_arrow_start = "Telephone";
                current.middle_link_to_arrow_end = "DateDepart";
            j++;

    
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
