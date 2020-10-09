using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Orientation : MonoBehaviour
{
    [FormerlySerializedAs("Portrait mode")] 
    public GameObject portraitCanvas;
    [FormerlySerializedAs("Landscape mode")]
    public GameObject landscapeCanvas;

    [FormerlySerializedAs("Portrait mode")]
    public GameObject portraitList;
    [FormerlySerializedAs("Landscape mode")]
    public GameObject landscapeList;




    void Update()
    {
        if ( Screen.width > Screen.height )
        {
            portraitCanvas.gameObject.SetActive(false);
            landscapeCanvas.gameObject.SetActive(true);
            portraitList.gameObject.SetActive(false);
            landscapeList.gameObject.SetActive(true);

        } else
        {
            portraitCanvas.gameObject.SetActive(true);
            landscapeCanvas.gameObject.SetActive(false);
            portraitList.gameObject.SetActive(true);
            landscapeList.gameObject.SetActive(false);

        }
    }
}
