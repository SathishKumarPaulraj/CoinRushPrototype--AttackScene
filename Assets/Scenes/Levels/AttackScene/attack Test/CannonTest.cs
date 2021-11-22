using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTest : MonoBehaviour
{

    public GameObject _bullet;
    public Transform _shotPoint;
    public GameObject _Targetpsoition;


    // Start is called before the first frame update
    void Start()
    {
        BulletLaunch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletLaunch()
    {
        GameObject _bul = Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation);
        _bul.GetComponent<Missile>().target = _Targetpsoition.transform;

    }
}
