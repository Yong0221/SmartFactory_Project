using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 생산 스케쥴 관리를 위한 컨테이너 클래스
/// </summary>
public class ProductionScheduleData
{
   public int productionTargetQuantity;
   public float productionRate;
   public DateTime materialSupplyDate;
    
    public ProductionScheduleData(int productionTargetQuantity, float productionRate, DateTime materialSupplyDate) 
    {
        productionTargetQuantity = this.productionTargetQuantity;
        productionRate = this.productionRate;
        materialSupplyDate = this.materialSupplyDate;
    }
}
