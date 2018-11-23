using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer1 : MonoBehaviour {
    public float radius = 20;
    List<GameObject> cubes = new List<GameObject>();
    public float scale = 50;
	// Use this for initialization
	void Start () {
        float theta = (Mathf.PI * 2) / (float) AudioAnalyzer1.bands.Length;
        for (int i = 0; i < AudioAnalyzer1.bands.Length; i++)
        {
            Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius
                , 0
                , Mathf.Cos(theta * i) * radius
                );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg
                , Vector3.up
                );
            q = transform.rotation * q;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, q);
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)AudioAnalyzer1.bands.Length
                , 1
                , 1
                );
            cube.transform.parent = this.transform;
            cubes.Add(cube);            
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < cubes.Count; i++)
        {
            Vector3 ls = cubes[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyzer1.bands[i] * scale), Time.deltaTime * 5.0f);
            cubes[i].transform.localScale = ls;
        }
	}
}
