using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private PlayerCollision playerCollision;

    private Rigidbody rigidbody;

    private void Start()
    {
        playerCollision.isCollided = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Exit")
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            playerCollision.isCollided = true;
        }
    }
}
