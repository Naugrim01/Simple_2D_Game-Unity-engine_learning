using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGraphics()
    {
        //apply fullscreen
        Screen.fullScreen = fullscreenTog.isOn;
       
        //apply vsync

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } 
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
