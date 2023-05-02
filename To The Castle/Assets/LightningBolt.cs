using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public GameObject LightningBolT;
    public GameObject Protag;

    float Protagx;
    float Protagy;

    public void zap()
    {

        StartCoroutine(zapRoutine());

        IEnumerator zapRoutine()
        {
            Protagx = Protag.transform.position.x;
            Protagy = Protag.transform.position.y;

            yield return new WaitForSeconds(2f);
            GameObject lBolt = Instantiate(LightningBolT, new Vector2(Protagx, Protagy +  20.6f), Quaternion.identity);

            Destroy(lBolt, 5);

            while (lBolt != null)
            {
                lBolt.transform.position = Vector2.MoveTowards(new Vector2(lBolt.transform.position.x, lBolt.transform.position.y), new Vector2(Protagx, Protagy), 25.0f * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();
            }
        }
    }

  
}
