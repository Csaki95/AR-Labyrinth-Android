using TMPro;
using UnityEngine;

/**
 * PlayerPrefs contains higscore to every map
 * Maps identifiers are case specific and have to be set on both the highscore end, and 
 */
public class TopScoreLoader : MonoBehaviour
{
    [Tooltip("Reference to text that displays map name")]
    public TMP_Text label;
    [Tooltip("Reference to text that displays higscore")]
    public TMP_Text highScore;

    [Header("Highscore identifier")]
    [Tooltip("Case sensitive identifier that is set on each map. Highscore is save by this and gets called here the same way. " +
        "If the added identifier does not have a highscore yet it's defaulted to 0")]
    public string mapName;

    void Start()
    {
        label.text = mapName;
        highScore.text = "Personal best: " + PlayerPrefs.GetInt(mapName, 0).ToString() + "s";
    }
}
