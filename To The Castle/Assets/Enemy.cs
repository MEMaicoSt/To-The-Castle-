using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject en;

    Rigidbody2D eRB;

    SpriteRenderer eSpR;

    float enRunSpeed = 15.0f;


    public Enemy_1_Anim_Changer leEnAnim;

    public GameObject Protag;

    public Text protagHasShield;

    public BoxCollider2D passThru;
    

    float health;

    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
        eSpR = GetComponent<SpriteRenderer>();

        
        health = 1.0f;

    }


    void FixedUpdate()
    {
        if (health <= 0.0f)
        {
             leEnAnim.ChangeAnimState("Enemy_1_0_Health");
            eRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            passThru.isTrigger = true;
           
        }
        else
        {
            enrun();
        }
    }

    void enrun()
    {

       

        //If the protagonist gets close, run towards her.
        if(Protag.transform.position.x >= en.transform.position.x - 20.0f)
        {


            leEnAnim.ChangeAnimState("Enemy_1_Running");
            transform.position = Vector2.MoveTowards(new Vector2(en.transform.position.x, en.transform.position.y), new Vector2(Protag.transform.position.x,Protag.transform.position.y), enRunSpeed*Time.fixedDeltaTime);

           if((Protag.transform.position.x < 0 && en.transform.position.x > 0) || (Protag.transform.position.x > 0 && en.transform.position.x < 0) || (Protag.transform.position.x < 0 && en.transform.position.x < 0))
            {
                eSpR.flipX = true;
            }
            else
            {
                eSpR.flipX = false;
            }
        }
        else
        {
            leEnAnim.ChangeAnimState("Enemy1Idle");
        }
       
    }

    void OnCollisionEnter2D(Collision2D hit)
    {

        if (hit.gameObject.tag == "taiyaki" || hit.gameObject.tag == "dragonfruit")
        {
            Destroy(hit.gameObject);
            health += 0.01f;
        }

            //If the player collides with you, and she has a shield equipped, you'll take more damage
            if (hit.gameObject.tag == "Player")
        {
           if(protagHasShield.text == "Shield Equipped: 1")
            {
                health -= 0.05f;
            }

            else
            {
                health -= 0.002f;
            }
        }
        //if the enemy is kicked by the player
        if(hit.gameObject.tag == "hit")
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


    //references:
    //https://www.google.com/search?q=how+do+you+get+the+position+of+a+game+object&rlz=1C1CHBF_enUS894US894&oq=how+do+you+get+the+position+of+a+game+object&aqs=chrome..69i57j33i10i160l2.7960j0j7&sourceid=chrome&ie=UTF-8
    //https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html
    // https://answers.unity.com/questions/810742/freeze-position-in-2d.html
    //https://docs.unity3d.com/ScriptReference/Collider-isTrigger.html

}
