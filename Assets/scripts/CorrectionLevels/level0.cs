using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level0 : MonoBehaviour
{
    static bool active;
    CorrectionContainer cc;
    CorrectionManagerScript cms;
    GameObject success;
    GameObject failure;

    public static void activate(bool b)
    {
        active = b;
    }
    // Use this for initialization
    void Start()
    {
        active = false;
        success = GameObject.Find("Success");
        failure = GameObject.Find("Failure");
        cc = new CorrectionContainer();
        cc.level_name = "level0";

        int i = 0, j = 0;
        cc.table.Add(new TagCorrectionsStruct());
        cc.table[0].tag = "ParentBoxTag";

        cc.table[i].table.Add(new NameCorrectionStruct());
        cc.table[i].table[j].name = "Sejour";
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("CodeSejour");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("DateDepart");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Duree");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Destination");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("PrixParPersonne");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NbPlaceMax");

        j++;
        cc.table[i].table.Add(new NameCorrectionStruct());
        cc.table[i].table[j].name = "Client";
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NumeroClient");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NomClient");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("PrenomClient");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("DateDeNaisCl");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Adresse");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("CodePostal");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Ville");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Telephone");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Pays");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("Mail");


        j++;
        cc.table[i].table.Add(new NameCorrectionStruct());
        cc.table[i].table[j].name = "Accompagnant";
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("IdAccomp");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NomAccomp");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("PrenomAccomp");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("DateDeNaisAc");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NationaliteAc");


        j++;
        cc.table[i].table.Add(new NameCorrectionStruct());
        cc.table[i].table[j].name = "Reservation";
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("NbPersonnes");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("DateReservation");
        ((NameCorrectionStruct)cc.table[i].table[j]).table.Add("TauxRemise");

        i++; j = 0;

        cc.table.Add(new TagCorrectionsStruct());
        cc.table[i].tag = "ParentArrowTag";
        ArrowCorrectionStruct current = null;

        //a simple arrow between 2 boxes
        cc.table[i].table.Add(new ArrowCorrectionStruct());
        cc.table[i].table[j].name = "";
        current = (ArrowCorrectionStruct)cc.table[i].table[j];
        current.name_start = "Client";
        current.name_end = "Sejour";
        current.multiplicity_start = "Etoile";
        current.multiplicity_end = "Etoile";
        j++;

        //a simple arrow between 2 boxes
        cc.table[i].table.Add(new ArrowCorrectionStruct());
        cc.table[i].table[j].name = "";
        current = (ArrowCorrectionStruct)cc.table[i].table[j];
        current.name_start = "Accompagnant";
        current.name_end = "Client";
        current.multiplicity_start = "Etoile";
        j++;

        //an association class : note that only the point of view of the association class is here and it will check EVERYTHING
        // /!\NO a simple arrow between 2 boxes to be put for the link on which the assocaition class stands
        cc.table[i].table.Add(new ArrowCorrectionStruct());
        cc.table[i].table[j].name = "";
        current = (ArrowCorrectionStruct)cc.table[i].table[j];
        current.name_start = "Reservation";
        current.name_end = "";
        current.middle_link_to_arrow_start = "Client";
        current.middle_link_to_arrow_end = "Sejour";
        j++;

        cms = this.gameObject.GetComponent<CorrectionManagerScript>();
        if (cms == null)
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "Could not find the CorrectionManagerScript on the item with the level0 script");
            return;
        }
        if (!cms.loadCorrection(cc))
        {
            print(System.Reflection.MethodBase.GetCurrentMethod().Name + ":ERROR:\n"
                    + "Load correction failure");
            return;
        }
        print("Level0 OK");
    }

    //void OnMouseDown()
    //{
    //    bool r = cms.isCorrect();
    //    print("=============>Is correct: " + (r ? "true" : "false"));
    //}
    public int place;
    public int offset;
    public int width;
    public int height;

    void OnGUI()
    {
        int buttonWidth = width;
        int buttonHeight = height;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            new Rect(
              10,
              (Screen.height) - place*((buttonHeight) +offset),
              buttonWidth,
              buttonHeight
            ),
            "Correction"
          )
        )
        {
            //print(((ArrowCorrectionStruct)cc.table[0].table[0]).dump());

            if (!active)
            {

                bool r = cms.isCorrect();
                if (r)
                {
                    GameObject suc = GameObject.Instantiate(success);
                    suc.transform.position = new Vector3(0, 0, 0);
                    reunion1script.haspassedumllvl1 = true;
                }
                else
                {
                    GameObject fl = GameObject.Instantiate(failure);
                    fl.transform.position = new Vector3(0, 0, 0);
                }
                CorrectionManagerScript.addLog("=============>Is correct: " + (r ? "true" : "false"));
                CorrectionManagerScript.printStaticLog();
                print("=============>Is correct: " + (r ? "true" : "false"));
                activate(true);
            }
        }
    }
}