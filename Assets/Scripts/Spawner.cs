using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 프리팹을 스폰할 위치를 지정하기 위한 변수를 선언합니다.
    public Transform spawnLocation;

    // 두 개의 프리팹을 변수로 선언합니다.
    public GameObject box1;
    public GameObject box2;
    public float box1Count_in;
    public float box2Count_in;


    // 버튼 클릭 이벤트에서 호출될 메서드를 선언합니다.
    public void OnBoxGenerateBtnClkEvnt()
    {
       
        // 랜덤으로 프리팹을 선택합니다.
        GameObject selectedPrefab = Random.Range(0, 2) == 0 ? box1 : box2;

        // 선택된 프리팹을 지정된 위치에 생성합니다.
        GameObject newObject = Instantiate(selectedPrefab, spawnLocation.position, spawnLocation.rotation);
        MeshRenderer meshRenderer = newObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        // 생성된 오브젝트의 태그를 설정합니다.
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
