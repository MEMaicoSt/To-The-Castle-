using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundOptions : MonoBehaviour
{
    public AudioMixer AMix;
    public Slider masterVol;
    public Slider musicVol;
    public Slider sfxVol;


    public Image optionsMenu1;

    void Start()
    {

        if (PlayerPrefs.GetInt("set first time volume") == 0)
        {
            PlayerPrefs.SetInt("set first time volume", 1);
            masterVol.value = .25f;
            musicVol.value = .25f;
            sfxVol.value = .25f;
        }
        else
        {
            masterVol.value = PlayerPrefs.GetFloat("MasterVolume");
            musicVol.value = PlayerPrefs.GetFloat("MusicVolume");
            sfxVol.value = PlayerPrefs.GetFloat("SFXVolume");
        }

    }


    public void SetMasterVolume()
    {
        SetVolume("MasterVolume", masterVol.value);
    }

    public void SetMusicVolume()
    {
        SetVolume("MusicVolume", musicVol.value);
    }

    public void SetSFXVoume()
    {
        SetVolume("SFXVolume", sfxVol.value);
    }


    void SetVolume(string name, float value)
    {
        float volume = Mathf.Log10(value) * 20;
        if (value == 0)
        {
            volume = -80;
        }


        AMix.SetFloat(name, volume);
        PlayerPrefs.SetFloat(name, value);
    }



    public void back2Main()
    {
        optionsMenu1.gameObject.SetActive(false);
    }

   


}
