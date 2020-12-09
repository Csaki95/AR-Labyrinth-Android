using UnityEngine;

public class Player : MonoBehaviour
{
    private bool atGoal;

    private void Start()
    {
        atGoal = false;
    }

    public bool playerCollided()
    {
        return atGoal;
    }

    private void OnTriggerEnter(Collider other)
    {
        atGoal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        atGoal = false;
    }
}
