using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using mxComponent;
using System.Threading;

public class Piston : MonoBehaviour
{
    [Header("데이터")]
    [Tooltip("데이터 및 데이터 파일 저장 경로를 설정합니다.")]
    public CylinderStatusData cylinderStatusData;
    public string cylinderDataPath;
    SwitchSensorData[] switchSensorData = new SwitchSensorData[2];
    public string[] switchSensorDataPath;

    [Header("상태")]
    [Tooltip("솔레노이드를 편솔 또는 양솔로 설정합니다. \n 편솔: 1 , 양솔: 2")]
    public Option option = Option.SingleSolenoid;
    public enum Option
    {
        SingleSolenoid = 1,
        DoubleSolenoid = 2
    }
    public Species species = Species.X;
    public enum Species
    {
        X, Y, Z 
    }
    public bool isCylinderMoving = false;
    public bool isbackward = true;
    public float runTime = 2;

    [Header("PLC")]
    public int[] plcInputValues;
    public string rearSwitchDeviceName; //x10
    public string frontSwitchDeviceName; //x11

    [Header("초기화")]
    public Transform PistonRod;
    public Image btnimgf;
    public Image btnimgb;
    public TMP_Text pistonText;
    public float minRange;
    public float maxRange;
    public Vector3 minPos;
    public Vector3 maxPos;

    [Header("옵션")]
    public Sensor sensor;
    public AudioClip clip;

    public void Start()
    {
        if(species == Species.X)
        {
            minPos = new Vector3(minRange, PistonRod.transform.localPosition.y, PistonRod.transform.localPosition.z);
            maxPos = new Vector3(maxRange, PistonRod.transform.localPosition.y, PistonRod.transform.localPosition.z);
        }
        else if (species == Species.Y)
        {
            minPos = new Vector3(PistonRod.transform.localPosition.x, minRange, PistonRod.transform.localPosition.z);
            maxPos = new Vector3(PistonRod.transform.localPosition.x, maxRange, PistonRod.transform.localPosition.z);
        }
        else
        {
            minPos = new Vector3(PistonRod.transform.localPosition.x, PistonRod.transform.localPosition.y, minRange);
            maxPos = new Vector3(PistonRod.transform.localPosition.x, PistonRod.transform.localPosition.y, maxRange);
        }

        plcInputValues = new int[(int)option];

    }

    // Update is called once per frame
    void Update()
    {

        if (option == Option.SingleSolenoid) //편솔
        {
            // 실린더 전진
            if (plcInputValues[0] > 0 && !isCylinderMoving && isbackward)
                StartCoroutine(CoMove(isbackward));
            else if (plcInputValues[0] == 0 && !isCylinderMoving && !isbackward)
                StartCoroutine(CoMove(!isbackward));
        }
        else if (option == Option.DoubleSolenoid) //양솔
        {
            // 실린더 전진
            if (plcInputValues[0] > 0 && !isCylinderMoving && isbackward)
                StartCoroutine(CoMove(isbackward));

            // 실린더 후진
            if (plcInputValues[1] > 0 && !isCylinderMoving && !isbackward)
                StartCoroutine(CoMove(!isbackward));
        }
    }

    public void OnCylinderButtonClickEvent(bool dir)
    {
        StartCoroutine(CoMove(dir));
/*        Audiomanager.instance.PlayAudioClip(clip);*/
    }
    public void SetSwitchDevicesByCylinderMoving(bool _isCylinderMoving, bool _isBackward)
    {
        if (_isCylinderMoving)
        {
            MxComponent.instance.SetDevice(rearSwitchDeviceName, 0);  // 실린더가 움직이고 있을때는 움직이지 않도록
            MxComponent.instance.SetDevice(frontSwitchDeviceName, 0); // PLC상에서 신호를 끔(0으로 설정)
            print($"isBackward: {_isBackward}, {rearSwitchDeviceName}: 0");
            print($"isBackward: {_isBackward}, {frontSwitchDeviceName}: 0");
            return;                                                                                              // 반복되지 않게 하기 위해 리턴
        }
        if (_isBackward)                                                                                      // 실린더가 후진상태일때 
        {
            MxComponent.instance.SetDevice(rearSwitchDeviceName, 1);
            print($"isBackward: {_isBackward}, {rearSwitchDeviceName}: 1");
        }
        else
        {
            MxComponent.instance.SetDevice(frontSwitchDeviceName, 1);
            print($"isBackward: {_isBackward}, {frontSwitchDeviceName}: 1");
        }
    }
    IEnumerator CoMove(bool dir)
    {
        print("시작");
        SetSwitchDevicesByCylinderMoving(isCylinderMoving, isbackward);

            isCylinderMoving = true;
            cylinderStatusData.usageCount = cylinderStatusData.usageCount + 1;

            cylinderStatusData.operationStatus = true;
            //SetCylinderSwitchActive(isbackward, false);
            /*        SetCylinderBtnActive(isbackward, true);*/

            float elapsedTime = 0;

            while (elapsedTime < runTime)
            {
                elapsedTime += Time.deltaTime;

                if (isbackward)
                {
                    MovePositionRod(minPos, maxPos, elapsedTime, runTime);
                    btnimgf.color = Color.green;
                    btnimgb.color = Color.white;
            }
                else
                {
                    MovePositionRod(maxPos, minPos, elapsedTime, runTime);
                    btnimgb.color = Color.green;
                    btnimgf.color = Color.white;
            }
                yield return new WaitForSeconds(Time.deltaTime);
            }
            //SetCylinderSwitchActive(isbackward, true);
            isCylinderMoving = false;
            cylinderStatusData.operationStatus = true;
            isbackward = !isbackward; //초기값(true) ->false

            SetSwitchDevicesByCylinderMoving(isCylinderMoving, isbackward);
    }

    public void MovePositionRod(Vector3 startPos, Vector3 endPos, float _elapsedtime, float _runtime)
    {
        Vector3 newPos = Vector3.Lerp(startPos, endPos, _elapsedtime / _runtime);//t값이 0(min)~1(max)까지 변화
        PistonRod.transform.localPosition = newPos;
    }
}
