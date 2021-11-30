using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine( Transition());
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(0f, 8f, -3f), Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      //  this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(0f, 8f, -3f), Time.deltaTime);
        //  Transition();

        // this.gameObject.transform.position += Vector3.up * 2 * Time.deltaTime;
        // this.gameObject.transform.position -= transform.position;
        // this.GetComponent<Rigidbody>().useGravity = false;
    }

    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = this.gameObject.transform.position; // Camera.main.transform.position;
        Vector3 endPos = new Vector3(0f, 8f, -3f); //new Vector3(_TargetTransform.localPosition.x, CameraAttackPosition.y, CameraAttackPosition.z);
        Debug.Log(this.gameObject.name);
        Debug.Log(startingPos);
        Debug.Log(endPos);

        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / 2.5f);
            Debug.Log("Inside Coroutine");

            this.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, t );
            //GameObject temp = new GameObject();
            //temp.transform.LookAt(_TargetTransform);
            //Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, temp.transform.rotation, t*3);
            yield return 0;
        }
    }
}
