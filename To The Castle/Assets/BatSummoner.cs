using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSummoner : MonoBehaviour
{
    public GameObject bat;
    public GameObject Protag;
   

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

            if (Protag.transform.position.y <= bAt.transform.position.y - 20.0f)
            {
                bAt.transform.position = Vector2.MoveTowards(new Vector2(bAt.transform.position.x, bAt.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), 15.0f * Time.fixedDeltaTime);
            }

                Destroy(bAt, 4);

                yield return new WaitForSeconds(1f);
                GameObject bAt2 = Instantiate(bat, (new Vector2(Random.Range(-25.0f, 29.0f), 16.15f)), Quaternion.identity);

            if (Protag.transform.position.y <= bAt2.transform.position.y - 20.0f)
            {
                bAt2.transform.position = Vector2.MoveTowards(new Vector2(bAt2.transform.position.x, bAt2.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), 15.0f * Time.fixedDeltaTime);
            }

            Destroy(bAt2, 4);

                yield return new WaitForSeconds(1f);
                GameObject bAt3 = Instantiate(bat, (new Vector2(Random.Range(-25.0f, 29.0f), 16.15f)), Quaternion.identity);

            if (Protag.transform.position.y <= bAt3.transform.position.y - 10.0f)
            {
                bAt3.transform.position = Vector2.MoveTowards(new Vector2(bAt3.transform.position.x, bAt3.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), 15.0f * Time.fixedDeltaTime);
            }

            Destroy(bAt3, 4);


        }
    }
   
}
