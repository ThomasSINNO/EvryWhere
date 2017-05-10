using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class droptitlescript : MonoBehaviour {

    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;
    private NameCollider coll;
    private Vector3 pos = new Vector3(0,0,0);

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision");
    }


    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;

                }
            }
        }
    }

    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }

    void DropItem()
    {
        draggingItem = false;
        GameObject nc = GameObject.Find("boite1/namecollider");
      

    }

    void Update()
    {
        if (HasInput)
        {
            DragOrPickUp();
        }
        else
        {
            if (draggingItem) DropItem();
        }
    }

}
