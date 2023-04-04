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

    int health;

    // Start is called before the first frame update
    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        prSpR = GetComponent<SpriteRenderer>();
        health = 100;
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
            if (Input.GetKeyDown(KeyCode.K))
            {
             leProtagAnim.ChangeAnimState("Kick");
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
             leProtagAnim.ChangeAnimState("Protag_Punch");
            }

            leProtagAnim.ChangeAnimState("Idle");
        }

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "taiyaki" || hit.gameObject.tag == "dragonfruit")
        {
            Destroy(hit.gameObject);

           if(health < 100)
            {
                health += 5;
            }
            if(health > 100)
            {
                health = 100;
            }
        }

        if(hit.gameObject.tag == "Enemy" /*and the enemy is attacking while you're not blocking*/)
        {

        }
    }

    //references:
    //https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
    //https://www.youtube.com/watch?v=QRp4V1JTZnM
}
