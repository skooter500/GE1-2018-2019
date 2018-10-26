using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FC : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Walk(float units)
    {
        rb.AddForce(transform.forward * units);
    }

    void Strafe(float units)
    {
        rb.AddForce(transform.right * units);
    }

    void Yaw(float units)
    {
        rb.AddTorque(Vector3.up * units);
    }

    float power = 1000;
    float apower = 500;

    // Update is called once per frame
    void Update () {
        Walk(Input.GetAxis("Vertical") * power * Time.deltaTime);
        Strafe(Input.GetAxis("Horizontal") * power * Time.deltaTime);
        Yaw(Input.GetAxis("Yaw") * apower * Time.deltaTime);


    }
}
