using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet_Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic=true;
         
        }
    }
}
