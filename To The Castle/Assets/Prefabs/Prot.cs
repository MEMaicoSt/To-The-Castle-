using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Prot : MonoBehaviour
{

    public GameObject PUNCH;
    public GameObject KICK;
   

    Rigidbody2D pRB;

    SpriteRenderer prSpR;

    float runSpeed = 30.0f;

    Vector3 thisWaythisSpeed;

    public Protag_Anim_Changer leProtagAnim;

    public Transform hB;

    public float currX;

    public Text shieldEquip;

    // Start is called before the first frame update
    void Start()
    {
        pRB = GetComponent<Rigidbody2D>();
        prSpR = GetComponent<SpriteRenderer>();

        hB.localScale = new Vector3(1f, 1f, 1f);

       
        shieldEquip.text = "Shield Equipped: 0";
 
    }


    void FixedUpdate()
    {

        
         if (hB.localScale.x <= 0)
        {
            hB.localScale = new Vector3(0f, 1f, 1f);

            leProtagAnim.ChangeAnimState("Protag_0_Health");
           

        }
        else
        {
            run();
        }

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
                
                KICK.GetComponent<AudioSource>().Play();

            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                leProtagAnim.ChangeAnimState("Protag_Punch");
                
                PUNCH.GetComponent<AudioSource>().Play();

            }

            
            leProtagAnim.ChangeAnimState("Idle");
        }

       

    }


    

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "taiyaki" || hit.gameObject.tag == "dragonfruit")
        {
            Destroy(hit.gameObject);


            hB.localScale = new Vector3((hB.localScale.x + 0.2f), 1f, 1f);

            if (hB.localScale.x > 1)
            {
                hB.localScale = new Vector3(1f, 1f, 1f);
            }


        }

        if(hit.gameObject.tag == "Shield")
        {
            Destroy(hit.gameObject);
            temporaryShieldEquip();
        }


        if ((hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "Supernatural_Enemy") && shieldEquip.text != "Shield Equipped: 1")
        {

            hB.localScale = new Vector3((hB.localScale.x - 0.01f), 1f, 1f);

        }

       

        if(hit.gameObject.tag == "Bat")
        {
            Destroy(hit.gameObject);

            currX = hB.localScale.x - 0.1f;

            hB.localScale = new Vector3(currX, 1f, 1f);
        }


    }

    
     void temporaryShieldEquip(){
     
     StartCoroutine(temporaryShieldEquipRoutine());
     
      IEnumerator temporaryShieldEquipRoutine(){   

        yield return new WaitForSeconds(0.1f);

       shieldEquip.text = "Shield Equipped: 1";

        yield return new WaitForSeconds(20f);

        shieldEquip.text = "Shield Equipped: 0";


     }
     }

     
    //references:
    //https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
    //https://www.youtube.com/watch?v=QRp4V1JTZnM
    //https://docs.unity3d.com/ScriptReference/AudioSource.Play.html

}
