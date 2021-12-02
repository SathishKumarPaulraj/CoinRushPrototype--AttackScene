using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position += Time.deltaTime * 100f * Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += Time.deltaTime * 2f * Vector3.back;
        //Debug.Log(Time.deltaTime * 2f * Vector3.back);
    }
}
