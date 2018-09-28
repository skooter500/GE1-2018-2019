using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour {
    public float angle = 20.0f;
    public float frequency;

    public float theta;
    public Vector3 axis;
	// Use this for initialization
	void Start () {
        axis = Random.insideUnitSphere;
        axis.y = 0;
        axis.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = Quaternion.AngleAxis(
            Mathf.Sin(theta) * angle, axis);
        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f;
	}
}
