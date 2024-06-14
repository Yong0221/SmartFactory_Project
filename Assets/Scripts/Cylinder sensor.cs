using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mxComponent;

public class CylinderSensor : MonoBehaviour
{
    [SerializeField]
    [Header("데이터")]
    public SwitchSensorData switchSensorData;

    [Header("상태")]
    public Cylinder cylinder = Cylinder.Conveyor_PushCylinder;
    public enum Cylinder
    {
        Conveyor_PushCylinder,
        Conveyor_GateCylinder,
        LoadingSys_X_Transfer,
        LoadingSys_LM_Transfer,
        LoadingSys_Z_Transfer,
        LoadingSys_LoadCylinder,
    }

    public Position position = Position.전진센서;
    public enum Position
    {
        전진센서,
        중간센서,
        후진센서
    }

    public bool isObjectDetected = false;

    public string plcAddress;
    public int plcInputValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slider"))
        {
            isObjectDetected = true;
            plcInputValue = 1;
            MxComponent.instance.SetDevice(plcAddress, plcInputValue);
            //로그
            if (position == Position.전진센서)
            {
                print(this.cylinder + " - 전진 상태입니다");
            }
            else if (position == Position.후진센서)
            {
                print(this.cylinder + " - 후진 상태입니다");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slider"))
        {
            isObjectDetected = false;
            plcInputValue = 0;
            MxComponent.instance.SetDevice(plcAddress, plcInputValue);
        }
    }
}