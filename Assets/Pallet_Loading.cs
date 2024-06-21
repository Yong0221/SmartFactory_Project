using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pallet_Loading : MonoBehaviour
{
    public bool isloading;
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
        print(collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Box1"))
        {
            print("Ãæµ¹");
            isloading = true;
           
            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
            collision.gameObject.GetComponent<Rigidbody>().isKinematic=true;
         
        }
        else if(collision.gameObject.CompareTag("Box2"))
        {
            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
            isloading = false;
    }
}
