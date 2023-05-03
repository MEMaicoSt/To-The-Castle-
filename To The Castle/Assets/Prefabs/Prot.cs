using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject hit;

    public GameObject hitPunch;

    public GameObject myProtag;

    public BoxCollider2D passThru;

    public Text currentLvl;

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

            pRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            passThru.isTrigger = true;

            tryAgains();

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
                GameObject hiT = Instantiate(hit, (new Vector2(myProtag.transform.position.x + 1, myProtag.transform.position.y+1)), Quaternion.identity);

            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                leProtagAnim.ChangeAnimState("Protag_Punch");
                
                PUNCH.GetComponent<AudioSource>().Play();
                GameObject hitp = Instantiate(hitPunch, (new Vector2(myProtag.transform.position.x + 1, myProtag.transform.position.y + 1.6f)), Quaternion.identity);
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


        if ((hit.gameObject.tag == "Enemy") && shieldEquip.text != "Shield Equipped: 1")
        {

            hB.localScale = new Vector3((hB.localScale.x - 0.01f), 1f, 1f);

        }

        if(hit.gameObject.tag == "Supernatural_Enemy" && shieldEquip.text != "Shield Equipped: 1")
        {
            hB.localScale = new Vector3((hB.localScale.x - 0.045f), 1f, 1f);
        }


        if (hit.gameObject.tag == "Bat" && shieldEquip.text != "Shield Equipped: 1")
        {
            Destroy(hit.gameObject);

            currX = hB.localScale.x - 0.1f;

            hB.localScale = new Vector3(currX, 1f, 1f);
        }
        if (hit.gameObject.tag == "Bat" && shieldEquip.text == "Shield Equipped: 1")
        {
            Destroy(hit.gameObject);
        }


        if (hit.gameObject.tag == "LightningBolt" && shieldEquip.text != "Shield Equipped: 1")
        {
            Destroy(hit.gameObject);
            hB.localScale = new Vector3((hB.localScale.x - 0.08f), 1f, 1f);
        }
        if (hit.gameObject.tag == "LightningBolt" && shieldEquip.text == "Shield Equipped: 1")
        {
            Destroy(hit.gameObject);         
        }

        if (hit.gameObject.tag == "Finish_Flag")
        {
            Destroy(hit.gameObject);
            SceneManager.LoadScene("Level_2");
        }

        if (hit.gameObject.tag == "Finish_Flag2")
        {
            Destroy(hit.gameObject);
            SceneManager.LoadScene("Level_3");
        }

        if(hit.gameObject.tag == "FinaleFlag")
        {
            Destroy(hit.gameObject);
            toEndingCutscene();

        }

        if (hit.gameObject.tag == "hit")
        {
            Destroy(hit.gameObject);          
        }

        if (hit.gameObject.tag == "hitpunch")
        {
            Destroy(hit.gameObject);
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

    void tryAgains()
    {
        StartCoroutine(tryAgainsRoutine());

        IEnumerator tryAgainsRoutine()
        {
            yield return new WaitForSeconds(4f);

            if(currentLvl.text == "Level 1")
            {
                SceneManager.LoadScene("TryAgain_Lvl1");
            }

            if (currentLvl.text == "Level 2")
            {
                SceneManager.LoadScene("TryAgain_Lvl2");
            }

            if (currentLvl.text == "Level 3")
            {
                SceneManager.LoadScene("TryAgain_Lvl3");
            }
        }
    }

    void toEndingCutscene()
    {
        StartCoroutine(toEndingCutsceneRoutine());

        IEnumerator toEndingCutsceneRoutine()
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("Ending_Cutscene");
        }
    }

     
    //references:
    //https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
    //https://www.youtube.com/watch?v=QRp4V1JTZnM
    //https://docs.unity3d.com/ScriptReference/AudioSource.Play.html

}
