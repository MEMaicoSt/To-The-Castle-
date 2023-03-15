using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag_Anim_Chooser : MonoBehaviour
{
    public Animator protagAnim;
    public string currSt = "Idle";


    // Start is called before the first frame update
    IEnumerator Start()
    {
        ChangeAnimState("Idle");
        yield return new WaitForSeconds(1);
        ChangeAnimState("Idle");
    }

   

    public void ChangeAnimState(string newState, float speed = 1)
    {
        protagAnim.speed = speed;

        if(currSt == newState)
        {
            return;
        }

        currSt = newState;
        protagAnim.Play(newState);
        
    }
}
