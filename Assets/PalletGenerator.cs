using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PalletGenerator : MonoBehaviour
{
    public GameObject pallet;
   
    // Start is called before the first frame update

    public void pallet1GenerateBtnClkEvnt()
    {
        GameObject newObject = Instantiate(pallet,transform.position,transform.rotation);
        newObject.GetComponent<MeshRenderer>().enabled=true;
        newObject.tag = "Pallet1";
        

    }
    public void pallet2GenerateBtnClkEvnt()
    {
        GameObject newObject = Instantiate(pallet, transform.position, transform.rotation);
        newObject.GetComponent<MeshRenderer>().enabled = true;
        newObject.tag = "Pallet2";

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
