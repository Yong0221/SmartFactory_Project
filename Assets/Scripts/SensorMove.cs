using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorMove : MonoBehaviour
{
    float[] box1Size;
    float[] box2Size;
    public enum BoxSize
    {
        box1,
        box2
    }
    public BoxSize boxSize = BoxSize.box1;
    public Sensor sensor;
    Vector3 sensorOrigin;

    // Start is called before the first frame update
    void Start()
    {
        box1Size = new float[] { 0.22f, 0.19f, 0.09f };
        box2Size = new float[] { 0.271f, 0.181f, 0.0151f };
        sensorOrigin = sensor.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (sensor.isObjectDetected)
        {
            StartCoroutine(TransTarget(boxSize, sensor, sensorOrigin));
        }
    }

    IEnumerator TransTarget(BoxSize _boxsize, Sensor _sensor, Vector3 _sensorOrigin)
    {

        switch (_boxsize)
        {
            case BoxSize.box1:
                {
                    Vector3 box1Target = _sensorOrigin;
                    box1Target.x += box1Size[1] + 0.01f;
                    if (sensor.sensorData.usageCount % 25 == 0)
                    {
                        box1Target.z = 0;
                        box1Target.x = 0;
                        box1Target.y -= box1Size[2];
                    }
                    else if (sensor.sensorData.usageCount % 5 == 0)
                    {
                        box1Target.y = 0;
                        box1Target.z -= box1Size[0];
                    }
                    _sensor.transform.localPosition = Vector3.Lerp(_sensorOrigin, box1Target, 3f);
                    sensorOrigin = box1Target;
                    break;
                }

            case BoxSize.box2:
                {
                    Vector3 box2Target = _sensorOrigin;
                    box2Target.y -= box2Size[1] + 0.005f;
                    if (sensor.sensorData.usageCount % 25 == 0)
                    {
                        box2Target.y = 0;
                        box2Target.x = 0;
                        box2Target.z -= box2Size[2];
                    }
                    else if (sensor.sensorData.usageCount % 5 == 0)
                    {
                        box2Target.y = 0;
                        box2Target.x -= box2Size[0];
                    }
                    _sensor.transform.localPosition = Vector3.Lerp(_sensorOrigin, box2Target, 1f);
                    sensorOrigin = box2Target;
                    break;
                }
        }

        yield return new WaitForSeconds(2f);
    }
}