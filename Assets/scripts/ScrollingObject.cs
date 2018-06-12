using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    // list of variables
    private Rigidbody2D rb2d; // a private rigidbody 2d variable

	
    // Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // assign the component's rigidbody to rb2d
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed,0); // set velocity
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver){
            // if game over
            rb2d.velocity = Vector2.zero; // set speed to 0
        }
	}
}
