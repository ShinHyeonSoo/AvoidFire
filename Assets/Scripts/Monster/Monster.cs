
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float minX = -8.3f;
    private float maxX = 8.3f;

    MonsterSpawn monsterSpawn;

    SpriteRenderer monsterRenderer;

    void Update()
    {
        MonsterMove();
    }
    void MonsterMove()
    {
        monsterSpawn = GetComponentInParent<MonsterSpawn>();
        monsterRenderer = GetComponent<SpriteRenderer>();

        if (transform.position.x < minX)
        {
            //monsterRenderer.flipX = false;
            gameObject.SetActive(false);
        }

        //몬스터를 뽑을때 flip되게 해야겟다 
        if (transform.position.x > maxX)
        {
            //monsterRenderer.flipX = true;
            gameObject.SetActive(false);
        }
        if (monsterRenderer.flipX)
            transform.Translate(Vector3.left * monsterSpawn.speed * Time.deltaTime);

        else transform.Translate(Vector3.right * monsterSpawn.speed * Time.deltaTime);
    }
}
