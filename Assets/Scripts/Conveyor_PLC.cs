using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using box_Location;
using mxComponent;
using UnityEditor.MemoryProfiler;

public class Conveyor_PLC : MonoBehaviour
{
   
    public Box_Location box_Location;
    public ConveyorData conveyorData;
    private void Update()
    {
        if(MxComponent.instance.connection == MxComponent.Connection.Connected
            && conveyorData.plcInputValue != 0&&!box_Location.isBeltMoving )
        {
            box_Location.beltOnBtnClkEvnt();
         
        }
    }
}
