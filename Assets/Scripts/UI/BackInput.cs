using UnityEngine;

public class BackInput : MonoBehaviour
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
