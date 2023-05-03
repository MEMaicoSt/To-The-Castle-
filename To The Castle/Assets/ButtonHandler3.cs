using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler3 : MonoBehaviour
{
    public void Retry3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void seeLvls3()
    {
        SceneManager.LoadScene("Level_Selection_Screen");
    }

    public void seeTitleScreen3()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
