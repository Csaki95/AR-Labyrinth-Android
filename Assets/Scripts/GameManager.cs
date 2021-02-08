using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const string VICTORYTEXT = "You won!";
    private const string LOSTTEXT = "Ran out of time...";

    public Text statusOutput;
    public GameObject TargetLostScreen;
    public GameObject ResultScreen;
    public GameObject PauseScreen;
    public TMP_Text responseOutput;

    public GameObject mapPrefab;
    public List<Spawner> spawners = new List<Spawner>();
    public AugmentedImageController augmentedImageController;
    public int maxTime = 40;
    public string highScoreName;

    private Vector3 TargetPosition;
    private Quaternion TargetRotation;

    private int finishedPlayers;
    private int playerCount;

    private bool isTracked;
    private bool isPaused;
    private bool isEnded;
    private bool initialTrack;
    private int countdownTime;
    private int topScore;
    private SceneChange sceneChange;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        isPaused = false;
        isEnded = false;
        isTracked = false; 
        initialTrack = true;
        playerCount = spawners.Count;
        countdownTime = maxTime;
        sceneChange = new SceneChange();
        topScore = PlayerPrefs.GetInt(highScoreName, maxTime);
        StartCoroutine(CountDownTimer());
        UnPause(false);
    }

    private void Update()
    {
        MapTracking();
        FinishedPlayerCount();
        StatusOutput();
        BackButton();
        if (isTracked && !isPaused && initialTrack) SpawnPlayer();
        if (finishedPlayers == playerCount) EndGame(true);
        if (countdownTime == 0 && finishedPlayers != playerCount) EndGame(false);
    }

    // used for spawning, or reseting ball position to original spawnpoint
    public void SpawnPlayer()
    {
        foreach(Spawner spawnpoint in spawners)
        {
            spawnpoint.spawnPlayers();
        }
        countdownTime = maxTime;
        initialTrack = false;
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void UnPause(bool forSceneChange)
    {
        if(!forSceneChange) isPaused = false;
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
            isTracked = true;
        } else
        {
            mapPrefab.SetActive(false);
            TargetLostScreen.SetActive(true);
            isTracked = false;
        }
    }

    private void StatusOutput()
    {
        if (isTracked && !isEnded)
        {
            statusOutput.text = countdownTime.ToString() + " sec | " + finishedPlayers.ToString() + " / " + playerCount.ToString();
            TargetLostScreen.SetActive(false);
        }
        else if(!isEnded)
        {
            statusOutput.text = "Waiting for target";
            if (isPaused)
            {
                TargetLostScreen.SetActive(false);
            } 
            else
            {
                TargetLostScreen.SetActive(true);
            }
        }
    }

    private void FinishedPlayerCount()
    {
        finishedPlayers = 0;
        foreach (Spawner spawner in spawners)
        {
            if (spawner.isPlayerCollided() == true) finishedPlayers++;
        }
    }

    private void EndGame(bool isVictory)
    {
        int elapsedTime = maxTime - countdownTime;
        TargetLostScreen.SetActive(false);
        ResultScreen.gameObject.SetActive(true);
        if (isVictory)
        {
            if (topScore > elapsedTime)
            {
                PlayerPrefs.SetInt(highScoreName, elapsedTime);
                responseOutput.text = VICTORYTEXT + "\n in: " + elapsedTime.ToString() + " seconds" + "\n New Record!";
            }
            else
            {
                responseOutput.text = VICTORYTEXT + "\n in: " + elapsedTime.ToString() + " seconds";
            }
        }
        else
        {
            responseOutput.text = LOSTTEXT;
        }
        Time.timeScale = 0.25f;
    }

    private void BackButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PauseScreen.activeSelf)
            {
                sceneChange.SceneLoader(0);
            } 
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
                PauseScreen.SetActive(true);
            }
        }
    }

    IEnumerator CountDownTimer()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);

            if(isTracked && !isPaused && finishedPlayers != playerCount) 
                countdownTime--;
        }
    }
}
