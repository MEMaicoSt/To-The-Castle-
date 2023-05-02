using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public GameObject blue;

    Rigidbody2D blueRB;

    SpriteRenderer blueSpR;

    float blueRunSpeed = 15.0f;

    public Blue_Anim_Changer leEnAnim;

    public GameObject Protag;

    public Flamingo fgo;

    public LightningBolt zapProtag;


    // Start is called before the first frame update
    void Start()
    {
        blueRB = GetComponent<Rigidbody2D>();
        blueSpR = GetComponent<SpriteRenderer>();

    }


    void FixedUpdate()
    {

        blueRun();

    }

    void blueRun()
    {



        //If the protagonist gets close, run towards her.
        if (Protag.transform.position.x >= blue.transform.position.x - 20.0f)
        {

            if (Protag.transform.position.y >= 8.7f)
            {
                //summon the giant bird that will fly toward the protagonist and lower her health
                
            }

            //if the protagonist is at a certain distance, summon a lightning bolt to come towards her
            if (Protag.transform.position.x <= blue.transform.position.x - 12.0f)
            {
                zapProtag.zap(); 
            }

            //if the Protagonist is close enough, start kicking
            if (Protag.transform.position.x <= blue.transform.position.x - 8.0f)
            {

            }


            leEnAnim.ChangeAnimState("");
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


            leEnAnim.ChangeAnimState("");

        }

    }



}
