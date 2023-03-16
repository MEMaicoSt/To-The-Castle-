using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag_Anim_Changer : MonoBehaviour
{
    public Animator proAnim;

    public string currState = "Idle";



    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimState("Idle");
    }

   
    public void ChangeAnimState(string newState, float speed = 1)
    {
        proAnim.speed = speed;
        
        if(currState == newState)
        {
            return;
        }

        currState = newState;
        proAnim.Play(newState);
    }
}
