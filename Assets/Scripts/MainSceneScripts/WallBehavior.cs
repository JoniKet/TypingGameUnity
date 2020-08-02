using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    private SpawnManager spawnManagerScript;
    private bool isPlaced = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaced)
        {
            Vector3 mouseLocation = spawnManagerScript.getMouseLocation();
            transform.position = mouseLocation + Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPlaced = true;
        }

        float mouseScrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollWheelInput != 0 && !isPlaced)
        {
            if(mouseScrollWheelInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 10, 0);
            }
            if (mouseScrollWheelInput < 0)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 10, 0);
            }
        }
        
    }

 

}
