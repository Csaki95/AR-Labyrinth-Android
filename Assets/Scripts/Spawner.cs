using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Player;

    private Transform position;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());

        position = this.transform;
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);

        Instantiate(Player, position);
    }
}
