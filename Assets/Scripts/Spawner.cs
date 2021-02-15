using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("Player prefab that gets intatiated when spawn is called")]
    public GameObject Player;
    private GameObject thisPlayer;
    private Player playerReference;

    [SerializeField]
    private float spawnDelay = 0.5f;

    /**
     * Instatiate a player prefab on current position
     * Immediately set it inactive, so the gameobject only gets activated when needed
     * Get Player script reference from the instantiated object
     */
    private void Start()
    {
        thisPlayer = Instantiate(Player, this.transform);
        thisPlayer.gameObject.SetActive(false);
        playerReference = thisPlayer.GetComponent<Player>();
    }

    // Used for spawning the players and resetting them to starting position
    public void SpawnPlayers()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Returns if the player reached the goal
    public bool IsPlayerCollided()
    {
        return playerReference.PlayerCollided;
    }

    // Wait for spawnDelay seconds then activate the Player, this is need so Players only spawn after the map has been instatiated
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);

        thisPlayer.transform.position = this.transform.position;
        thisPlayer.gameObject.SetActive(true);
    }
}
