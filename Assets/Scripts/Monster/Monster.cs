
using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float minX = -8.3f;
    private float maxX = 8.3f;
    float knockback = 3; // 튕겨나갈 정도
    float knockbackpower = 2; // 튕겨나갈 힘
    public float speed;

    MonsterSpawn monsterSpawn;

    SpriteRenderer monsterRenderer;
    Rigidbody2D rb2d;
    RandomEffectManager randomEffectManager;
    void Update()
    {
        MonsterMove();
    }
    void MonsterMove()
    {
        randomEffectManager = FindObjectOfType<RandomEffectManager>();
        monsterSpawn = GetComponentInParent<MonsterSpawn>();
        monsterRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        if (transform.position.x < minX)
        {
            gameObject.SetActive(false);
            Score.Instance.AddScore(10);
            SoundManager.Instance.Play("sfx_coin", Sound.Sfx);
            EffectManager.Instance.ShotEffect("explosion", transform.position);
        }

        if (transform.position.x > maxX)
        {
            gameObject.SetActive(false);
            Score.Instance.AddScore(10); // 점수올라가는지 확인
            SoundManager.Instance.Play("sfx_coin", Sound.Sfx);
            EffectManager.Instance.ShotEffect("explosion", transform.position);
        }
        if (monsterRenderer.flipX)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        else transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && randomEffectManager.randomEffect == 4)
            
        {
            float dirX = transform.position.x - collision.transform.position.x > 0 ? (knockback) : -(knockbackpower);
            rb2d.AddForce(new Vector2(dirX, (knockback)) * (knockbackpower *3), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            float dirX = transform.position.x - collision.transform.position.x > 0 ? (knockback) : -(knockbackpower);
            rb2d.AddForce(new Vector2(dirX, (knockback)) * (knockbackpower), ForceMode2D.Impulse);
            SoundManager.Instance.Play("collision", Sound.Sfx, 0.5f);
            EffectManager.Instance.ShotEffect("hit", transform.position);
        }
    }

}
