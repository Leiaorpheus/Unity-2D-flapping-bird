using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < - groundHorizontalLength) {
            Debug.Log("The position before is: " + transform.position.x);
            RepositionBackground();
            
        } else {
            Debug.Log("Now: " + transform.position.x);
        }
		
	}

    private void RepositionBackground() {
        Vector2 groundoffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundoffset;
        Debug.Log(transform.position);

    }
}
