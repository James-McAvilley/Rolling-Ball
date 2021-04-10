using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer mixer;
    public Dropdown resDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void Fullscreen(bool FullScreen)
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);

    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
}
