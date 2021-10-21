using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public float maxPower;
    public float minPower;
    public float force;


    public Line tl;

    public int par = 0; //PAAAAR
    public Text parText;
    public Text parBGText;

    Camera cam;
    
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

        

        if ((Math.Abs(rb.velocity.x) <= .05) && (Math.Abs(rb.velocity.y) <= .0001)) //Fake friction
        {
            rb.velocity = new Vector2(0, 0);

        }

        if (rb.velocity.y == 0 && rb.velocity.x == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = rb.transform.position;
                startPoint.z = 15;
            }


            if (Input.GetMouseButton(0))
            {
                
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                tl.RenderLine(startPoint, currentPoint);
                
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;

                float distance = Vector2.Distance(startPoint, endPoint);
                force = Mathf.Clamp(distance, minPower, maxPower);
                Vector3 dir = (startPoint - endPoint).normalized;
                // old force = new Vector2(Mathf.Clamp((startPoint.x - endPoint.x), minPower.x, maxPower.x), Mathf.Clamp((startPoint.y - endPoint.y), minPower.y, maxPower.y));
                rb.AddForce(dir * (force * power), ForceMode2D.Impulse);

                // old rb.AddForce(force * power, ForceMode2D.Impulse);
                tl.EndLine();
                par += 1; //Adds 1 to par on hit
                parText.text = "Par: " + par;
                parBGText.text = "Par: " + par;
            }
        }
    }
}
