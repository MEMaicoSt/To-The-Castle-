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

    public void goLvl2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void goLvl3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void goBack()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
