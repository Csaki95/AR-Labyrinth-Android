using UnityEngine;

public class Player : MonoBehaviour
{
    // Public property for getting if the Player object inside or outside the goal collider
    public bool PlayerCollided => atGoal;
    private bool atGoal = false;

    private void OnTriggerEnter(Collider other)
    {
        atGoal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        atGoal = false;
    }
}
