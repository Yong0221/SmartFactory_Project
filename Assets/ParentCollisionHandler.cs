using UnityEngine;

public class ParentCollisionHandler : MonoBehaviour
{
    // B�� C�� Collider�� ������ ����
    public Collider colliderB;
    public Collider colliderC;

    void Start()
    {
        // �ʱ�ȭ �� collider�� null�� ��� ã��
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
        // B�� C�� �浹 ����
        if (colliderB != null && colliderC != null && colliderB.bounds.Intersects(colliderC.bounds))
        {
            // C�� A�� �ڽ����� ����
            colliderC.transform.parent = this.transform;
        }
    }
}
