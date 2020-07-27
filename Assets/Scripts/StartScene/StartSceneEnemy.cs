using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneEnemy : MonoBehaviour
{
    GameObject mouseLocationObject;
    Rigidbody enemyRb;
    private float jumpForce = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        mouseLocationObject = GameObject.Find("MouseObject");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.rotation = Quaternion.LookRotation(mouseLocationObject.transform.position.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MouseCube"){
            enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnMouseDown()
    {
        Instantiate(gameObject, CreateRandomSpawnLocationMenu(),transform.rotation);
    }

    private Vector3 CreateRandomSpawnLocationMenu()
    {
        // Get the spawn area limits
        float eastLimit = 30.0f;
        float westLimit = -30.0f;
        float northLimit = 40.0f;
        float southLimit = 5.0f;
        float upLimit = 30.0f;
        float downLimit = 10.0f;


        Vector3 spawnPos = new Vector3(Random.Range(eastLimit, westLimit),
                               Random.Range(downLimit, upLimit),
                               Random.Range(southLimit, northLimit));

        return spawnPos;
    }
}


