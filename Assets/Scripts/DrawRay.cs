using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(Input.mousePosition, fwd, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
        }
    }
}
