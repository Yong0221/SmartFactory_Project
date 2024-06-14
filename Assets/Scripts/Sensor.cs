using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Diagnostics;
using System.Xml.Linq;
using TMPro;
using mxComponent;
using System.IO;
using static UnityEditor.PlayerSettings;

public class Sensor : MonoBehaviour
{
    [Header("데이터")]
    [Tooltip("데이터 및 데이터 파일 저장 경로를 설정합니다.")]
    public SensorData sensorData;
    public string sensorDataPath;

    [Header("상태")]
    public bool isObjectDetected = false;
    public ConveyorCylinder pushCylinder;
    public Image sensorImage;

    [Header("PLC")]
    public string plcAddress;
    public int plcInputValue;
    public string boxName;

    void Start()
    {
        Util.CreateJsonForSensor<DataManager>(sensorData);
        sensorImage.color = Color.white;
        sensorData = Util.LoadJson<SensorData>(sensorDataPath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box1" | other.gameObject.tag == "Box2")
        {
            isObjectDetected = true;
            print("[Sensor]" + other.gameObject.tag + "이(가) [" + this.name + "]에 인식됩니다.");
            int cnt = 1;
            do
            {
                sensorData.usageCount++;
                cnt++;
            } while (cnt == 1);
        }

        if (other.gameObject.tag == "Box1")
        {
            sensorImage.color = Color.green;
            plcInputValue = 1;
            MxComponent.instance.SetDevice(plcAddress, 1);
            sensorData.operationStatus = true;
            pushCylinder.maxRange = -0.25f;
            boxName = "Box1";
        }

        else if (other.gameObject.tag == "Box2")
        {
            sensorImage.color = Color.green;
            plcInputValue = 1;
            MxComponent.instance.SetDevice(plcAddress, 1);
            sensorData.operationStatus = true;
            pushCylinder.maxRange = -0.188f;
            boxName = "Box2";
        }
        pushCylinder.minPos = new Vector3(pushCylinder.transform.localPosition.x, pushCylinder.transform.localPosition.y, pushCylinder.minRange);
        pushCylinder.maxPos = new Vector3(pushCylinder.transform.localPosition.x, pushCylinder.transform.localPosition.y, pushCylinder.maxRange);

    }

    private void OnTriggerExit(Collider other)
    {
        sensorImage.color = Color.white;
        isObjectDetected = false;
        sensorData.operationStatus = false;
        plcInputValue = 0;
        MxComponent.instance.SetDevice(plcAddress, 0);
    }
}