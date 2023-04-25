using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSummoner : MonoBehaviour
{
    public GameObject bat;
    public GameObject Protag;

    SpriteRenderer bSpR;
   

    /*void Start()
    {
        
       BatAttack();
    }

   */

    

    public void BatAttack()
    {
       StartCoroutine(BatAttackRoutine());

        IEnumerator BatAttackRoutine()
        {
           
                yield return new WaitForSeconds(1f);
                GameObject bAt = Instantiate(bat, (new Vector2(Random.Range(-25.0f, 29.0f), 16.15f)), Quaternion.identity);
                Destroy(bAt, 4);
               while (bAt != null)
            {  
                bAt.transform.position = Vector2.MoveTowards(new Vector2(bAt.transform.position.x, bAt.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), 15.0f * Time.fixedDeltaTime);

                bSpR = bAt.GetComponent<SpriteRenderer>();

                if ((Protag.transform.position.x < 0 && bAt.transform.position.x > 0) || (Protag.transform.position.x > 0 && bAt.transform.position.x < 0) || (Protag.transform.position.x < 0 && bAt.transform.position.x < 0))
                {
                    bSpR.flipX = false;
                }
                else
                {
                    bSpR.flipX = true;
                }

                yield return new WaitForFixedUpdate();

            }
        }
    }
   
}
