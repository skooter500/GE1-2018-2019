using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimator1 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

    float damping = 10.0f;
	
	void Update () {
        for (int i = 1; i < transform.parent.childCount; i++)
        {
            Vector3 offset = new Vector3(0, 0, -1.1f);
            Transform prev = transform.parent.GetChild(i - 1);
            Transform current = transform.parent.GetChild(i);

            Vector3 wantedPosition = prev.transform.TransformPoint(offset);
            current.transform.position = Vector3.Lerp(current.transform.position, wantedPosition, Time.deltaTime * damping);

            Quaternion wantedRotation = Quaternion.LookRotation(prev.transform.position - current.position, prev.transform.up);

            current.transform.rotation = Quaternion.Slerp(current.transform.rotation, wantedRotation, Time.deltaTime * damping);


        }
    }
}
