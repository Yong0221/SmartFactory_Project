using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class ScreenChange : MonoBehaviour

{ public GameObject[] panels;
  public TMP_Text text;
  public TMP_InputField inputPW;
  public Button accessBtn;
    public PrivateInformation info;


    private void Start()
    {
/*        ScreenChanger(0);
        text.GetComponent<TMP_Text>();*/
    }
    
    public void ScreenChanger(int panelIndex)
    {

        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[panelIndex].SetActive(true);
    }

    private void Update()
    {
        if (panels[0].activeSelf == true && Input.GetMouseButton(0))
        {
            OnFirstAccessEvent();
        }
        if (panels[1].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            AccessMain();
        }
    }

    public void OnFirstAccessEvent()
    {
        ScreenChanger(1);
        text.text = Environment.MachineName;
    }

    public void AccessMain()
    {
        if (inputPW.text == info.pinNumber)
        {
            ScreenChanger(2);
        }
        else
        {
            print("PIN번호 오류");
        }
    }
}

