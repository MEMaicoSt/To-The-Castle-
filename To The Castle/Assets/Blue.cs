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
