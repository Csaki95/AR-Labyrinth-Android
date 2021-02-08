using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;

    public void SceneLoader(int sceneID)
    {
        StartCoroutine(LoadScene(sceneID));
    }

    IEnumerator LoadScene(int sceneID)
    {
        transition.SetTrigger("Transition_Trigger");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneID);
    }
}
