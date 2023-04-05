using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupNat_Enemy_2_Anim_Changer : MonoBehaviour
{
    public Animator enAnim;

    public string currState = "Supernatural_Enemy_2_Idle";



    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimState("Supernatural_Enemy_2_Idle");
    }


    public void ChangeAnimState(string newState, float speed = 1)
    {
        enAnim.speed = speed;

        if (currState == newState)
        {
            return;
        }

        currState = newState;
        enAnim.Play(newState);
    }
}
