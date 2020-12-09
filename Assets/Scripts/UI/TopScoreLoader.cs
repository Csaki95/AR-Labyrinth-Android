using TMPro;
using UnityEngine;

public class TopScoreLoader : MonoBehaviour
{
    public TMP_Text label;
    public TMP_Text highScore;

    public string mapName;

    void Start()
    {
        label.text = mapName;
        highScore.text = "Personal best: " + PlayerPrefs.GetInt(mapName, 0).ToString() + "s";
    }
}
