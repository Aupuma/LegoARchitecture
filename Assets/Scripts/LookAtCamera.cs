using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.transform;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - target.transform.position);
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
    }
}
