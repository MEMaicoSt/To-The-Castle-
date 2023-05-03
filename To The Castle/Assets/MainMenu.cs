using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image optionsMenu;

    
    public void goToLvlScreen()
    {
        SceneManager.LoadScene("Level_Selection_Screen");
    }

    
    public void Quit()
    {
        Application.Quit(); 
    }

    public void mySoundOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
    }


}
