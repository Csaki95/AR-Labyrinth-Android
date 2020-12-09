using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Orientation : MonoBehaviour
{
    public List<CanvasPairs> orientations = new List<CanvasPairs>();

    void Update()
    {
        if ( Screen.width > Screen.height )
        {
            foreach(CanvasPairs canvas in orientations)
            {
                canvas.Landscape.SetActive(true);
                canvas.Portrait.SetActive(false);
            }
        } else
        {
            foreach (CanvasPairs canvas in orientations)
            {
                canvas.Portrait.SetActive(true);
                canvas.Landscape.SetActive(false);
            }
        }
    }
}
