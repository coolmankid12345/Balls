using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    public GameObject thePlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            thePlayer.transform.position = destination.transform.position;
        }
    }
}
