using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCylinder : MonoBehaviour
{
    public float runTime=2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoMoveDeliveryCylinder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CoMoveDeliveryCylinder()
    {
        Vector3 newPos = transform.position;
        newPos.x = 1.6f;
        float elapsedTime = 0;
        while (elapsedTime < runTime)
        {
            elapsedTime+= Time.deltaTime;
            float t = elapsedTime / runTime;
            transform.position=Vector3.Lerp(transform.position, newPos, t); 
            yield return null;

        }
        yield return null;
    }
}
