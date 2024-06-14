using System;

[Serializable]
public class ConveyorStatusData
{
    public enum Direction
    {
        Forward,
        Reverse
    }
    public string name;                            //컨베이어 이름
    public string serialNumber;                //컨베이어 시리얼넘버
    public string manufacturer;               //컨베이어 제조사
    public bool operationStatus;             //작동유무
    public Direction direction;                 //방향
    public float speed;                             //속도
    public bool overloadStatus;              //운반중 유무
    public bool malfunctionStatus;         //고장유무
    public bool maintenanceStatus;       //정비필요유무
    public int usageCount;                      //사용횟수
    public string productionDate;    //제조년월일

    // 생성자
    public ConveyorStatusData(string name, string serialNumber, string manufacturer,Direction direction, int usageCount, string productionDate)
    {
        this.name = name;
        this.serialNumber = serialNumber;
        this.manufacturer = manufacturer;
        this.direction = direction;
        this.usageCount = usageCount;
        this.productionDate = productionDate;
    }
}
