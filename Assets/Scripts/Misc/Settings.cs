using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    
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

    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
