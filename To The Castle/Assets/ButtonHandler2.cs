using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler2 : MonoBehaviour
{
    public void Retry2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void seeLvls2()
    {
        SceneManager.LoadScene("Level_Selection_Screen");
    }

    public void seeTitleScreen2()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
