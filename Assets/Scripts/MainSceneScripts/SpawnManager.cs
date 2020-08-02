using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyObject;
    private GameManager gameManager;
    public GameObject placedWall;
    public Camera upCamera;
    private bool isSpawning;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(spawnenemies(gameManager.level));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning && !gameManager.planningMode)
        {
            StartCoroutine(spawnenemies(gameManager.level));
            isSpawning = true;
        }
    }

    public IEnumerator spawnenemies(int level)
    {
        if (!gameManager.planningMode)
        {
            float interval = Random.Range(1 - 0.1f * 1 / level, Random.Range(1, 3));
            int spawnAmount = (int)Random.Range(1, level);

            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate(enemyObject, CreateRandomSpawnLocation(), transform.rotation);
            }
            yield return new WaitForSeconds(interval);
            StartCoroutine(spawnenemies(gameManager.level));
        }
        else
        {
            isSpawning = false;
        }
    }


    private Vector3 CreateRandomSpawnLocation()
    {
        // Get the spawn area limits
        float eastLimit = GameObject.Find("WallE").transform.position.x;
        float westLimit = GameObject.Find("WallW").transform.position.x;
        float northLimit = GameObject.Find("WallN").transform.position.z;
        float southLimit = GameObject.Find("WallS").transform.position.z;

        // Get the door position
        Vector3 doorPosition = GameObject.Find("Door").transform.position;

        // Generate spawn location that is under allowed area
        bool acceptedLocation = false;
        Vector3 spawnPos = new Vector3(0, 0, 0);

        while (!acceptedLocation)
        {
            spawnPos = new Vector3(Random.Range(eastLimit, westLimit),
                                            0.2f,
                                            Random.Range(southLimit, northLimit));
            if (Vector3.Distance(doorPosition, spawnPos) > 10)
            {
                acceptedLocation = true;
            }
        }

        return spawnPos;
    }

    // Method for spawning wall obstacle on mouse location
    public void spawnWallOnMouseLocation()
    {
        Instantiate(placedWall, getMouseLocation(), transform.rotation);
    }

    // Method for getting relative mouse location
    public Vector3 getMouseLocation()
    {
        Vector3 mouseLocation;
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = upCamera.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            mouseLocation = hit.point;
            return mouseLocation;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }


    }
}
