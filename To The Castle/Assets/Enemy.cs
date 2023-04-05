using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject en;

    Rigidbody2D eRB;

    SpriteRenderer eSpR;

    float enRunSpeed = 15.0f;

   

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
            transform.position = Vector2.MoveTowards(new Vector2(en.transform.position.x, en.transform.position.y), new Vector2(Protag.transform.position.x,Protag.transform.position.y), enRunSpeed*Time.deltaTime);

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


    //references:
    //https://www.google.com/search?q=how+do+you+get+the+position+of+a+game+object&rlz=1C1CHBF_enUS894US894&oq=how+do+you+get+the+position+of+a+game+object&aqs=chrome..69i57j33i10i160l2.7960j0j7&sourceid=chrome&ie=UTF-8
    //https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html



}
