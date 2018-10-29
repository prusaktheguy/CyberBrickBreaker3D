using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;
    public float startingForce;
    public Rigidbody playerRigidbody;
    public Vector3 velocity;
    public Vector3 curveForce;
    private Vector3 pos;
    public float rotateSpeed;
    public float curveSpeed;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * -startingForce );
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase.Equals(TouchPhase.Began) || Input.GetTouch(0).phase.Equals(TouchPhase.Stationary) || Input.GetTouch(0).phase.Equals(TouchPhase.Moved))
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 4));
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(curveSpeed * Vector3.Cross(rb.velocity, rb.angularVelocity), ForceMode.Force);

        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 24);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -24);
        }
        velocity = rb.velocity;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //TODO: try generate playerRigidbody velocity and use it instead of rotate speed, and on all axis
            transform.rotation = Quaternion.Euler(0, Mathf.PingPong(Time.time * rotateSpeed, 90), 0);


           // curveForce = (new Vector3(pos.x, pos.y, rb.transform.position.z) - rb.transform.position).normalized * curveSpeed * Time.smoothDeltaTime;
            velocity = rb.velocity;
            //Quaternion deltaRotation = Quaternion.Euler(curveForce * Time.deltaTime);
            //rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }
}
