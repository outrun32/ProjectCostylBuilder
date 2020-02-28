using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserInput : MonoBehaviour
{
    public static GameObject thisobject;
    int CurrentID;
    void Start()
    {
        thisobject = null;
        CurrentID = 0;
    }

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        for(int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if(CurrentID != id)
            {
                CurrentID = id;
                thisobject = hit.collider.gameObject;

                string tag = thisobject.tag;
                if(tag == "button")
                {
                    //Button bt = thisobject.GetComponent<Button>();
                    Debug.Log("Button clicked");
                }

            }
        }
    }
}
