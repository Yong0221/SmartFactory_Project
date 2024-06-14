using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mxComponent;

public class BoxDetector : MonoBehaviour
{
    public Sensor sensor;
    public string plcAddress_box1;
    public string plcAddress_box2;
    public int plcInputvalue;

    private void Update()
    {
        if (sensor.isObjectDetected)
        {
            switch (sensor.boxName)
            {
                case "Box1":
                    MxComponent.instance.SetDevice(plcAddress_box1, 1);
                    MxComponent.instance.SetDevice(plcAddress_box2, 0);
                    break;

                case "Box2":
                    MxComponent.instance.SetDevice(plcAddress_box2, 1);
                    MxComponent.instance.SetDevice(plcAddress_box1, 0);
                    break;
            }
        }
    }
}
