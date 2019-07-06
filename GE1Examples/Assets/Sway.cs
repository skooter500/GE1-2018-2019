using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour {
    public float angle = 20.0f;
    public float frequency;

    public float theta;
    public Vector3 axis = Vector3.zero;
	// Use this for initialization
	void Start () {
        if (axis == Vector3.zero)
        {
            axis = Random.insideUnitSphere;
            axis.y = 0;
            axis.Normalize();
        }
        // Uncomment to use the job system
        SwayManager1.Instance.Add(this.gameObject);
    }
	
    // Comment out to use the job system
    
	/*void Update () {
        transform.localRotation = Quaternion.AngleAxis(
            Mathf.Sin(theta) * angle, axis);
        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f;
	} 
    */
    
    
}
