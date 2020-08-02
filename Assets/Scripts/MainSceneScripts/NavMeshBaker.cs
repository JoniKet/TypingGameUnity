using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface[] navMeshSurfaces;

    // Start is called before the first frame update
    void Start()
    {
        buildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildNavMesh()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }

}
