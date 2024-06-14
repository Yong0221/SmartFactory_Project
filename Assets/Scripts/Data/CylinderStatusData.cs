using System;

[Serializable]
public class CylinderStatusData
{
    public string name;                             //실린더 이름
    public string serialNumber;                 //실린더 시리얼넘버
    public string manufacturer;                //실린더 제조사
    public string productionDate;     //제조년월일

    public int usageCount;                       //사용횟수
    
    public int[] solenoidStatus;                 //현재 솔레노이드 위치(앞, 뒤)

    public bool operationStatus;              //작동유무
    public bool malfunctionStatus;          //고장유무
    public bool maintenanceStatus;        //정비필요유무



    // 생성자
    public CylinderStatusData( string name, string serialNumber, string manufacturer, int[] solenoidStatus, int usageCount, string productionDate)
    {
        this.name = name;
        this.serialNumber = serialNumber;
        this.manufacturer = manufacturer;
        this.solenoidStatus = solenoidStatus;
        this.usageCount = usageCount;
        this.productionDate = productionDate;
    }
}
