using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Result screen text for Victory and Lose condition
    private const string VICTORYTEXT = "You won!";
    private const string LOSTTEXT = "Ran out of time...";

    // References for GameManager related UI gameObjects
    [Header("UI references")]
    [Tooltip("Status Text element, if target is found display current number of balls in the goal, else show \"Waiting for target\"")]
    public Text statusOutput;
    [Tooltip("Activate this gameObject when target is lost")]
    public GameObject TargetLostScreen;
    [Tooltip("Activate this gameObject when game ended")]
    public GameObject ResultScreen;
    [Tooltip("Activate this gameObject when game is paused, or back button was pressed")]
    public GameObject PauseScreen;
    [Tooltip("TextMeshPro output for game end result")]
    public TMP_Text responseOutput;

    // Core game components
    [Header("Core game components")]
    [Tooltip("Reference to the map holder gameObject that's placed on target image")]
    public GameObject mapPrefab;
    [Tooltip("Reference to the spawners in the current map")]
    public List<Spawner> spawners = new List<Spawner>();
    [Tooltip("ARCore requirement, controller for image tracking")]
    public AugmentedImageController augmentedImageController;

    [Header("Map settings")]
    [Tooltip("Max time on current level (seconds)")]
    public int maxTime = 40;
    [Tooltip("Map name (case sensitive and used to get the highscore in main menu)")]
    public string highScoreName;

    // Used for counting and displaying the current number of balls in goal
    private int finishedPlayers;
    private int playerCount;

    // Status, and misc variables (usage explained in their methods)
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
        sceneChange = gameObject.AddComponent<SceneChange>();
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
            spawnpoint.SpawnPlayers();
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
            if (spawner.IsPlayerCollided() == true) finishedPlayers++;
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
