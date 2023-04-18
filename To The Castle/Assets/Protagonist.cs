using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float speed = 8.5f;
    public Protag_Anim_Changer asc;

    public bool platformingProtag = true; //when true, change behavior to work like 2D platformer char

    public float jumpVel = 50;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void Move(Vector3 offset)
    {
        if (offset != Vector3.zero)
        {
            offset.Normalize();
            //offset *= Time.fixedDeltaTime;
            //rb.MovePosition(transform.position + ((offset)*speed));
            Vector3 vel = offset *= speed;
            if (platformingProtag)
            {
                rb.velocity = new Vector2(vel.x, rb.velocity.y);
            }
            else
            {
                rb.velocity = vel;
            }


            asc.ChangeAnimState("Protag_Run");
            if (offset.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            
            Stop();
            //asc.ChangeAnimationState("Idle"); 
        }
    }

    public void Stop()
    {
        //return;
        if (platformingProtag)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        asc.ChangeAnimState("Idle");


    }

    public void MoveToward(Vector3 position)
    {
        Move(position - transform.position);
    }

    public void Jump()
    {
        if (!platformingProtag)
        {
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpVel);

    }

    
}
