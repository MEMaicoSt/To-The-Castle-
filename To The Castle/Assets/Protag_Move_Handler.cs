using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protag_Move_Handler : MonoBehaviour
{

    public Protagonist pgt;


    void FixedUpdate()
    {
        // pgt.Move
        pgt.Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) );
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pgt.Jump();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            pgt.asc.ChangeAnimState("Kick");
        }



    }

    
}
