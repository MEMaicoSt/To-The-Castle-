using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En2AnimChanger : MonoBehaviour
{
    public Animator en2Anim;

    public string currState = "Enemy2Idle";



    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimState("Enemy2Idle");
    }


    public void ChangeAnimState(string newState, float speed = 1)
    {
        en2Anim.speed = speed;

        if (currState == newState)
        {
            return;
        }

        currState = newState;
        en2Anim.Play(newState);
    }
}

