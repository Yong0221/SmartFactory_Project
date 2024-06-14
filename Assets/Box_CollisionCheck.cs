using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_CollisionCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Box1"))
            Destroy(collision.gameObject);
        else if(collision.gameObject.CompareTag("Box2"))
            Destroy(collision.gameObject);
    }
}
