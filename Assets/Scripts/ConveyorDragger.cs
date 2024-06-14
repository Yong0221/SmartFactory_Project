using UnityEngine;
using UnityEngine.UI;


public class ConveyorDragger : MonoBehaviour
{
    public Image conveyorOnBtn;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Box1" | other.gameObject.tag == "Box2")
        {
            other.transform.SetParent(transform);
            conveyorOnBtn.color = Color.green;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box1" | other.gameObject.tag == "Box2")
        {
            other.transform.SetParent(null);
            conveyorOnBtn.color = Color.white;
        }
    }
}