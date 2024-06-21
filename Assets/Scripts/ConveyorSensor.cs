using mxComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSensor : MonoBehaviour
{
    public bool isObjectDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Dragger"))
        {
            isObjectDetected = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
       
        isObjectDetected = false;
  

    }
}