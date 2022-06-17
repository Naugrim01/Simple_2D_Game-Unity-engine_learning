using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;
    
    public int selsectedResolution;

    public Text resolutionLabel;

    public AudioMixer theMixer;

    public Slider mastSlider, musicSlider, sfxSlider;
        
    public Text mastLabel, musicLabel, sfxLabel;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        //search for resolution in list
        bool foundRes = false;
        for (int i = 0;i < resolutions.Length; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selsectedResolution = i;
                UpdateResLabel();
            }
        }

        if(!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }
        //load last audio settings
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            mastSlider.value = PlayerPrefs.GetFloat("MasterVol");
            mastLabel.text = (mastSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
            musicLabel.text = (musicSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
            sfxLabel.text = (sfxSlider.value + 80).ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selsectedResolution--;
        if (selsectedResolution < 0)
        {
            selsectedResolution = 0;
        }
        UpdateResLabel();
    }
    public void ResRight()
    {
        selsectedResolution++;
        if (selsectedResolution > resolutions.Length - 1)
        {
            selsectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selsectedResolution].horizontal.ToString() + " x " + resolutions[selsectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //apply fullscreen
        //Screen.fullScreen = fullscreenTog.isOn; - moved to "set the resolution"
       
        //apply vsync

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } 
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        //set the resolution

        Screen.SetResolution(resolutions[selsectedResolution].horizontal, resolutions[selsectedResolution].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        mastLabel.text = (mastSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", mastSlider.value);
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value); //remember last setting
    }
    
    public void SetMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value); //remember last setting
    }

    public void SetSFXVol()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value); //remember last setting
    }
}


[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}