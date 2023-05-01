using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerate : MonoBehaviour
{
    public GameObject sHield;
    public GameObject Protag;

    // Start is called before the first frame update
    void Start()
    {
        shieldAppear();
    }

   void shieldAppear()
    {
        StartCoroutine(shieldAppearanceRoutine());

        IEnumerator shieldAppearanceRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(8f);
                GameObject shiEld = Instantiate(sHield, (new Vector2(Random.Range(Protag.transform.position.x - 5.0f, Protag.transform.position.x + 3.6f), -3.2064f)), Quaternion.identity);

                Destroy(shiEld, 9);



            }
        
        }



    }
}
