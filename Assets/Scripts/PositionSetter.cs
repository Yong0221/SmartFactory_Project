using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxPositionSetter : MonoBehaviour
{
    float[] box1Size;                           //1호상자 사이즈 - 간격용
    float[] box2Size;                           //2호상자 사이즈 - 간격용
    public float box1Count;                          //1호상자 카운트
    public float box2Count;                          //1호상자 카운트
    public float maxMoveBelt;           //컨베이어 이동거리 (임시)

    public Transform box1_Origin;    //1호상자 최초 적재 위치
    public Transform box2_Origin;    //2호상자 최초 적재 위치
    Vector3 nowPos;                          //현재위치
    Vector3 target1Pos;                     //목적지1(변경전)
    Vector3 target2Pos;                     //목적지2(변경후)
    Vector3 robotTarget;                   //움직일 Transfer 설정
    Vector3 LM_Origin;                     // 각각의 원점(초기위치) - 기준: 컨베이어 벨트에서 받는 위치
    Vector3 X_Origin;
    Vector3 Z_Origin;
    Vector3 Load_Origin;
    Vector3 moveBoxTarget;              //box가 있어야할 곳
    Vector3 box1_deltaPos;

    public loadBox loadCheck;           //로드시스템 고정부 - 물건 적재 여부 체크용도

    public Transform LMTransfer;
    public Transform X_Transfer;
    public Transform Z_Transfer;
    public Transform Load_Transfer;

    public GameObject Belt;             //컨베이어 이동용(임시)

    bool isTransfer;                            //이동여부

    void Start()
    {
        isTransfer = true;

        box1Size = new float[] { -0.19f, 0.22f, 0.09f };        //1호 박스 사이즈 초기화
        box2Size = new float[] { 0.271f, 0.181f, 0.0151f }; //사이즈 좌표 기준은 로봇 축 기준;
        nowPos = new Vector3();
        target1Pos = new Vector3();
        target2Pos = new Vector3();
        moveBoxTarget = new Vector3();
        box1_deltaPos = new Vector3();
        box1_deltaPos = Vector3.zero;

        LM_Origin = LMTransfer.localPosition;
        X_Origin = X_Transfer.localPosition;
        Z_Origin = Z_Transfer.localPosition;
        Load_Origin = Load_Transfer.localPosition;

        //LMTransfer의 Y축 방향 이동을 위한  target좌표 재설정 작업

    }
    public void LMLoadBtnClkEvnt()
    {
        robotTarget = LMTransfer.localPosition; //LM 움직임

        robotTarget.z -= moveBoxTarget.x;         //축좌표변환: z-x방향으로 이동
        StartCoroutine(CoMoveLMCylinder(LM_Origin, robotTarget, 2));
    }

    public void LMOriginBtnClkEvnt()
    {
        robotTarget = LMTransfer.localPosition;
        StartCoroutine(CoMoveLMCylinder(robotTarget, LM_Origin, 2));
    }

    public void XLoadBtnClkEvnt()
    {
        robotTarget = X_Origin;
        robotTarget.x -= moveBoxTarget.y;
        StartCoroutine(CoMoveXCylinder(X_Origin, robotTarget, 2));
    }

    public void XOriginBtnClkEvnt()
    {
        print(ToString(X_Origin));

        robotTarget = X_Transfer.localPosition;

        StartCoroutine(CoMoveXCylinder(robotTarget, X_Origin, 2));

    }

    public void ZLoadBtnClkEvnt()
    {

        print(ToString(X_Origin));
        robotTarget = Z_Origin;
        robotTarget.y -= -moveBoxTarget.z;
        StartCoroutine(CoMoveZCylinder(Z_Origin, robotTarget, 2));

    }

    public void ZOriginBtnClkEvnt()
    {

        robotTarget = Z_Transfer.localPosition;
        StartCoroutine(CoMoveZCylinder(robotTarget, Z_Origin, 2));

    }

    public void CylinderForwardBtnClkEvnt()
    {
        robotTarget = Load_Origin;
        robotTarget.x = -0.2f;
        StartCoroutine(CoMoveLoadCylinder(robotTarget, Load_Origin, 0.5f));
        robotTarget = Vector3.zero;

    }

    public void CylinderBackwardBtnClkEvnt()
    {
        robotTarget = Load_Origin;
        robotTarget.x = -0.2f;
        StartCoroutine(CoMoveLoadCylinder(Load_Origin, robotTarget, 0.5f));
        robotTarget = Vector3.zero;

        if (loadCheck.isBoxLoading[0])
        {
            loadCheck.isBoxLoading[0] = false;
        }
        else if (loadCheck.isBoxLoading[1])
        {
            nowPos = GameObject.FindGameObjectWithTag("Box2").transform.position;
            target2Pos = nowPos - box2_Origin.position;// target pos z축: LM가이드 이동 값& X축: Z동작부 이동값 & Y축: X동작부 이동값;
            target2Pos = transAxis(target2Pos);
            moveBoxTarget = target2Pos;

        }
    }

    public void beltOnBtnClkEvnt()
    {
        Vector3 belt_origin = Belt.transform.localPosition;
        Vector3 belt_target = belt_origin;
        belt_target.x = maxMoveBelt;
        StartCoroutine(CoMoveBelt(belt_origin, belt_target, 1f));

        print(box1_deltaPos);
    }

    public Vector3 box1TargetTrans(Vector3 _box1Target)
    {
        box1Count += 1;
        _box1Target.y -= box1Size[1] + 0.01f;
        if (box1Count % 25 == 0)//z축 변환
        {
            _box1Target.y = 0;
            _box1Target.x = 0;
            _box1Target.z += box1Size[2];
        }
        else if (box1Count % 5 == 0)//X축 변환
        {
            _box1Target.y = 0;
            _box1Target.x += box1Size[0];
        }//LM축 변환
        print(box1Count);

        return _box1Target;
    }
    private Vector3 transAxis(Vector3 _targetPos)//x:LM동작부, y:Z동작부, Z: X동작부
    {
        Vector3 result = new Vector3();

        result.x = _targetPos.z;
        result.y = _targetPos.x;
        result.z = _targetPos.y;

        return result;
    }
    private string ToString(Vector3 v)
    {
        return string.Format("targetPos (X: {0:F7}, Y: {1:F7}, Z: {2:F7})", v.x, v.y, v.z);
    }

    IEnumerator CoMoveLMCylinder(Vector3 _originPos, Vector3 _targetPos, float movingTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < movingTime)
        {
            float t = elapsedTime / movingTime;

            LMTransfer.localPosition = Vector3.Lerp(_originPos, _targetPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator CoMoveXCylinder(Vector3 _originPos, Vector3 _targetPos, float movingTime)

    {
        float elapsedTime = 0f;

        while (elapsedTime < movingTime)
        {
            float t = elapsedTime / movingTime;

            X_Transfer.localPosition = Vector3.Lerp(_originPos, _targetPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly targetPos
        //transform.position = moveBoxTarget;
    }
    IEnumerator CoMoveZCylinder(Vector3 _originPos, Vector3 _targetPos, float movingTime)

    {
        float elapsedTime = 0f;

        while (elapsedTime < movingTime)
        {
            float t = elapsedTime / movingTime;

            Z_Transfer.localPosition = Vector3.Lerp(_originPos, _targetPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly targetPos
        //transform.position = moveBoxTarget;
    }
    IEnumerator CoMoveLoadCylinder(Vector3 _originPos, Vector3 _targetPos, float movingTime)

    {
        float elapsedTime = 0f;

        while (elapsedTime < movingTime)
        {
            float t = elapsedTime / movingTime;

            Load_Transfer.localPosition = Vector3.Lerp(_originPos, _targetPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly targetPos
        //transform.position = moveBoxTarget;
    }
    IEnumerator CoMoveBelt(Vector3 _originPos, Vector3 _targetPos, float movingTime)

    {
        float elapsedTime = 0f;

        while (elapsedTime < movingTime)
        {
            float t = elapsedTime / movingTime;

            Belt.transform.localPosition = Vector3.Lerp(_originPos, _targetPos, t);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Belt.transform.localPosition = _originPos;

        if (loadCheck.isBoxLoading[0])
        {

            nowPos = GameObject.FindGameObjectWithTag("Box1").transform.position;
            target1Pos = nowPos - box1_Origin.position;
            print(ToString(target1Pos));
            target1Pos = transAxis(target1Pos); //target pos x yz -> 뒤죽박죽   lm x z
            target1Pos += box1_deltaPos;// box c
            moveBoxTarget = target1Pos;
            print(ToString(moveBoxTarget));
            box1_deltaPos = box1TargetTrans(box1_deltaPos);
            print("box1 다음 위치 경로 계획 완료 : " + ToString(box1_deltaPos));

        }
        yield return null;
    }
}
