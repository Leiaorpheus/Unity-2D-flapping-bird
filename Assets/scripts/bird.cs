using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {
    private bool isDead = false; // whether player is dead
    private Rigidbody2D rb; // another ridgid body
    public float upForce = 200f; // momentum
    private Animator anim; // animator
    private const string flap = "Flap";
    private const string die = "Die";

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>(); // store ridigbody into rb
        anim = GetComponent<Animator>(); // get the animator component attached to bird 
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
            if (Input.GetMouseButtonDown(0)) {
                // if right clicked, give it a rigidbody, start moving
                rb.velocity = Vector2.zero; // no velocity at all short cut for (0,0)
                rb.AddForce(new Vector2(0, upForce)); // new impulse, 0 at x, 200 at y, so only move up and down
                anim.SetTrigger(flap);
            }
        }
	}

    // check collision, this is a bulid-in API function serves as an event-listener
    void OnCollisionEnter2D(){
        rb.velocity = Vector2.zero; // when collide with background, set velocity to 0 in both directions
        isDead = true; // if hit something, then die
        anim.SetTrigger(die);
        GameController.instance.birdDied();
    }
}
