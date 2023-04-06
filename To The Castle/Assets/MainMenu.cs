using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void goToLvlScreen()
    {
        SceneManager.LoadScene("Level_Selection_Screen");
    }

    
    public void Quit()
    {
        Application.Quit(); 
    }
}
