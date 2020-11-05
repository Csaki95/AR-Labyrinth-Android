using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool playerCollision;
    private new Rigidbody rigidbody;

    private void Start()
    {
        playerCollision = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool isCollided()
    {
        return playerCollision;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Exit")
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            playerCollision = true;
        }
    }
}
