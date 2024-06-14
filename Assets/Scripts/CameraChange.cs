using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraChange : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject[] cameraList;

    private void Start()
    {
        dropdown.options.Clear();
        
        for(int i = 0; i < cameraList.Length; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = cameraList[i].name.ToString();
            dropdown.options.Add(option);
        }

    }
    IEnumerator CameraChanger(int index)
    {
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].SetActive(false);
        }
        cameraList[index].SetActive(true);

        yield return new WaitForSeconds(1);
    }

    public void Update()
    {
        StartCoroutine (CameraChanger(dropdown.value));
    }

}
