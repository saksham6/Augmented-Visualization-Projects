using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraController : MonoBehaviour
{
    public GameObject player;  // Assign the player object in the Inspector
    private Vector3 offset;    // The initial offset between the camera and the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;  // Calculate the initial offset
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;  // Update the camera's position to follow the player
    }
}
