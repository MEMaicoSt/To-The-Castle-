using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Anim_Changer : MonoBehaviour
{
    public Animator enAnim;

    public string currState = "Enemy1Idle";



    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimState("Enemy1Idle");
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
