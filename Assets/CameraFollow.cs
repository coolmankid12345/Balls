﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Camera cam;
    public Vector3 mp;

    public float smoothSpeed = 0.125f; //put between 0 and 1 small is smoother
    public Vector3 offset; //Pulls camera away from character

    void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        mp = cam.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 15;
        Vector3 desiredPosition;
        if(Input.GetMouseButton(1))
        {
            desiredPosition = (target.position + offset) + ((target.position + offset) - (mp));
        }
        else
        {
            desiredPosition = (target.position + offset);//Exact camera follow 
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //Smoothed camera adjustment
        transform.position = smoothedPosition; //Applying camera position
    }

}
