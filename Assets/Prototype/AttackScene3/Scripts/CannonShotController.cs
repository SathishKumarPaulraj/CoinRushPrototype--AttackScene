using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShotController : MonoBehaviour
{

    public Rigidbody _bulletPrefab,_bullet;
    public Transform _shotPoint;
    public Transform _TargetTransform;
    public AttackManager _AttackManager;
    public Quaternion CameraAttackRotation;
    public float CameraAttackPositionZ = -665f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*  void LaunchProjectile()
      {
          Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

          if (Physics.Raycast(camRay, out hit, 100f, layer))
          {
              Cursor.SetActive(true);
              Cursor.transform.position = hit.point + Vector3.up * 0.1f;

              Vector3 Vo = CalculateVelocity(hit.point, _shotPoint.position, 1f);

              transform.rotation = Quaternion.LookRotation(Vo);

              if (Input.GetMouseButtonDown(0))
              {
                  Rigidbody obj = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);
                  obj.velocity = Vo;
              }

          }
          else
          {
              Cursor.SetActive(false);
          }
      } */

    /// <summary>
    ///  Calcuate the Projectile  of the Bullet from from Origin to Target
    /// </summary>
    /// <param name="target"></param>
    /// <param name="origin"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //Define 
        Vector3 _distance = target - origin;
        Vector3 _distanceXZ = _distance;
        _distanceXZ.y = 0f;

        //Distance Value

        float sY = _distance.y;
        float sXZ = _distanceXZ.magnitude;

        float Vxz = sXZ / time;
        float Vy = sY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = _distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        Debug.Log("Vector3 value" + result);
        return result;

    }

    /// <summary>
    /// Cannon look at the Target and Instantiate the Bullet Prefab
    /// </summary>
    /// <param name="tran"></param>
    public void AssignPos(Transform tran)
    {
        _TargetTransform = tran;
        this.transform.parent = Camera.main.transform.parent;
        this.transform.localPosition = new Vector3(0, -30f, 60f);
        // this.transform.localRotation = Camera.main.transform.rotation;
        //Camera.main.transform.parent.position = new Vector3(tran.localPosition.x, tran.localPosition.y, tran.localPosition.z) + new Vector3(-30f, 197.1f, -483.8f);
        //Camera.main.transform.parent.rotation = CameraAttackRotation;
        //this.gameObject.transform.position = new Vector3(tran.localPosition.x, tran.localPosition.y, tran.localPosition.z) + new Vector3(-30f, 130f, -422.8f);
        //this.gameObject.transform.rotation = CameraAttackRotation;
        //Camera.main.transform.parent.position = new Vector3(tran.localPosition.x, tran.localPosition.y, tran.localPosition.z) + new Vector3(-30f,197.1f,-483.8f);
        //Camera.main.transform.parent.rotation = CameraAttackRotation;
        //this.gameObject.transform.position = new Vector3(tran.localPosition.x, tran.localPosition.y, tran.localPosition.z) + new Vector3(-30f, 130f, -422.8f);
        //this.gameObject.transform.rotation = CameraAttackRotation;
        // this.gameObject.transform.position = new Vector3(tran.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //this.gameObject.transform.LookAt(tran);
        //Destroy(_bullet, .8f);
        Invoke("ShootBullet", 2f);
    }

    public void ShootBullet()
    {
        _bullet = Instantiate(_bulletPrefab, _shotPoint.transform.position, _shotPoint.transform.rotation);
        _bullet.velocity = CalculateVelocity(_TargetTransform.transform.position, _shotPoint.transform.position, 1f);
        Debug.Log("Cannon fired");
        Camera.main.transform.parent = _bullet.transform;
        Invoke("DetachCamera", .8f);
        Invoke("DestroyBullet", 1f);
    }

    public void DetachCamera()
    {
        Camera.main.transform.parent = null;
    }

    public void DestroyBullet()
    {
        Destroy(_bullet, 1f);
      
        if (_AttackManager._Shield == true)
        {
            Debug.Log("Shield Activated");
            Debug.Log(_bulletPrefab.transform.GetChild(0).name);
            _bullet.transform.GetChild(0).gameObject.SetActive(true);
            _bullet.transform.GetChild(0).parent = null;
        }
        else
        {
            Debug.Log("Shield Disabled");
            Debug.Log(_bulletPrefab.transform.GetChild(1).name);
            _bullet.transform.GetChild(1).gameObject.SetActive(true);
            _bullet.transform.GetChild(1).parent = null;
        }
    }
}
