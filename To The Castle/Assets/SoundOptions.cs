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

    public void back2Main()
    {
        optionsMenu1.gameObject.SetActive(false);
    }


}
