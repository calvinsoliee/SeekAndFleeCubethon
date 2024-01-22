using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{
    public Transform obstacle;
    public Transform target;
    public float maxSpeed = 5f;
    
    public KinematicSteeringOutput GetSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.position - obstacle.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        float targetRotation = Mathf.Atan2(result.velocity.x, result.velocity.z) * Mathf.Rad2Deg;
        obstacle.rotation = Quaternion.Euler(0f, targetRotation, 0f);

        result.rotation = 0;
        return result;
        Debug.Log("Velocity: " + result.velocity);
        Debug.Log("Target Rotation: " + targetRotation);
    }
    public void Update()
    {
        GetSteering();
    }
}

public class KinematicSteeringOutput
{
    public Vector3 velocity;
    public float rotation;
}
