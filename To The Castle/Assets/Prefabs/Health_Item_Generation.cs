using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item_Generation : MonoBehaviour
{
    public GameObject taiyaki;
    public GameObject dragonfruit;
    // Start is called before the first frame update
    void Start()
    {
        foodAppear(); 
    }

   void foodAppear()
    {
        StartCoroutine(foodAppearanceRoutine());

        IEnumerator foodAppearanceRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(10f);
                GameObject taiYaki = Instantiate(taiyaki, (new Vector2(Random.Range(-25.30f, 29.01f), -3.206f)), Quaternion.identity);
                GameObject dragonFruit = Instantiate(dragonfruit, (new Vector2(Random.Range(-25.30f, 29.01f), -3.206f)), Quaternion.identity);
                Destroy(taiYaki, 10);
                Destroy(dragonFruit, 10);

            }
        }
    }
}
