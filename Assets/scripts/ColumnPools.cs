using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPools : MonoBehaviour
{
    public int columnPoolSize = 5; // initialize array size
    private GameObject[] columns; // array of columns
    public GameObject columnPrefab; // create prefab variable to put prefabs inside
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); // putting object pool in somewhere user cannot see

    private float timeSinceLastSpawned; // time passed
    public float spawnRate = 4f; // how often position a new column

    // randomized column ys
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private float spawnXPosition = 10f; // spawn x position
    private int currentColumn = 0; // current column number

    // Use this for initialization
    void Start()
    {
        // setting up object pool
        columns = new GameObject[columnPoolSize]; // initialize array size to be 5

        // fill the array with prefabs
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity); // assign each array element a prefab
        }

    }

    // Update is called once per frame
    void Update()
    {

        // check whether is time to spawn new columns
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0; // set time back to 0
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); // generate fixed x coordinate and random y coordinate
            currentColumn++; // add one to current column

            // restart columns and prevent index out of range when column is fulled
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0; // reset current column
            }

        }
    }
}

