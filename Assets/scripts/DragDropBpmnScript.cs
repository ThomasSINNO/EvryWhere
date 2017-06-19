using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBpmnScript : DragDropScript {

	// Use this for initialization
	void Start () {
        box_collider = this.gameObject.GetComponent<BoxCollider2D>();
        if (box_collider == null)
        {
            print("ERROR:could not find box colldier on drag drop script");
            return;
        }
        initial_box_colldier_size = box_collider.size;
        short_box_colldier_size = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public override void resetPosition()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}
}
