using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using mxComponent;
using static UnityEditor.PlayerSettings;
//시작시 플레이어가 뒤 방향으로 이동

public class ConveyorCylinder : MonoBehaviour
{
    public enum Cylinder
    {
        Conveyor_PushCylinder,
        Conveyor_GateCylinder,
    }
    public Cylinder cylinder = Cylinder.Conveyor_PushCylinder;

    public MovePos movepos = MovePos.X;
    public enum MovePos
    {
        X, Y, Z
    }
    public float runTime = 2;
    public float minRange; //후진
    public float maxRange; //전진
    public Vector3 minPos;
    public Vector3 maxPos;
    public CylinderSensor forwardSensor;//전진 센서
    public CylinderSensor backwardSensor;//후진 센서
    public Sensor objectSensor;//물품 확인용
    public Sensor returnSensor;
    public bool isCylinderMoving = false;

    public CylinderStatusData cylinderStatusData;

    [Header("PLC")]
    public int plcInputValue;

    private void Start()
    {
        if (movepos == MovePos.X)
        {
            minPos = new Vector3(minRange, transform.localPosition.y, transform.localPosition.z);
            maxPos = new Vector3(maxRange, transform.localPosition.y, transform.localPosition.z);
        }
        else if (movepos == MovePos.Y)
        {
            minPos = new Vector3(transform.localPosition.x, minRange, transform.localPosition.z);
            maxPos = new Vector3(transform.localPosition.x, maxRange, transform.localPosition.z);
        }
        else
        {
            minPos = new Vector3(transform.localPosition.x, transform.localPosition.y, minRange);
            maxPos = new Vector3(transform.localPosition.x, transform.localPosition.y, maxRange);
        }
    }

    void Update() //프레임이 갱신될때 실행되는 메서드 0.002~0.004초에 한번씩 실행
    {
        if(MxComponent.instance.connection == MxComponent.Connection.Connected)
        {
            Vector3 directon = Vector3.back; //현 위치에서  destination까지의 벡터
            switch (cylinder)
            {
                case Cylinder.Conveyor_PushCylinder:
                    if (//plcInputValues[0] > 0 &&
                        !isCylinderMoving && backwardSensor.isObjectDetected && objectSensor.isObjectDetected)
                    {
                        StartCoroutine(CylMove(true));                                             // 실린더 전진 
                    }

                    if (//plcInputValues[1] > 0 &&
                        !isCylinderMoving && forwardSensor.isObjectDetected && returnSensor.isObjectDetected)
                    {
                        StartCoroutine(CylMove(false));                                           // 실린더 후진
                    }
                    break;

                case Cylinder.Conveyor_GateCylinder:
                    if (//plcInputValues[0] > 0 &&
                        !isCylinderMoving && forwardSensor.isObjectDetected && objectSensor.isObjectDetected)
                    {
                        StartCoroutine(CylMove(true));                                             // 실린더 전진 
                    }

                    if (//plcInputValues[1] > 0 &&
                        !isCylinderMoving && backwardSensor.isObjectDetected && returnSensor.isObjectDetected)
                    {
                        StartCoroutine(CylMove(false));                                           // 실린더 후진
                    }
                    break;
            }
            }
        }

    public void OnCylinderButtonClickEvent(bool dir)
    {
        StartCoroutine(CylMove(dir));
    }

    IEnumerator CylMove(bool dir)
    {
        if(cylinder == Cylinder.Conveyor_PushCylinder)
        {
            if (dir)
            {
                print("Conveyor_PushCylinder - 작동중입니다...");
                print("Conveyor_PushCylinder - 박스를 올바른 위치로 정렬합니다");
            }
            else
            {
                print("Conveyor_PushCylinder - 박스 정렬이 확인되었습니다...");
                print("Conveyor_PushCylinder - 다음 박스 정렬을 위해 원위치로 돌아갑니다.");
            }
        }
        else
        {
            if (dir)
            {
                print("Conveyor_GateCylinder - 작동중입니다...");
                print("Conveyor_GateCylinder - 통과를 위해 게이트를 엽니다");
            }
            else
            {
                print("Conveyor_GateCylinder - 물체 통과를 감지했습니다");
                print("Conveyor_GateCylinder - 다음 물체 정렬을 위해 게이트를 닫습니다");
            }
        }

        isCylinderMoving = true;
        int justOnce = 1;
        do
        {
            cylinderStatusData.usageCount = cylinderStatusData.usageCount + 1;
            justOnce++;
        }
        while (justOnce == 1);

        cylinderStatusData.operationStatus = true;

        float elapsedTime = 0;
        while (elapsedTime < runTime)
        {
            elapsedTime += Time.deltaTime;

            if (dir)
            {
                MovePositionRod(minPos, maxPos, elapsedTime, runTime);
            }
            else
            {
                MovePositionRod(maxPos, minPos, elapsedTime, runTime);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        isCylinderMoving = false;
        cylinderStatusData.operationStatus = false;
    }

    public void MovePositionRod(Vector3 startPos, Vector3 endPos, float _elapsedtime, float _runtime)
    {
        Vector3 newPos = Vector3.Lerp(startPos, endPos, _elapsedtime / _runtime);//t값이 0(min)~1(max)까지 변화
        transform.localPosition = newPos;
     }
}   
