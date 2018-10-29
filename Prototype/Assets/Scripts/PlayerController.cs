using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    Rigidbody rg;
    public float speed;
    private Camera cam;
    private Vector3 pos;
    public Vector3 velocity;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void Update()
    {
       
        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase.Equals(TouchPhase.Began) || Input.GetTouch(0).phase.Equals(TouchPhase.Stationary) || Input.GetTouch(0).phase.Equals(TouchPhase.Moved))
            {
                pos = cam.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 4));


                //   rg.transform.position = Vector3.MoveTowards(rg.transform.position, new Vector3(pos.x, pos.y, rg.position.z), speed*Time.deltaTime);
                //  rg.transform.LookAt(new Vector3(pos.x, pos.y, rg.position.z));
                //  rg.AddForce((new Vector3(pos.x, pos.y, rg.position.z) - rg.transform.position).normalized * speed * Time.smoothDeltaTime);
                //    rg.AddRelativeForce(0, 0, speed * Time.deltaTime);
                //   rg.velocity = (new Vector3(pos.x, pos.y, rg.position.z) - rg.transform.position).normalized * speed * Time.smoothDeltaTime;
                //  velocity = rg.velocity;
                //rg.velocity = (new Vector3(pos.x, pos.y, rg.transform.position.z) - rg.transform.position).normalized * speed * Time.smoothDeltaTime;

                velocity = (new Vector3(pos.x, pos.y, rg.transform.position.z) - rg.transform.position).normalized * speed * Time.smoothDeltaTime;
                rg.transform.position = Vector3.MoveTowards(rg.transform.position, new Vector3(pos.x, pos.y, rg.position.z), speed * Time.deltaTime);

            }

        }
    }
    void FixedUpdate()
    {

 
    }
                    

}


