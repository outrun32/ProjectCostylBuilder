﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveA : MonoBehaviour
{
    public JsonManager json;
    public Transform tr;
    public Vector3 startpos;
    bool isSaved;
    void Start()
    {
        tr = GetComponent<Transform>();
        startpos = tr.position;
    }
    bool f = false;
    void Update()
    {
        if (!f && Vector3.Distance(startpos, tr.position) > 0.5f)
        {
            f = true;
            json.SaveJson();
            print("s");
        }

    }
}
