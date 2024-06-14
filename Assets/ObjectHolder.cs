using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("box0") | other.gameObject.layer == LayerMask.NameToLayer("box1"))
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("box0") | other.gameObject.layer == LayerMask.NameToLayer("box1"))
        {
            other.transform.SetParent(null);
        }
    }
}
