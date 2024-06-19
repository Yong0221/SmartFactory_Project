using UnityEngine;

public class Pallet_Collision_Check : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("��ü �浹 ����");

        // �浹�� ���ӿ�����Ʈ�� �̸��� ���
        print("�浹�� ��ü: " + collision.gameObject.name);

        // �浹�� ���ӿ�����Ʈ�� �±׸� ���
        print("�浹�� ��ü�� �±�: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Pallet1"))
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            print("pallet1");
        }
        else if (collision.gameObject.CompareTag("Pallet2"))
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            print("pallet2");
        }
        else
        {
            print("�ٸ���ü �浹");
        }
    }
}
