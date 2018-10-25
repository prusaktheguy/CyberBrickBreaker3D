using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera


    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + offset;

    }
}
