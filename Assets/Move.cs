using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 maxPower;
    public Vector2 minPower;

    public Line tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        tl = GetComponent<Line>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Math.Abs(rb.velocity.x) <= .01)&& (Math.Abs(rb.velocity.y) <= .0001)) //Fake friction
        {
            rb.velocity = new Vector2(0,0);

        }
        if (Input.GetMouseButtonDown(0) && rb.velocity.y == 0 && rb.velocity.x == 0) 
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0) && rb.velocity.y == 0 && rb.velocity.x == 0)
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0) && rb.velocity.y == 0 && rb.velocity.x == 0)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }
}
