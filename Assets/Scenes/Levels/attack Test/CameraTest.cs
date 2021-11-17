using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public float transitionDuration = 2.5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transition());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < .1f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            Debug.Log(t);

            transform.position = Vector3.Lerp(startingPos, target.position, t*3);
            yield return 0;
        }


    }
}
