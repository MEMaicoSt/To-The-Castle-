using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void seeLvls()
    {
        SceneManager.LoadScene("Level_Selection_Screen");
    }

    public void seeTitleScreen()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
