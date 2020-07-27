using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyObject;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnenemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnenemies()
    {
        Instantiate(enemyObject, CreateRandomSpawnLocation(), transform.rotation);
        yield return new WaitForSeconds(2);
        StartCoroutine(spawnenemies());
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
        Vector3 spawnPos = new Vector3(0,0,0);

        while (!acceptedLocation)
        {
            spawnPos = new Vector3(Random.Range(eastLimit, westLimit),
                                            0.2f,
                                            Random.Range(southLimit, northLimit));
            if(Vector3.Distance(doorPosition,spawnPos) > 10)
            {
                acceptedLocation = true;
            }
        }

        return spawnPos;
    }
}
