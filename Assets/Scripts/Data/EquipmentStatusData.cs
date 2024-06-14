using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 설비상태를 나타내기 위한 컨테이너 클래스
/// </summary>
public class EquipmentStatusData
{
    public string name;
    public bool operationStatus;
    public bool malfunctionStatus;
    public bool maintenanceStatus;

    //초기화
    public EquipmentStatusData(string name, bool operationStatus, bool malfunctionStatus, bool maintenanceStatus)
    {
        this.name = name;
        this.operationStatus = operationStatus;
        this.malfunctionStatus = malfunctionStatus;
        this.maintenanceStatus = maintenanceStatus;
    }

    public bool GetoperationStatus()
    {
        return this.operationStatus;
    }
    public bool GetmalfunctionStatus()
    {
        return this.malfunctionStatus;
    }
    public bool GetmaintenanceStatus()
    {
        return this.malfunctionStatus;
    }
}
