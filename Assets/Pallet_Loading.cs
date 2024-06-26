using box_Location;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pallet_Loading : MonoBehaviour
{
    public bool isloading;
<<<<<<< HEAD
    public float boxCount;
=======
    public Box_Location robotManager;
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
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
<<<<<<< HEAD

        if (collision.gameObject.CompareTag("Box1"))
=======
        
        if (collision.gameObject.CompareTag("Box1") && robotManager.isCylinderBackward)
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
        {
           
            isloading = true;

            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
<<<<<<< HEAD
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
        else if (collision.gameObject.CompareTag("Box2"))
=======
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            StartCoroutine(Timer(rb, 0.5f));
            rb.constraints = RigidbodyConstraints.None;





        }
        else if(collision.gameObject.CompareTag("Box2")&&robotManager.isCylinderBackward)
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
        {
            isloading = false;
            collision.gameObject.transform.SetParent(transform);
            collision.transform.tag = "Untagged";
<<<<<<< HEAD
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
=======
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            StartCoroutine(Timer(rb, 0.5f));
            rb.constraints = RigidbodyConstraints.None;
      


>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
        }
        isloading = false;
        boxCount = transform.childCount;
    }
<<<<<<< HEAD
}
=======
    private IEnumerator Timer(Rigidbody rb, float delay)
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(delay);
        rb.isKinematic = true;



    }

}
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
