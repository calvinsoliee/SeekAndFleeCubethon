using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee : MonoBehaviour
{
    public Transform character;
    public Transform threat;
    public float maxSpeed = 5f;

    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        // Calculate the direction away from the threat
        result.velocity = character.position - threat.position;

        // Normalize the direction and apply max speed
        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        // Face away from the threat
        float targetRotation = Mathf.Atan2(result.velocity.x, result.velocity.z) * Mathf.Rad2Deg;
        character.rotation = Quaternion.Euler(0f, targetRotation, 0f);

        result.rotation = 0;
        return result;
    }

    private void Update()
    {
        // Call the fleeing behavior in the Update method
        GetSteering();
    }
}

public class KinematicFleeingOutput
{
    public Vector3 velocity;
    public float rotation;
}
