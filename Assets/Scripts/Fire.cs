
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire : MonoBehaviour
{
    public GameObject fireobj;
    float size;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start 함수 실행");
        Spawnfire();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setfire()
    {

        GameObject fire = Instantiate(fireobj, this.transform);
        rb2D = fire.GetComponent<Rigidbody2D>();

        float x = Random.Range(-9f, 9f);
        fire.transform.localPosition = new Vector2(x, 5);

        int Randomtype = Random.Range(1, 4);

        switch (Randomtype)
        {
            case 1:
                size = 1.5f;
                rb2D.gravityScale = Randomtype;
                break;
            case 2:
                size = 2f;
                rb2D.gravityScale = Randomtype;
                break;
            case 3:
                size = 3f;
                rb2D.gravityScale = Randomtype;
                break;

        }
        fire.transform.localScale = new Vector2(size, size);
    }
    public void Spawnfire()
    {
        InvokeRepeating("Setfire", 0f, .3f);
    }


}
