using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        // check if overlapped with bird
        if(other.GetComponent<bird>() != null) {
            GameController.instance.birdScored(); 
        }
    }
}
