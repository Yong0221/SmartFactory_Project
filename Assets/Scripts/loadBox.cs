using UnityEngine;

public class loadBox : MonoBehaviour
{
    private Transform loadFixedPart; // Load 고정부
    public bool[] isBoxLoading;//0번주소 부터 1호박스 2호박스, 추후 박스 추가 가능
    public GameObject colliedBox1;
    public GameObject colliedBox2;

    void Start()
    {
        isBoxLoading = new bool[2];//이부분에서 숫자가 현재 컨트롤할 박스 종류
        // 정확한 경로를 지정하여 Load 고정부 오브젝트를 찾습니다.
        string path = "LoadSystem부/Assy-50-Drive/Assy-52_LMGuideSystem/LM동작부/Assy-53_X-Transfer/X동작부/X회전부/Assy-54_Z-Transfer/Z동작부/Assy-55_LoadingSystem/Load고정부";
        GameObject loadFixedPartObject = GameObject.Find(path);

        if (loadFixedPartObject != null)
        {
            loadFixedPart = loadFixedPartObject.transform;
        }
        else
        {
            Debug.LogError("Load 고정부 object not found! Ensure the path is correct and the object exists in the scene.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box1"))
        {
            colliedBox1 = collision.gameObject;
            collision.transform.SetParent(loadFixedPart);
            print("box1충돌");

            for (int i=0; i<isBoxLoading.Length; i++)
                isBoxLoading[i] = false;
            isBoxLoading[0] = true;
      
        }
        else if (collision.gameObject.CompareTag("Box2"))
        {
            colliedBox2 = collision.gameObject;
                        collision.transform.SetParent(loadFixedPart);
            for (int i = 0; i < isBoxLoading.Length; i++)
                isBoxLoading[i] = false;
            isBoxLoading[1] = true;
        }
    }


}
