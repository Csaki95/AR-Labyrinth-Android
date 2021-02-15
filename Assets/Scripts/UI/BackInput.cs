using UnityEngine;

public class BackInput : MonoBehaviour
{
    // Checks every frame if Android back button got pressed, disables current object. This is used in Main menu exiting submenus
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
