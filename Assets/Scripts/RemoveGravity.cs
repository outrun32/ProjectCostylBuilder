using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGravity : MonoBehaviour
{
    Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Resource")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }
}
