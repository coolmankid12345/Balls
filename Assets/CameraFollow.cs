using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //Camera cam;
    //public Vector3 mp;

    public float smoothSpeed = 0.125f; //put between 0 and 1 small is smoother
    public Vector3 offset; //Pulls camera away from character



    private void FixedUpdate()
    {

        //mp = cam.ScreenToWorldPoint(Input.mousePosition);
        //mp.z = 15;
        Vector3 desiredPosition = (target.position + offset); //Exact camera follow   - mp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //Smoothed camera adjustment
        transform.position = smoothedPosition; //Applying camera position
    }

}
