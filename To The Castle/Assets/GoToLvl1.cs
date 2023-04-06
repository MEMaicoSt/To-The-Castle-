using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLvl1 : MonoBehaviour
{
    
    public void skip()
    {
        SceneManager.LoadScene("Level_1");
    }

   
}
