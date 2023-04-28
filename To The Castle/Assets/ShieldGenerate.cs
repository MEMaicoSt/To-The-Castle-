using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerate : MonoBehaviour
{
    public GameObject sHield;

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
                GameObject shiEld = Instantiate(sHield, (new Vector2(Random.Range(-33.8f,14.52f), -3.2064f)), Quaternion.identity);

                Destroy(shiEld, 9);



            }
        
        }



    }
}
