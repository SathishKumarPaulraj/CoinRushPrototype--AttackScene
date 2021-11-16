using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parabolic Missile
/// < para > Calculating trajectory and steering </para >
/// <para>ZhangYu 2019-02-27</para>
/// </summary>
public class Missile : MonoBehaviour
{

    public Transform target; //target
    public float hight = 16f; // parabolic height
    public float gravity = 9.8f; // gravitational acceleration
    private Vector3 position; //My position
    private Vector3 dest; //Target location
    private Vector3 Velocity; //Motion Velocity
    private float time = 0; // Motion time

    private void Start()
    {
        dest = target.position;
        position = transform.position;
        Velocity = PhysicsUtil.GetParabolaInitVelocity(position, dest, gravity, hight, 0);
        transform.LookAt(PhysicsUtil.GetParabolaNextPosition(position, Velocity, gravity, Time.deltaTime));
    }

    private void Update()
    {
        // Computational displacement
        float deltaTime = Time.deltaTime;
        position = PhysicsUtil.GetParabolaNextPosition(position, Velocity, gravity, deltaTime);
        transform.position = position;
        time += deltaTime;
        Velocity.y += gravity * deltaTime;

        // Computational steering
        transform.LookAt(PhysicsUtil.GetParabolaNextPosition(position, Velocity, gravity, deltaTime));

        // Simply simulate collision detection
        if (position.y <= dest.y) enabled = false;
    }

}