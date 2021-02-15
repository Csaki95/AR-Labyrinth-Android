using Michsky.UI.ModernUIPack;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Sound switches")]
    public SwitchManager soundSwitchPort;
    public SwitchManager soundSwitchLand;
    [Header("Orientation Horizontal Selectors")]
    public HorizontalSelector horizontalSelectorPort;
    public HorizontalSelector horizontalSelectorLand;
    private bool isMuted = false;
    private int selectedIndex = 0;

    private void Update()
    {
        if (Screen.width < Screen.height)
        {
            soundSwitchPort.isOn = isMuted;
            horizontalSelectorPort.SetIndex(selectedIndex);
        }
        else
        {
            soundSwitchLand.isOn = isMuted;
            horizontalSelectorLand.SetIndex(selectedIndex);
        }
    }

    // Functions for setting screen orientaion
    public void ScreenAutoRotate()
    {
        selectedIndex = 0;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void ScreenLandscape()
    {
        selectedIndex = 1;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void ScreenPortrait()
    {
        selectedIndex = 2;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Mute Audio
    public void MuteAudio()
    {
        isMuted = true;
        AudioListener.volume = 0.0F;
    }

    public void UnMuteAudio()
    {
        isMuted = false;
        AudioListener.volume = 1.0F;
    }

    // Resets PlayerPrefs that contain map names, and highscores
    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
