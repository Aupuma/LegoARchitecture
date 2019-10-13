using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer line;
    Vector3[] points;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.GetPositions(points);
        line.positionCount = 0;

        line.positionCount = points.Length;
        line.SetPosition(0, points[0]);
    }

    IEnumerator DrawLineSegment()
    {

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
