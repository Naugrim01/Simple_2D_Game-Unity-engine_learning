using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;
    
    public int selsectedResolution;

    public Text resolutionLabel;

    // Start is called before the first frame update
    void Start()
    {
        
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
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}