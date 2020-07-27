using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float step = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Move player Towards enemy
    public void moveAboveEnemy(Transform enemyPosition)
    {
        StartCoroutine(movePlayerToCoroutine(enemyPosition));
    }
    
    public IEnumerator movePlayerToCoroutine(Transform enemyPosition)
    {
        bool arrived = false;
        Vector3 enemyXZ = new Vector3(enemyPosition.position.x, transform.position.y, enemyPosition.position.z);
        while (!arrived)
        {
            float speed = step * Time.deltaTime;
           transform.position =  Vector3.MoveTowards(transform.position, enemyXZ, speed);
            if (Vector3.Distance(transform.position, enemyXZ) < 0.00001f) arrived = true;
            yield return null;
        }
        if (arrived)
        {
            // implement lif enemy method
        }
    }


}
