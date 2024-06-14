using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite[] images;
    public GameObject[] panels;

    void Start()
    {
       Sprite img1 = images[Random.Range(0, images.Length)];
        for(int i = 0; i < panels.Length; i++)
        {
           panels[i].GetComponent<Image>().sprite = img1;
        }
    }
}
