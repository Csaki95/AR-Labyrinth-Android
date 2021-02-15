using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("Scene changing animation settings:")]
    [Tooltip("Reference to the selected animation")]
    public Animator transition;
    [Tooltip("Time between animation start and loading the next scene. This number must be bigger, or equal to the scene exit animation")]
    public float transitionTime = 1.0f;
    public bool isMap = false;

    public void Start()
    {
        // Setting available from editor, if true it skips the scene opening animation
        transition.SetBool("IsMap", isMap);
    }

    public void SceneLoader(int sceneID)
    {
        // Reset timeScale in case scenechange got called from paused state, or slowed down state
        Time.timeScale = 1.0f;
        StartCoroutine(LoadScene(sceneID));
    }

    // Trigger the animation, wait for transition time seconds before loading next scene
    IEnumerator LoadScene(int sceneID)
    {
        transition.SetTrigger("Transition_Trigger");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneID);
    }
}
