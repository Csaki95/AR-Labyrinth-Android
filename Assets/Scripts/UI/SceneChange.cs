using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SceneLoader(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
