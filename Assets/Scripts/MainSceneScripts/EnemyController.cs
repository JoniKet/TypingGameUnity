using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public TextMeshPro enemyText;
    public PlayerController playerControllerScript;
    public Dictionary dictionaryScript;
    public GameObject player;
    public float upSpeed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject door;
    public Transform goal;
    private NavMeshAgent agent;
    public bool isActive = true;
    private bool hasBeenCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Implement a method to call random word
        
        player = GameObject.Find("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
        dictionaryScript = GameObject.Find("SpawnManager").GetComponent<Dictionary>();
        door = GameObject.Find("Door");
        enemyRb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        enemyText.text = dictionaryScript.GetRandomWord();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy NavMeshAgent destionation setting
        if (isActive && !hasBeenCalled)
        {
            agent.destination = door.transform.position;
        }

        // Begin to lift the enemy to player ufo if the enemy is under the ufo
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                            new Vector3(player.transform.position.x, 0, transform.position.z)) < 0.1f && hasBeenCalled)
        {
            //TODO: Begin beam effect
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 4000, 0) * Time.deltaTime);
            enemyRb.MoveRotation(enemyRb.rotation * deltaRotation);
            enemyRb.MovePosition(transform.position + transform.up * Time.deltaTime * upSpeed);
        }

        // Begin destroy process of enemy if enemy is close to ufo on y axis
        if (player.transform.position.y - transform.position.y < 0.5f && hasBeenCalled)
        {   
            DestroyEnemy();
        }
    }

    public void MovePlayerAboveEnemy()
    {
        
        hasBeenCalled = true;
        enemyText.text = "";
        isActive = false;
        agent.isStopped = true;
        agent.enabled = false;
        playerControllerScript.moveAboveEnemy(transform);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

 

}
