using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private float moveSpeed;
    private float destroyXPosition;

    public void Initialize(float speed, float destroyX) // CloudSpawner에서 호출될때 매개변수로 받아서 초기화하기
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
