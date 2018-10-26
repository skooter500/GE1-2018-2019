using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    float time = 0;
    Vector3 v;
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 0 && ! GetComponent<Rigidbody>().isKinematic)
        {
            v = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            time += Time.deltaTime;
        }
        if (transform.position.y <= 0)
        {
            Debug.Log("Sphere time: " + time);
            Debug.Log("Sphere v" + v);
        }

    }
}
