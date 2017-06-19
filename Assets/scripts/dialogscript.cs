using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogscript : MonoBehaviour {

    public List<Sprite> listspr;
    SpriteRenderer sprr;
    int i;
    public int size;

    void Start () {
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
            consignesuml1script.setboolcons(false);
        }
        
    }

}
