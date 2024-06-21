using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // �������� ������ ��ġ�� �����ϱ� ���� ������ �����մϴ�.
    public Transform spawnLocation;

    // �� ���� �������� ������ �����մϴ�.
    public GameObject box1;
    public GameObject box2;
    public float box1Count_in;
    public float box2Count_in;


    // ��ư Ŭ�� �̺�Ʈ���� ȣ��� �޼��带 �����մϴ�.
    public void OnBoxGenerateBtnClkEvnt()
    {
       
        // �������� �������� �����մϴ�.
        GameObject selectedPrefab = Random.Range(0, 2) == 0 ? box1 : box2;

        // ���õ� �������� ������ ��ġ�� �����մϴ�.
        GameObject newObject = Instantiate(selectedPrefab, spawnLocation.position, spawnLocation.rotation);
        MeshRenderer meshRenderer = newObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        // ������ ������Ʈ�� �±׸� �����մϴ�.
        if (selectedPrefab == box1)
        {
            newObject.tag = "Box1";
            box1Count_in++;
 

        }
        else if (selectedPrefab == box2)
        {
            newObject.tag = "Box2";
            box2Count_in++;

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
