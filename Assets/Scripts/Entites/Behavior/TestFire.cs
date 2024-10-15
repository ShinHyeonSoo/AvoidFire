using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;

    private int groundTagHash;
    private int playerTagHash;

    private void Awake()
    {
        groundTagHash = "Ground".GetHashCode();
        playerTagHash = "Player".GetHashCode();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌대상 해쉬값 가져오고
        int collisionTagHash = collision.gameObject.GetHashCode();

        if (collisionTagHash == groundTagHash)
        {
            Destroy(gameObject);
        }
        else if (collisionTagHash == playerTagHash)
        {
            //TODO :: 플레이어 데미지 및 오브젝트 파괴,
        }
    }
}
