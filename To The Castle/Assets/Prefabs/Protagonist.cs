using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    
    Rigidbody2D pRB;

    SpriteRenderer prSpR;

    float runSpeed = 30.0f;

    Vector3 thisWaythisSpeed;

    public Protag_Anim_Changer leProtagAnim;

    // Start is called before the first frame update
    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        prSpR = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {

        run();
        
    }

    void run()
    {
        thisWaythisSpeed = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * runSpeed);

        GetComponent<Rigidbody2D>().MovePosition(transform.position + thisWaythisSpeed);

        if (thisWaythisSpeed != Vector3.zero)
        {

            thisWaythisSpeed.Normalize();
            thisWaythisSpeed *= Time.fixedDeltaTime;

            leProtagAnim.ChangeAnimState("Protag_Run");

            if ((thisWaythisSpeed.x < 0 && thisWaythisSpeed.y > 0) || (thisWaythisSpeed.x < 0 && thisWaythisSpeed.y < 0) || (thisWaythisSpeed.x < 0))
            {
                prSpR.flipX = true;
            }
            else
            {
                prSpR.flipX = false;
            }
        }
        else
        {
            //if (Input.GetKeyDown(KeyKode.K))
           // {
           //  leProtagAnim.ChangeAnimState("Kick");
           // }

            leProtagAnim.ChangeAnimState("Idle");
        }
    }
}
