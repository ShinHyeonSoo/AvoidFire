using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int hp;
    private float minX = -8f;
    private float maxX = 8f;
    private int groundTagHash;
    private int playerTagHash;
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

        monsterSpawn.speed =3;
        monsterSpawn.hp =3;
        monsterSpawn.MonsterType();


        if (transform.position.x <= minX)
            monsterRenderer.flipX = false;

        if (transform.position.x >= maxX)
            monsterRenderer.flipX = true;

        if (monsterRenderer.flipX)
            transform.Translate(Vector3.left * monsterSpawn.speed * Time.deltaTime);

        else transform.Translate(Vector3.right * monsterSpawn.speed * Time.deltaTime);
    }
}
