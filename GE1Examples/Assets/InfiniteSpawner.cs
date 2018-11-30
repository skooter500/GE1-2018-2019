using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour {

    int row;

    public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}

    public void CreateRow()
    {
        for (float x = -50; x < 50; x++)
        {
            GameObject i = GameObject.Instantiate<GameObject>(prefab);
            Vector3 pos = new Vector3(x, 0, row) * 5;
            pos = transform.TransformPoint(pos);
            i.transform.position = pos;            
        }
        row++;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 50), "Count: " + row * 100);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRow();
        }
	}
}
