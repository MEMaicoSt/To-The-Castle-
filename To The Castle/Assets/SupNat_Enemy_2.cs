using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupNat_Enemy_2 : MonoBehaviour
{
    public GameObject supEn2;

    Rigidbody2D supEn2RB;

    SpriteRenderer se2SpR;

    float supEn2RunSpeed = 15.0f;

    public SupNat_Enemy_2_Anim_Changer leEnAnim;

    public GameObject Protag;

    public BatSummoner bSummon;

    public Text protagHasShield;

    float health;

    public BoxCollider2D passThru;


    // Start is called before the first frame update
    void Start()
    {
        supEn2RB = GetComponent<Rigidbody2D>();
        se2SpR = GetComponent<SpriteRenderer>();

         health = 1.0f;

    }


    void FixedUpdate()
    {
        if (health <= 0.0f)
        {
            leEnAnim.ChangeAnimState("Supernatural_Enemy_2_0_Health");
            supEn2RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            passThru.isTrigger = true;
        }
        else
        {
            supEn2run();
        }
    }

    void supEn2run()
    {



        //If the protagonist gets close, run towards her.
        if (Protag.transform.position.x >= supEn2.transform.position.x - 20.0f)
        {
            
           //If the protagonist is close enough, summon bats to attack the protagonist.
            if (Protag.transform.position.x <= supEn2.transform.position.x - 12.0f )
            {
                
                bSummon.BatAttack();
                
            }
           
           

            leEnAnim.ChangeAnimState("Supernatural_Enemy_2_Run");
            transform.position = Vector2.MoveTowards(new Vector2(supEn2.transform.position.x, supEn2.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), supEn2RunSpeed * Time.fixedDeltaTime);


            if ((Protag.transform.position.x < 0 && supEn2.transform.position.x > 0) || (Protag.transform.position.x > 0 && supEn2.transform.position.x < 0) || (Protag.transform.position.x < 0 && supEn2.transform.position.x < 0))
            {
                se2SpR.flipX = true;
            }
            else
            {
                se2SpR.flipX = false;
            }
        
           
        } 
        
        else
        {
          

            leEnAnim.ChangeAnimState("Supernatural_Enemy_2_Idle"); 
           
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
                health -= 0.01f;
            }

            else
            {
                health -= 0.005f;
            }
        }
        //if the enemy is kicked by the player
        if (hit.gameObject.tag == "hit")
        {
            Destroy(hit.gameObject);
            health -= 0.02f;
        }

        //if the enemy is punched by the player
        if (hit.gameObject.tag == "hitpunch")
        {
            Destroy(hit.gameObject);
            health -= 0.01f;
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

    //Reference: https://medium.com/eincode/unity-fundamentals-moving-a-game-object-179f708c5d36#:~:text=You%20can%20change%20the%20object,transform%20property%20of%20the%20object.&text=%2C1%2C1)-,transform.,Simple%20as%20that!


}
