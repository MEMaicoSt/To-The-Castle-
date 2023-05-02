using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stray_Projectile_Banisher : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "hit")
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "hitpunch")
        {
            Destroy(hit.gameObject);
        }


        if (hit.gameObject.tag == "LightningBolt")
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Bat")
        {
            Destroy(hit.gameObject);
        }

    }
}
