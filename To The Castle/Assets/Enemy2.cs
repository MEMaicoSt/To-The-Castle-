using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public GameObject en2;

    Rigidbody2D e2RB;

    SpriteRenderer e2SpR;

    float en2RunSpeed = 15.0f;

    public Text protagHasShield;

    public En2AnimChanger leEn2Anim;

    public GameObject Protag;

    public BoxCollider2D passThru;


    float health;

    // Start is called before the first frame update
    void Start()
    {
        e2RB = GetComponent<Rigidbody2D>();
        e2SpR = GetComponent<SpriteRenderer>();


         health = 1.0f;

    }

    void FixedUpdate()
    {
        if (health <= 0.0f)
        {
            leEn2Anim.ChangeAnimState("Enemy2_0_Health");
            e2RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            passThru.isTrigger = true;
        }
        else
        {
            en2run();
        }
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

    void OnCollisionEnter2D(Collision2D hit)
    {

        if (hit.gameObject.tag == "taiyaki" || hit.gameObject.tag == "dragonfruit")
        {
            Destroy(hit.gameObject);
        }

        //If the player collides with you, and she has a shield equipped, you'll take more damage
        if (hit.gameObject.tag == "Player")
        {
            if (protagHasShield.text == "Shield Equipped: 1")
            {
                health -= 0.05f;
            }

            else
            {
                health -= 0.01f;
            }
        }
        //if the enemy is kicked by the player
        if (hit.gameObject.tag == "hit")
        {
            Destroy(hit.gameObject);
            health -= 0.03f;
        }

        //if the enemy is punched by the player
        if (hit.gameObject.tag == "hitpunch")
        {
            Destroy(hit.gameObject);
            health -= 0.04f;
        }

        if (hit.gameObject.tag == "LightningBolt")
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Bat")
        {
            Destroy(hit.gameObject);
        }

    }
}