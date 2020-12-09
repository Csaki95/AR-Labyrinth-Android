using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Player;
    private GameObject thisPlayer;
    private Player playerReference;

    [SerializeField]
    private float spawnDelay = 0.5f;

    private void Start()
    {
        thisPlayer = Instantiate(Player, this.transform);
        thisPlayer.gameObject.SetActive(false);
        playerReference = thisPlayer.GetComponent<Player>();
    }

    public void spawnPlayers()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public bool isPlayerCollided()
    {
        return playerReference.playerCollided();
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);

        thisPlayer.transform.position = this.transform.position;
        thisPlayer.gameObject.SetActive(true);
    }
}
