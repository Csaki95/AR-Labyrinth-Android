using UnityEngine;

[System.Serializable]
public class CanvasPairs
{
    public GameObject Portrait;
    public GameObject Landscape;

    public CanvasPairs(GameObject port, GameObject land)
    {
        this.Portrait = port;
        this.Landscape = land;
    }
}
