using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text testOutput;

    public GameObject TargetLostScreen;

    public GameObject mapPrefab;

    public List<Spawner> spawners = new List<Spawner>();

    public AugmentedImageController augmentedImageController;

    public GameObject VictoryScreen;

    private Vector3 TargetPosition;
    private Quaternion TargetRotation;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        UnPause();
    }

    private void Update()
    {
        if (CollisionCheck()) Victory();
        MapTracking();

        testOutput.text = TargetPosition.ToString();
    }

    public void SpawnPlayer()
    {
        foreach(Spawner spawnpoint in spawners)
        {
            spawnpoint.spawnPlayers();
        }
    }

    public void Pause()
    {
        TargetLostScreen.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
    }

    private void MapTracking()
    {
        if(augmentedImageController.imageTrackingState)
        {
            TargetPosition = augmentedImageController.targetPosition;
            TargetRotation = augmentedImageController.targetRotation;
            mapPrefab.transform.localPosition = augmentedImageController.targetPosition;
            mapPrefab.transform.rotation = augmentedImageController.targetRotation;
            mapPrefab.SetActive(true);
            TargetLostScreen.SetActive(false);
        } else
        {
            mapPrefab.SetActive(false);
            TargetLostScreen.SetActive(true);
        }
    }

    private bool CollisionCheck()
    {
        foreach (Spawner spawner in spawners)
        {
            if (spawner.isPlayerCollided() == false) return false;
        }
        return true;
    }

    private void Victory()
    {
        TargetLostScreen.gameObject.SetActive(false);
        VictoryScreen.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
