using box_Location;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pallet_Loading : MonoBehaviour
{
    public bool isloading;
    public Box_Location robotManager;
    // Start is called before the first frame update
    void Start()
    {
        robotManager=GameObject.FindGameObjectWithTag("RobotManager").GetComponent<Box_Location>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)    {
        print(collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Box1") && robotManager.isCylinderBackward)
        {
            print("Ãæµ¹");
            isloading = true;
           
            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            StartCoroutine(Timer(rb, 0.5f));
            rb.constraints = RigidbodyConstraints.None;





        }
        else if(collision.gameObject.CompareTag("Box2")&&robotManager.isCylinderBackward)
        {
            isloading = false;
            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            StartCoroutine(Timer(rb, 0.5f));
            rb.constraints = RigidbodyConstraints.None;
      


        }
            isloading = false;
    }
    private IEnumerator Timer(Rigidbody rb, float delay)
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(delay);
        rb.isKinematic = true;



    }

}
