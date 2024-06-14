using UnityEngine;
using System.Threading;
//시작시 플레이어가 뒤 방향으로 이동
public class GateCylinder : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8;
    public Transform ForWardDestination;
    public Transform BackWardDestination;
    public float distanceLimit = 0.5f;
    public Timer timer;
    public CylinderSensor ForWardSensor;//전진 센서
    public CylinderSensor BackWardSensor;//후진 센서
    public Sensor ObjectSensor;//물품 확인용
    public Sensor CloseSensor;

    void Update() //프레임이 갱신될때 실행되는 메서드 0.002~0.004초에 한번씩 실행
    {
        Vector3 directon = Vector3.back; //현 위치에서  destination까지의 벡터

        if (ObjectSensor.isObjectDetected)
        {
            if (ForWardSensor.isObjectDetected)
            {
                Vector3 dir2Dest = (BackWardDestination.position - transform.position).normalized;
                float fordistance = (BackWardDestination.position - transform.position).magnitude;

                Thread.Sleep(10);
                if (fordistance > distanceLimit)
                {
                    transform.position += dir2Dest * Time.deltaTime * speed;
                    print("Conveyor_GateCylinder - 작동중입니다...");
                    print("Conveyor_GateCylinder - 통과를 위해 게이트를 엽니다");
                }
                else
                {
                    ObjectSensor.isObjectDetected = false;
                }
            }
        }
        if (CloseSensor.isObjectDetected)
        {
            ForWardSensor.isObjectDetected = false;
            
            Vector3 backdir2Dest = (ForWardDestination.position - transform.position).normalized;
            float backdistance = (ForWardDestination.position - transform.position).magnitude;
            Thread.Sleep(10);
            if (backdistance > distanceLimit)
            {
                transform.position += backdir2Dest * Time.deltaTime * speed;
                print("Conveyor_GateCylinder - 물체 통과를 감지했습니다");
                print("Conveyor_GateCylinder - 다음 물체 정렬을 위해 게이트를 닫습니다");
            }
            else
            {
                CloseSensor.isObjectDetected = false;

            }
        }
    }
}
