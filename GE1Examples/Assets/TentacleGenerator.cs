using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGenerator : MonoBehaviour {
    public int numTentacles = 20;
    public float gap = 0.1f;
    public GameObject segmentPrefab;
    public GameObject headPrefab;    
    Vector3 offset;
    // Use this for initialization
    void Awake () {
        offset = - Vector3.forward * (1.0f + gap);
        for (int i = 0; i < numTentacles; i++)
        {
            Vector3 lp = offset * i;
            GameObject prefab = (i == 0) ? headPrefab : segmentPrefab;
            GameObject segment = GameObject.Instantiate<GameObject>(prefab);
            segment.transform.position = transform.TransformPoint(lp);
            segment.transform.rotation = transform.rotation;
            segment.transform.parent = this.transform;
        }        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
