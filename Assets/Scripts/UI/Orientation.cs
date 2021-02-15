using System.Collections.Generic;
using UnityEngine;

/**
 * Create a list of gameobject pairs that are activated depending on device orientation
 * If screen width is bigger than height the screen is in Landscape it gets activated and portrait disabled
 * Same the other way around
 */
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
