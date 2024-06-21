using UnityEngine;

public class ParentCollisionHandler : MonoBehaviour
{
    // B와 C의 Collider를 저장할 변수
    public Collider colliderB;
    public Collider colliderC;

    void Start()
    {
        // 초기화 및 collider가 null인 경우 찾기
        if (colliderB == null)
        {
            colliderB = GameObject.Find("B").GetComponent<Collider>();
        }

        if (colliderC == null)
        {
            colliderC = GameObject.Find("C").GetComponent<Collider>();
        }
    }

    void Update()
    {
        // B와 C의 충돌 감지
        if (colliderB != null && colliderC != null && colliderB.bounds.Intersects(colliderC.bounds))
        {
            // C를 A의 자식으로 설정
            colliderC.transform.parent = this.transform;
        }
    }
}
