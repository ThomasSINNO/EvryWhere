using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum typearrow
{
    LINK,AGGREG,COMPO,ASSO,HERIT,UNDEF
};
public class FlecheScript : MonoBehaviour {


    protected List<GameObject> tab;
    protected typearrow type;

    protected bool isActive;

    protected GameObject arrow;
	// Use this for initialization
	void Start () {
        isActive = false;
        tab = new List<GameObject>();
        arrow = GameObject.Find("Arrow");
        type = typearrow.UNDEF;
        gameObject.tag = "ArrowButton";
    }

    static public GameObject[] getrects()
    {
        return(GameObject.FindGameObjectsWithTag("ArrowHitbox"));
    }

    static public GameObject[] getarrowbuttons()
    {
        return (GameObject.FindGameObjectsWithTag("ArrowButton"));
    }

    private void OnMouseDown()
    {
        GameObject[] buttons = getarrowbuttons();
        foreach(GameObject b in buttons)
        {
            if (this.gameObject != b)
            {
                b.GetComponent<FlecheScript>().ResetArrow();
            }
            
        }
        GameObject[] targets = getrects();
        foreach (GameObject gobj in targets)
        {
            if (!isActive)
            {
                gobj.GetComponent<ArrowHitboxScript>().Activate(this.gameObject);
            } else
            {
                gobj.GetComponent<ArrowHitboxScript>().Deactivate();
            }
            
        }
        if (!isActive)
        {
            isActive = true;

        } else
        {
            isActive = false;
        }
        
    }

    public void ResetArrow()
    {
        tab = new List<GameObject>();
        isActive = false;
    }

    

    public void EndArrow(GameObject g)
    {
        if (g == null)
        {
            print("g null");
        }
        tab.Add(g);
        if (tab.Count > 1)
        {

            GameObject newArrow = GameObject.Instantiate(arrow);
            print("instantiate arrow !");
            newArrow.transform.position = new Vector3(0f, 0f, 0f);

            GameObject dep = newArrow.transform.Find("depart").gameObject;
            dep.transform.position = tab[0].transform.position;
            SpriteRenderer rend1 = dep.gameObject.GetComponent<SpriteRenderer>();
            rend1.color = Color.green;
            print("Instantiate dep !");

            GameObject arr = newArrow.transform.Find("arrivee").gameObject;
            arr.transform.position = tab[1].transform.position;
            SpriteRenderer rend2 = arr.gameObject.GetComponent<SpriteRenderer>();
            rend2.color = Color.blue;

            GameObject mid = newArrow.transform.Find("milieu").gameObject;
            float x = (dep.transform.position.x + arr.transform.position.x) / 2;
            float y = (dep.transform.position.y + arr.transform.position.y) / 2;
            float z = (dep.transform.position.z + arr.transform.position.z) / 2;
            mid.transform.position = new Vector3(x, y, z);
            SpriteRenderer rend3 = mid.gameObject.GetComponent<SpriteRenderer>();
            rend3.color = Color.magenta;

            GameObject[] targets = getrects();
            foreach (GameObject gobj in targets)
                    gobj.GetComponent<ArrowHitboxScript>().Deactivate();
            ResetArrow();
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
