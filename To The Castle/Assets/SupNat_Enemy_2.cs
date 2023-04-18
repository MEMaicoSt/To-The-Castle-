using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupNat_Enemy_2 : MonoBehaviour
{
    public GameObject supEn2;

    Rigidbody2D supEn2RB;

    SpriteRenderer se2SpR;

    float supEn2RunSpeed = 15.0f;

    public SupNat_Enemy_2_Anim_Changer leEnAnim;

    public GameObject Protag;

    public GameObject Bat;

    // int health;

    // Start is called before the first frame update
    void Start()
    {
        supEn2RB = GetComponent<Rigidbody2D>();
        se2SpR = GetComponent<SpriteRenderer>();


        // health = 100;

    }


    void FixedUpdate()
    {

        supEn2run();

    }

    void supEn2run()
    {



        //If the protagonist gets close, run towards her.
        if (Protag.transform.position.x >= supEn2.transform.position.x - 20.0f)
        {
           //If the protagonist is close enough, summon bats to attack the protagonist.
            if (Protag.transform.position.x <= supEn2.transform.position.x - 14.0f )
            {
               
                leEnAnim.ChangeAnimState("Supernatural_Enemy_2_Sp_Att"); 
                batSummon();
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

    
    void batSummon()
    {
        StartCoroutine(BatAttackRoutine());

        IEnumerator BatAttackRoutine()
        {
          yield return new WaitForSeconds(3f);
          GameObject bat = Instantiate(Bat, (new Vector2(Random.Range(-30.0f,-22.0f), 13.77f)), Quaternion.identity);
          Destroy(bat, 10);
        }
    }

    
}
