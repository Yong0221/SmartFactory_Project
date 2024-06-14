using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class SensorData
{
    public string name;                 //센서 이름
    public string serialNumber;    //센서 시리얼넘버
    public string manufacturer;    //센서 제조사
    public bool operationStatus;             //작동유무
    public bool malfunctionStatus;         //고장유무
    public bool maintenanceStatus;       //정비필요유무
    public int usageCount;                      //사용횟수
    public string productionDate;    //제조년월일

    public SensorData(string name, string serialNumber, string manufacturer, int usageCount, string productionDate)
    {
        this.name = name;
        this.serialNumber = serialNumber;
        this.manufacturer = manufacturer;
        this.usageCount = usageCount;
        this.productionDate = productionDate;
    }
}
