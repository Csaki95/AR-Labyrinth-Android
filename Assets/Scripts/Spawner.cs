using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Player Player;

    private float spawnDelay = 0.5f;

    private void Start()
    {
        Instantiate(Player, this.transform);
        Player.gameObject.SetActive(false);
    }

    public void spawnPlayers()
    {
        StartCoroutine(ExampleCoroutine());

    }

    public bool isPlayerCollided()
    {
        return Player.isCollided();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);

        Player.transform.position = this.transform.position;
        Player.gameObject.SetActive(true);
    }
}
