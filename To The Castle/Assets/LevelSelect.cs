using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void goLvl1()
    {
        SceneManager.LoadScene("Opening_Cutscene");
    }

    public void goBack()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
