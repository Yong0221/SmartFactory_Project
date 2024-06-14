using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRead_Cyl: MonoBehaviour
{
    [Header("데이터")]
    [Tooltip("데이터 및 데이터 파일 저장 경로를 설정합니다.")]
    public CylinderStatusData cylinderStatusData;
    public string cylinderDataPath;
    public SwitchSensorData[] switchSensorData = new SwitchSensorData[2];
    public string[] switchSensorDataPath;

    [Header("PLC")]
    public string[] plcAddress;
    public int[] plcInputValues;
    public string frontSwitchDeviceName; 
    public string rearSwitchDeviceName;


    void Start()
    {
        cylinderDataPath = "Assets/Scripts/Data/CylData/" + cylinderStatusData.name + "_data.json";
        switchSensorDataPath[0] = "Assets/Scripts/Data/CylData/CylSwitchData/" + cylinderStatusData.name + "_switchF_data.json";
        switchSensorDataPath[1] = "Assets/Scripts/Data/CylData/CylSwitchData/" + cylinderStatusData.name + "_switchB_data.json";
        Util.CreateJsonForCylinder<DataManager>(cylinderStatusData);
        Util.CreateJsonForSwitchSensor<DataManager>(switchSensorData[0]);
        Util.CreateJsonForSwitchSensor<DataManager>(switchSensorData[1]);

        cylinderStatusData = Util.LoadJson<CylinderStatusData>(cylinderDataPath);
        for (int i = 0; i < switchSensorData.Length; i++)
        {
            switchSensorData[i] = Util.LoadJson<SwitchSensorData>(switchSensorDataPath[i]);
        }
    }

}
