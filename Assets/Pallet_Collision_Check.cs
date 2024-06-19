using UnityEngine;

public class Pallet_Collision_Check : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("물체 충돌 감지");

        // 충돌한 게임오브젝트의 이름을 출력
        print("충돌한 물체: " + collision.gameObject.name);

        // 충돌한 게임오브젝트의 태그를 출력
        print("충돌한 물체의 태그: " + collision.gameObject.tag);

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
            print("다른물체 충돌");
        }
    }
}
