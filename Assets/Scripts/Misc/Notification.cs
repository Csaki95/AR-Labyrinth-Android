using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("doNotify", 1) == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void doNotNotify()
    {
        PlayerPrefs.SetInt("doNotify", 0);
    }
}
