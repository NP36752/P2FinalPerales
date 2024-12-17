using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public int pipePoolSize = 5;
    public GameObject pipePrefab;
    public float spawnRate = 4f;
    public float pipeMin = -1f;
    public float pipeMax = 3.5f;

    private GameObject[] pipes;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentPipe = 0;


    void Start()
    {
        pipes = new GameObject[pipePoolSize];
        for (int i = 0; i < pipePoolSize; i++)
        {
            pipes[i] = (GameObject) Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.Instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (pipeMin, pipeMax);
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPipe++;
            if (currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
}
 