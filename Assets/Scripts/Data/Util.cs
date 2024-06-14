using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Util //new로 인스턴싱할 필요가 없는 글로벌 정적 클래스
{
    public static T CreateJsonForCylinder<T>(CylinderStatusData cylinderStatusData)
    {
        cylinderStatusData = new CylinderStatusData(cylinderStatusData.name, cylinderStatusData.serialNumber, cylinderStatusData.manufacturer, cylinderStatusData.solenoidStatus, cylinderStatusData.usageCount, cylinderStatusData.productionDate);
        string json = JsonUtility.ToJson(cylinderStatusData);

        FileStream fs = new FileStream("Assets/Scripts/Data/CylData/" + cylinderStatusData.name + "_data" + ".json", FileMode.Create); // 파일을 만들기
        StreamWriter sw = new StreamWriter(fs); // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();

        return default(T);
    }

    public static T CreateJsonForSensor<T>(SensorData sensorData)
    {
        sensorData = new SensorData(sensorData.name, sensorData.serialNumber, sensorData.manufacturer, sensorData.usageCount, sensorData.productionDate);
        string json = JsonUtility.ToJson(sensorData);

        FileStream fs = new FileStream("Assets/Scripts/Data/SenData/" + sensorData.name + "_data" + ".json", FileMode.Create); // 파일을 만들기
        StreamWriter sw = new StreamWriter(fs); // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();

        return default(T);
    }

    public static T CreateJsonForSwitchSensor<T>(SwitchSensorData switchSensorData)
    {
        switchSensorData = new SwitchSensorData(switchSensorData.name, switchSensorData.serialNumber, switchSensorData.manufacturer, switchSensorData.usageCount, switchSensorData.productionDate);
        string json = JsonUtility.ToJson(switchSensorData);

        FileStream fs = new FileStream("Assets/Scripts/Data/CylData/CylSwitchData/" + switchSensorData.name + "_data" + ".json", FileMode.Create); // 파일을 만들기
        StreamWriter sw = new StreamWriter(fs); // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();

        return default(T);
    }

    public static T CreateJsonForConveyor<T>(ConveyorStatusData conveyorStatusData)
    {
        conveyorStatusData = new ConveyorStatusData(conveyorStatusData.name, conveyorStatusData.serialNumber, conveyorStatusData.manufacturer, conveyorStatusData.direction, conveyorStatusData.usageCount, conveyorStatusData.productionDate);
        string json = JsonUtility.ToJson(conveyorStatusData);

        FileStream fs = new FileStream("Assets/Scripts/Data/ConData/" + conveyorStatusData.name + "_data" + ".json", FileMode.Create); // 파일을 만들기
        StreamWriter sw = new StreamWriter(fs); // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();

        return default(T);
    }

/*    public static T CreateJsonForMachine<T>(MachineData machineData)
    {
        machineData = new MachineData(machineData.name,machineData.serialNumber, machineData.manufacturer, machineData.usageCount, machineData.productionDate);
        string json = JsonUtility.ToJson(machineData);

        FileStream fs = new FileStream("Assets/" + machineData.name + "_data" + ".json", FileMode.Create); // 파일을 만들기
        StreamWriter sw = new StreamWriter(fs); // 문자 단위로 데이터 쓰기, 인코딩 처리
        sw.Write(json);
        sw.Close();
        fs.Close();

        return default(T);
    }*/

    public static T LoadJson<T>(string path)  //T - 특정 형식을 지정하지 않고 그 형식으로 파일을 만들기
    {
        FileStream fs = new FileStream(path, FileMode.Open); // 파일을 열기->스트림화
        StreamReader sr = new StreamReader(fs); // 스트림 정보를 읽기
        string json = sr.ReadToEnd();

        T obj = JsonUtility.FromJson<T>(json); //T형태의 obj를 json으로 받아 생성한다.

        sr.Close(); //스트림리더 닫기
        fs.Close(); //스트림 닫기

        return obj;
    }
}
