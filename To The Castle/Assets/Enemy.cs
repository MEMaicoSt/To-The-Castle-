using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject en;

    Rigidbody2D eRB;

    SpriteRenderer eSpR;

    //float runSpeed = 15.0f;

   // Vector3 thisWaythisSpeed;

    public Enemy_1_Anim_Changer leEnAnim;

    public GameObject Protag;

   // int health;

    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
        eSpR = GetComponent<SpriteRenderer>();
       // health = 100;

    }


    void FixedUpdate()
    {

        enrun();

    }

    void enrun()
    {
        //If the protagonist gets close, run towards her.
        if(Protag.transform.position.x >= en.transform.position.x - 20.0f)
        {
            leEnAnim.ChangeAnimState("Enemy_1_Running");
        }
        else
        {
            leEnAnim.ChangeAnimState("Enemy1Idle");
        }
       
    }

    

  

}
