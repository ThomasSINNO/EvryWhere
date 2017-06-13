using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogscript : MonoBehaviour {

    public List<Sprite> listspr;
    SpriteRenderer sprr;
    int i;
    public int size;

    void Start () {
        //listspr[0] = Resources.Load("dialogs/bulle1") as Sprite;
        //listspr[1] = Resources.Load<Sprite>("dialogs/bulle2");
        //listspr[2] = Resources.Load<Sprite>("dialogs/bulle3");
        //listspr[3] = Resources.Load<Sprite>("dialogs/bulle4");
        //listspr[4] = Resources.Load<Sprite>("dialogs/bulle5");

        sprr = this.gameObject.GetComponent<SpriteRenderer>();
        sprr.sprite = listspr[0];
        i = 0;
    }

    private void OnMouseDown()
    {
        if (i < size-1)
        {
            i++;
            sprr.sprite = listspr[i];
        } else
        {
            Destroy(this.gameObject);
        }
        
    }

}
