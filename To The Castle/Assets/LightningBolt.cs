using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public GameObject LightningBolT;
    public GameObject Protag;
   
    

    public void zap()
    {

        StartCoroutine(zapRoutine());

        IEnumerator zapRoutine()
        {
            yield return new WaitForSeconds(2f);
            GameObject lBolt = Instantiate(LightningBolT, new Vector2(Protag.transform.position.x, Protag.transform.position.y +  20.6f), Quaternion.identity);

            Destroy(lBolt, 6);

            while (lBolt != null)
            {
                lBolt.transform.position = Vector2.MoveTowards(new Vector2(lBolt.transform.position.x, lBolt.transform.position.y), new Vector2(Protag.transform.position.x, Protag.transform.position.y), 25.0f * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();
            }
        }
    }

  
}
