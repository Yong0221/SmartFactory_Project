using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// 생산처리에 대한 내용을 관리하는 컨테이너 클래스
/// </summary>
public class ProductionProcessData
{
    public float timeNeeded;
    public float timeProcessed;
    public int amountUsed;
    public int amountRemaining;
    public string processStatus;
    public bool safetyStatus;

    public ProductionProcessData(float timeNeeded, float timeProcessed, int amountUsed, int amountRemaining, string processStatus, bool safetyStatus)
    {
        timeNeeded = this.timeNeeded;
        timeProcessed = this.timeProcessed;
        amountUsed = this.amountUsed;
        amountRemaining = this.amountRemaining;
        processStatus = this.processStatus;
        safetyStatus = this.safetyStatus;
    }

    public float GettimeNeeded()
    {
        return this.timeNeeded;
    }
    public float GettimeProcessed()
    {
        return this.timeProcessed;
    }
    public int GetamountUsed()
    {
        return this.amountUsed;
    }
    public int GetamountRemaining()
    {
        return this.amountRemaining;
    }
    public string GetprocessStatus()
    {
        return this.processStatus;
    }
    public bool GetsafetyStatus()
    {
        return this.safetyStatus;
    }
}

