using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    // Public variables to assign the player and teleportation target in the Unity Inspector
    public GameObject playerObject;
    public GameObject teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject entering the trigger is the player
        if (other.gameObject == playerObject)
        {
            // Check if a teleport target has been set
            if (teleportTarget != null)
            {
                // Set the player's position to the teleport target's position
                playerObject.transform.position = teleportTarget.transform.position;
            }
            else
            {
                // Log a warning message if no target has been set
                Debug.LogWarning("Teleportation target not assigned.");
            }
        }
    }
}
