using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{

    public GameObject g1;
    public GameObject g2;
    public GameObject g3;

    // Start is called before the first frame update
    void Start()
    {
        float distance = (g1.transform.position.z- g2.transform.position.z);
        float distance2 = Vector3.Distance(g1.transform.position, g2.transform.position);
        float distance3 = Vector3.Distance(g1.transform.position, g3.transform.position);
        Debug.Log(distance);
        Debug.Log(distance2);
        Debug.Log(distance3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
