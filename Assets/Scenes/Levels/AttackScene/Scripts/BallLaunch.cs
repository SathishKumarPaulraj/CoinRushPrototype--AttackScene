using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parabolic Missile
/// < para > Calculating trajectory and steering </para >
/// <para>ZhangYu 2019-02-27</para>
/// </summary>
public class BallLaunch : MonoBehaviour
{

    public Transform target; //target
    public AttackManager _attackManager;
    public float hight = 16f; // parabolic height
    public float gravity = 9.8f; // gravitational acceleration
    private GameObject _bullet;
    private Vector3 position; //My position
    private Vector3 dest; //Target location
    private Vector3 Velocity; //Motion Velocity
    private float time = 0; // Motion time
   

    private void Start()
    {
        _attackManager = GameObject.Find("AttackManager").GetComponent<AttackManager>();
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
       // if (position.y <= dest.y) enabled = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Entered");
        Debug.Log(collision.gameObject.name);
        _bullet = this.gameObject;

        if (_attackManager._Shield == true)
        {
            Debug.Log("Shield Activated");
            _bullet.transform.GetChild(0).gameObject.SetActive(true);
            _bullet.transform.GetChild(1).gameObject.SetActive(true);
            _bullet.transform.GetChild(0).parent = null;
            _bullet.transform.GetChild(1).parent = null;
        }
        else
        {
            Debug.Log("Shield Disabled");
            _bullet.transform.GetChild(0).gameObject.SetActive(true);
            _bullet.transform.GetChild(1).gameObject.SetActive(true);
            _bullet.transform.GetChild(2).gameObject.SetActive(true);
            _bullet.transform.GetChild(3).gameObject.SetActive(true);
            _bullet.transform.GetChild(0).parent = null;
            _bullet.transform.GetChild(1).parent = null;
            _bullet.transform.GetChild(2).parent = null;
            _bullet.transform.GetChild(3).parent = null;

        }
    }
  
}