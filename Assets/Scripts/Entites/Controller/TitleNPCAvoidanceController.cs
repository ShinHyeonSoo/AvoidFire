using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleNPCAvoidanceController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float avoidDistance = 2f;
    //���������� �Ѱ谪 �ֱ�
    [SerializeField] private float boundaryX = 8f;

    private Vector2 movementDirection;
    private int fireTagHash;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        fireTagHash = "Fire".GetHashCode();

        movementDirection = Vector2.right;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        GameObject closestFire = FindClosestFire();
        if (closestFire != null)
        {
            AvoidFire(closestFire.transform.position);
        }
        else
        {
            MoveContinuously();
        }

        MoveNPC();
    }

    GameObject FindClosestFire()
    {
        GameObject[] fires = GameObject.FindGameObjectsWithTag("Fire");
        GameObject closestFire = null;
        float closestDistance = detectionRange;

        foreach (GameObject fire in fires)
        {
            if (fire.tag.GetHashCode() == fireTagHash)
            {
                float distanceToFire = Vector2.Distance(transform.position, fire.transform.position);

                if (distanceToFire < closestDistance)
                {
                    closestFire = fire;
                    closestDistance = distanceToFire;
                }
            }
        }
        //���� ����� ��(������null)
        return closestFire;
    }

    void AvoidFire(Vector2 firePosition)
    {
        Vector2 directionAwayFromFire = (transform.position - (Vector3)firePosition).normalized;
        //Y������Ұ�
        movementDirection = new Vector2(directionAwayFromFire.x, 0) * avoidDistance;
    }

    // �Ѱ谪 ���޽� �ݴ�� �̵�
    void MoveContinuously()
    {
        if (transform.position.x < -boundaryX)
        {
            movementDirection = Vector2.right;
        }
        else if (transform.position.x > boundaryX)
        {
            movementDirection = Vector2.left;
        }
    }

    void MoveNPC()
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        if (movementDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
