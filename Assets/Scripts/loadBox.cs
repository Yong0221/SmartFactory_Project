using UnityEngine;

public class loadBox : MonoBehaviour
{
    private Transform loadFixedPart; // Load ������
    public bool[] isBoxLoading;//0���ּ� ���� 1ȣ�ڽ� 2ȣ�ڽ�, ���� �ڽ� �߰� ����
    public GameObject colliedBox1;
    public GameObject colliedBox2;
    public float box1Count;
    public float box2Count;
<<<<<<< HEAD
    public bool once;
=======
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e

    void Start()
    {
        isBoxLoading = new bool[2];//�̺κп��� ���ڰ� ���� ��Ʈ���� �ڽ� ����
        // ��Ȯ�� ��θ� �����Ͽ� Load ������ ������Ʈ�� ã���ϴ�.
        string path = "LoadSystem��/Assy-50-Drive/Assy-52_LMGuideSystem/LM���ۺ�/Assy-53_X-Transfer/X���ۺ�/Xȸ����/Assy-54_Z-Transfer/Z���ۺ�/Assy-55_LoadingSystem/Load������";
        GameObject loadFixedPartObject = GameObject.Find(path);

        if (loadFixedPartObject != null)
        {
            loadFixedPart = loadFixedPartObject.transform;
        }
        else
        {
            Debug.LogError("Load ������ object not found! Ensure the path is correct and the object exists in the scene.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box1"))
        {
<<<<<<< HEAD
            if (once)
            {
                box1Count++;
                once = false;
            }
=======
            box1Count++;
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
            colliedBox1 = collision.gameObject;
            if (collision.transform.parent == null)
                collision.transform.SetParent(loadFixedPart);
            print("box1�浹");

            for (int i = 0; i < isBoxLoading.Length; i++)
                isBoxLoading[i] = false;
            isBoxLoading[0] = true;

        }
        else if (collision.gameObject.CompareTag("Box2"))
        {
<<<<<<< HEAD
            if (once)
            {
                box2Count++;
                once = false;
            }
=======
            box2Count++;
>>>>>>> 7400ff6e079360163c7d9584eab358354e17346e
            colliedBox2 = collision.gameObject;
            if (collision.transform.parent == null)
                collision.transform.SetParent(loadFixedPart);
            for (int i = 0; i < isBoxLoading.Length; i++)
                isBoxLoading[i] = false;
            isBoxLoading[1] = true;
        }
    }



}
