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
    public float test;///////
    /// </summary>
     bool cancel;
    public Line tl;

    public int par = 0; //PAAAAR
    public Text parText;
    public Text parBGText;

    Camera cam;
    
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 currentPoint;
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
            if (cancel == true)
            {
                startPoint = rb.transform.position;
                currentPoint = rb.transform.position;
                tl.RenderLine(startPoint, currentPoint);
            }
            //Clicking resets cancel but pressing right click cancels shot
            if(Input.GetMouseButtonDown(0))
            {
                cancel = false;
            }
            if(Input.GetMouseButtonDown(1))
            {
                cancel = true;
            }
            if (Input.GetMouseButton(0) && !cancel)
            {
                startPoint = rb.transform.position;
                startPoint.z = 15;
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;

                if(Vector3.Distance(startPoint, currentPoint) > maxPower)
                {
                    Vector3 dir = currentPoint - startPoint;
                    float dist = Mathf.Clamp(Vector3.Distance(startPoint, endPoint), 0, maxPower);
                    currentPoint = startPoint + (dir.normalized * dist);
                }
                
                /////////////////////////This is all an attempt to max out the line after the distance equivalent to maxPower
                /* if (Vector3.Distance(startPoint, currentPoint) > maxPower) //Note currently 
                 {
                     Vector2 deltaP = new Vector2((startPoint.x - currentPoint.x), (startPoint.y - currentPoint.y)); //This is the change in position
                     float newX = (float)(maxPower * Math.Pow(Math.Cos(Math.Atan(deltaP.y / deltaP.x)), 2)) + startPoint.x;
                     float newY = (float)(maxPower * Math.Pow(Math.Sin(Math.Atan(deltaP.y / deltaP.x)), 2)) + startPoint.y;
                     currentPoint = new Vector3(newX, newY, 15);
                     //This still needs to be fixed not sure why it doesn't work
                     if (deltaP.x < 0) //Fix X cord if neg
                     {
                         currentPoint.x = newX - (2*(startPoint.x));
                     }
                     if (deltaP.y < 0) //Fix Y cord if neg
                     {
                         currentPoint.y = newY - (2*(startPoint.y));
                     }
                     
            }
                */
                ///////////////////////////////////////////////////////////////////
                tl.RenderLine(startPoint, currentPoint); 
            }
                
            if (Input.GetMouseButtonUp(0) && !cancel)
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
