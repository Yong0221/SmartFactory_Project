using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeliveryCylinder : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    public float runTime = 6;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // 시작 위치 저장
        endPos = startPos; // 목표 위치 설정
        endPos.x = 2.3f; // 목표 위치의 x값을 2.3으로 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void cylinderABckBtnClkEvnt()
    {
        GameObject PalletA = GameObject.FindGameObjectWithTag("Pallet1");
        Rigidbody rb = PalletA.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        PalletA.tag = "Untagged";


    }
    public void cylinderBBckBtnClkEvnt()
    {
        GameObject PalletB = GameObject.FindGameObjectWithTag("Pallet2");
        Rigidbody rb = PalletB.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        PalletB.tag = "Untagged";


    }

    public void dlivetyCylinderFowardBtnClkEVnt()
    {
        StartCoroutine(CoMoveDeliveryCylinder(endPos,startPos));
    }
    public void dlivetyCylinderBckWardBtnClkEVnt()
    {
        StartCoroutine(CoMoveDeliveryCylinder(startPos,endPos));
    }
    IEnumerator CoMoveDeliveryCylinder(Vector3 _startPos, Vector3 _endPos)
    {
       
        float elapsedTime = 0; // 경과 시간 초기화

        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime; // 프레임마다 경과 시간 증가
            float t = elapsedTime / runTime; // 경과 시간에 따른 보간 값 계산
            transform.position = Vector3.Lerp(_startPos, _endPos, t); // 시작 위치와 목표 위치 사이를 보간
            yield return null; // 다음 프레임까지 대기
        }

        // 마지막 위치를 정확히 목표 위치로 설정
        transform.position = _endPos;
    }
}
