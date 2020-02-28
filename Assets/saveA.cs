using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveA : MonoBehaviour
{
    public JsonManager json;
    public Transform tr;
    public Vector3 startpos;

    void Start()
    {
        tr = GetComponent<Transform>();
        startpos = tr.position;
    }
    void Update()
    {
        if(startpos != tr.position)
        {
            json.SaveJson();
        }
    }
}
