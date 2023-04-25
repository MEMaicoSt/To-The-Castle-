using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Anim_Changer : MonoBehaviour
{
    public Animator enAnim;

    public string currState = "SupNat2Idle";



    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimState("SupNat2Idle");
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
