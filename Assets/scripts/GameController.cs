using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    // list of variables
    public static GameController instance;
    public GameObject gameOverText; // attach this script to the text
    public Text scoreText; // text for score
    public bool gameOver = false;
    public float scrollSpeed = -1.5f; // scrolling speed
    private int score = 0; // initialize score

	// Use this for initialization
    // awake called before start
	void Awake () {
		if (instance == null) {
            instance = this; // this is the script itself
        } else if (instance != this) {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // load current level again
            
        }
	}

    // when bird died
    public void birdDied()
    {
        gameOverText.SetActive(true); // enable game over UI
        gameOver = true; // now game ended

    }

    // add score when passing columns
    public void birdScored() {
        if (gameOver) {
            return; // if game is over, don't do anything
        }

        score += 1; // add to score
        scoreText.text = "Score: "+ score.ToString(); // display score
    }
}
