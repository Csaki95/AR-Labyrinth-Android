﻿using UnityEngine;

public class Notification : MonoBehaviour
{
    // Checking if opening notification has been disabled once before
    void Start()
    {
        if (PlayerPrefs.GetInt("doNotify", 1) == 0)
        {
            this.gameObject.SetActive(false);
        } else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void DoNotNotify()
    {
        PlayerPrefs.SetInt("doNotify", 0);
    }
}
