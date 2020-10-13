using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<PlayerCollision> playerCollisions;

    [SerializeField]
    private GameObject TrackingLostScreen;
    [SerializeField]
    public GameObject VictoryScreen;

    // Start is called before the first frame update
    private void Awake()
    {
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;

    }

    private void Update()
    {
        if (collisionCheck()) victory();

    }

    public void pause()
    {
        Time.timeScale = 0.0f;
    }

    public void unPause()
    {
        Time.timeScale = 1.0f;
    }

    private bool collisionCheck()
    {
        foreach (PlayerCollision i in playerCollisions)
        {
            if (i.isCollided == false) return false;
        }
        return true;
    }

    private void victory()
    {
        VictoryScreen.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
