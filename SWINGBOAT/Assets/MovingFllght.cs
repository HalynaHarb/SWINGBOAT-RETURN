using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFllght : MonoBehaviour
{
    public GameObject eye;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform [] points;
    public int pointSelection;
    void Start()
    {
        currentPoint = points[pointSelection];
    }

    // Update is called once per frame
    void Update()
    {
        eye.transform.position = Vector3.MoveTowards(eye.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if(eye.transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
    }
}
