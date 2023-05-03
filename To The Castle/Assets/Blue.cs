using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blue : MonoBehaviour
{
    public GameObject blue;

    Rigidbody2D blueRB;

    SpriteRenderer blueSpR;

    float blueRunSpeed = 15.0f;

    public Blue_Anim_Changer leEnAnim;

    public GameObject Protag;

    public LightningBolt zapProtag;

    public Text protagHasShield;

    float health;

    public BoxCollider2D passThru;

    

    // Start is called before the first frame update
    void Start()
    {
        blueRB = blue.GetComponent<Rigidbody2D>();
        blueSpR = blue.GetComponent<SpriteRenderer>();

        health = 1.0f;

    }


    void FixedUpdate()
    {
        if (health <= 0.0f)
        {
            leEnAnim.ChangeAnimState("Blue_0_Health");
            blueRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            passThru.isTrigger = true;
        }
        else
        {
            blueRun();
        }
    }

    void blueRun()
    {



        //If the protagonist gets close, run towards her.
        if (Protag.transform.position.x >= blue.transform.position.x - 20.0f)
        {


            //if the protagonist is at a certain distance, summon a lightning bolt to come towards her
            if (Protag.transform.position.x <= blue.transform.position.x - 12.0f)
            {
                zapProtag.zap();
            }



            leEnAnim.ChangeAnimState("Blue_Run");
            transform.position = Vector2.MoveTowards(new Vector2(blue.transform.position.x, blue.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), blueRunSpeed * Time.fixedDeltaTime);


            if ((Protag.transform.position.x < 0 && blue.transform.position.x > 0) || (Protag.transform.position.x > 0 && blue.transform.position.x < 0) || (Protag.transform.position.x < 0 && blue.transform.position.x < 0))
            {
                blueSpR.flipX = true;
            }
            else
            {
                blueSpR.flipX = false;
            }

        }

        else
        {
            leEnAnim.ChangeAnimState("Blue_Idle");
        }

    }

    void OnCollisionEnter2D(Collision2D hit)
    {

        if (hit.gameObject.tag == "taiyaki" || hit.gameObject.tag == "dragonfruit")
        {
            Destroy(hit.gameObject);
            health += 0.08f;

            if (health >= 1.0f)
            {
                health = 1.0f;
            }
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
