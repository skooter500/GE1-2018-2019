using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController1 : MonoBehaviour {

    public float speed = 1;
    public Transform camera;
	// Use this for initialization
	void Start () {
        if (camera == null)
        {
            camera = Camera.main.transform;
        }
		
	}

    public void Walk(float units)
    {
        transform.position += camera.transform.forward * units;
        //transform.Translate(Vector3.forward * units);
        //transform.Translate(0, 0, units);
    }

    public void Strafe(float units)
    {
        transform.position += camera.transform.right * units;
    }

    public void Yaw(float units)
    {
        transform.rotation = Quaternion.AngleAxis(units, Vector3.up) * transform.rotation;
        //transform.Rotate(0, units, 0, Space.World);
    }

    public void Pitch(float units)
    {
        transform.rotation = Quaternion.AngleAxis(units, transform.right) * transform.rotation;
    }

    public float rotSpeed = 90;
    
    // Update is called once per frame
    void Update () {
        Walk(Input.GetAxis("Vertical") * speed * Time.deltaTime);
        Strafe(Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        Yaw(Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime);
        //Pitch(- Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime);



    }
}
