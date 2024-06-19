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
        startPos = transform.position; // ���� ��ġ ����
        endPos = startPos; // ��ǥ ��ġ ����
        endPos.x = 2.3f; // ��ǥ ��ġ�� x���� 2.3���� ����
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
       
        float elapsedTime = 0; // ��� �ð� �ʱ�ȭ

        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime; // �����Ӹ��� ��� �ð� ����
            float t = elapsedTime / runTime; // ��� �ð��� ���� ���� �� ���
            transform.position = Vector3.Lerp(_startPos, _endPos, t); // ���� ��ġ�� ��ǥ ��ġ ���̸� ����
            yield return null; // ���� �����ӱ��� ���
        }

        // ������ ��ġ�� ��Ȯ�� ��ǥ ��ġ�� ����
        transform.position = _endPos;
    }
}
