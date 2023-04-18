using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Summoner : MonoBehaviour
{
    public GameObject Bat;
    
    void Start()
    {
        batAppear();
    }

   void batAppear()
    {
        StartCoroutine(batAttackRoutine());

        IEnumerator batAttackRoutine()
        {
            yield return new WaitForSeconds(1f);
           GameObject bat = Instantiate(Bat, (new Vector2(Random.Range(-30.72f, -21.12f), 13.96f)), Quaternion.identity);


        }



    }
}
