using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private float moveSpeed;
    private float destroyXPosition;

    public void Initialize(float speed, float destroyX) // CloudSpawner���� ȣ��ɶ� �Ű������� �޾Ƽ� �ʱ�ȭ�ϱ�
    {
        moveSpeed = speed;
        destroyXPosition = destroyX;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.x > destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
