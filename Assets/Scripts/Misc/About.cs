using UnityEngine;

public class About : MonoBehaviour
{
    // Just opens a website, nothing else
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
