using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Functions for setting screen orientaion
    public void ScreenAutoRotate()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void ScreenLandscape()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void ScreenPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Resets PlayerPrefs that contain map names, and highscores
    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
