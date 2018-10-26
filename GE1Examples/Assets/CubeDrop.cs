using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrop : MonoBehaviour {

    Vector3 v = Vector3.zero;
    Vector3 a = new Vector3(0, -9.81f, 0);
	// Use this for initialization
	void Start () {
		
	}

    float time = 0;
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 0)
        {
            v += a * Time.deltaTime;
            transform.position += v * Time.deltaTime;
            time += Time.deltaTime;
        }
        else
        {
            Debug.Log("Cube v: " + v);
            Debug.Log("Cube time" + time);
        }
	}
}
