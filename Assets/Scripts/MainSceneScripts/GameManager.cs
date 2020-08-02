using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 2;
    public int destroyedEnemies = 0;
    public int health = 10;
    public int passedEnemies = 0;
    public int wave = 1;
    public Camera mainCamera;
    public Camera upCamera;
    public bool planningMode = false;
    private SpawnManager spawnManager;
    private GameObject Canvas;
    private GameObject[] enemies;
    private NavMeshBaker navMeshBakerScript;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        navMeshBakerScript = GameObject.Find("NavMeshBuilder").GetComponent<NavMeshBaker>();
        Canvas = GameObject.Find("Canvas");
        Canvas.transform.GetChild(1).gameObject.SetActive(false);
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        upCamera = GameObject.Find("UpCamera").GetComponent<Camera>();
        mainCamera.gameObject.SetActive(true);
        upCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.C) && planningMode == false){
            ActivatePlanningMode();
        }
        else if (Input.GetKeyDown(KeyCode.C) && planningMode == true)
        {
            deactivatePlanningMode();
        }
    }

    void ActivatePlanningMode()
    {
        // Find all the enemies on the map when planning mode is enabled and destroy them
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().DestroyEnemy();
        }

        planningMode = true; // Activate planning mode
        mainCamera.gameObject.SetActive(false); // Change camera to orthogonal view
        upCamera.gameObject.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(true); // Activate wallpanel
    }

    void deactivatePlanningMode()
    {
        navMeshBakerScript.buildNavMesh();
        mainCamera.gameObject.SetActive(true);
        upCamera.gameObject.SetActive(false);
        Canvas.transform.GetChild(1).gameObject.SetActive(false);
        planningMode = false;

    }



}
