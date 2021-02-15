using Michsky.UI.ModernUIPack;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Sound switches")]
    public SwitchManager soundSwitchPort;
    public SwitchManager soundSwitchLand;
    [Header("Orientation switches")]
    public SwitchManager rotationSwitchPort;
    public SwitchManager rotationSwitchLand;
    private bool isMuted = false;
    private bool isRotationFrozen = false;

    private void Update()
    {
        soundSwitchPort.isOn = isMuted;
        rotationSwitchPort.isOn = isRotationFrozen;
        soundSwitchLand.isOn = isMuted;
        rotationSwitchLand.isOn = isRotationFrozen;
    }

    // Functions for setting screen orientaion
    public void ScreenAutoRotate()
    {
        isRotationFrozen = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void ScreenPortrait()
    {
        isRotationFrozen = true;
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
