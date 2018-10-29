using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour {
    public GameObject player;
    public bool isBottomShade;
    private float offset=0;         

    // Use this for initialization
    void Start () {
        if (isBottomShade)
        {
            offset = transform.position.x - player.transform.position.x;
        }
        else
        {
            offset = transform.position.y - player.transform.position.y;

        }

    }

    // Update is called once per frame
    void Update () {
        if (isBottomShade)
        {
            transform.position = new Vector3( player.transform.position.x + offset, transform.position.y,transform.position.z) ;

        }
        else
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
        }

    }
}
