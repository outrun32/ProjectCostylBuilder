using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGravity : MonoBehaviour
{
    Rigidbody rb;
    public bool stay;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Resource")
        {
            stay = true;
            rb = other.GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Resource")
        {
            stay = false;
        }
    }
}
