using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PalletGenerator : MonoBehaviour
{
    public GameObject pallet;
   
    // Start is called before the first frame update

    public void palletGenerateBtnClkEvnt()
    {
        GameObject newObject = Instantiate(pallet,transform.position,transform.rotation);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
