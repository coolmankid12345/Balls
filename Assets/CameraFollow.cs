using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f; //put between 0 and 1 small is smoother
    public Vector3 offset; //Pulls camera away from character

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; //Exact camera follow
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //Smoothed camera adjustment
        transform.position = smoothedPosition; //Applying camera position
    }

}
