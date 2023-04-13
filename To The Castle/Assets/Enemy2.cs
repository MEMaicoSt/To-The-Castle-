using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject en2;

    Rigidbody2D e2RB;

    SpriteRenderer e2SpR;

    float en2RunSpeed = 15.0f;



    public En2AnimChanger leEn2Anim;

    public GameObject Protag;

    // int health;

    // Start is called before the first frame update
    void Start()
    {
        e2RB = GetComponent<Rigidbody2D>();
        e2SpR = GetComponent<SpriteRenderer>();


        // health = 100;

    }


    void FixedUpdate()
    {

        en2run();

    }

    void en2run()
    {



        //If the protagonist gets close, run towards her.
        if (Protag.transform.position.x >= en2.transform.position.x - 20.0f)
        {

            leEn2Anim.ChangeAnimState("Enemy_2_Running");
            transform.position = Vector2.MoveTowards(new Vector2(en2.transform.position.x, en2.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), en2RunSpeed * Time.fixedDeltaTime);

            if ((Protag.transform.position.x < 0 && en2.transform.position.x > 0) || (Protag.transform.position.x > 0 && en2.transform.position.x < 0) || (Protag.transform.position.x < 0 && en2.transform.position.x < 0))
            {
                e2SpR.flipX = true;
            }
            else
            {
                e2SpR.flipX = false;
            }
        }
        else
        {
            leEn2Anim.ChangeAnimState("Enemy2Idle");
        }

    }
}