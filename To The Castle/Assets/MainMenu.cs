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

    //references: https://stackoverflow.com/questions/49460877/unity-image-enabled-false-does-not-work#:~:text=In%20Unity%20in%20order%20to,need%20to%20instantiate%20the%20object.

}
