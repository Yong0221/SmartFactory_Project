using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Logs : MonoBehaviour
{
    StreamWriter writer;

    void Awake()
    {
        writer = new StreamWriter("Assets/Scripts/Data/SystemLog.txt");
        Application.logMessageReceived += saveLog;
    }

    void saveLog(string logString, string stackTrace, LogType type)
    {
        string currentTime = DateTime.Now.ToString(("HH:mm:ss"));
        writer.WriteLine($"[{currentTime}] {logString}");
    }

    void OnDisable()
    {
        Application.logMessageReceived -= saveLog;

        writer.Flush();
        writer.Close();
    }
}
