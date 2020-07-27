using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObject : MonoBehaviour
{
    private GameObject mouseObject;
    // Start is called before the first frame update
    void Start()
    {
        mouseObject = GameObject.Find("MouseObject");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if(Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            transform.position = hit.point;
        }
    }
}
