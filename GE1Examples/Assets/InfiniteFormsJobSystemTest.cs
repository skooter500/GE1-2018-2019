using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFormsJobSystemTest : MonoBehaviour {
    int rowCount = 0;

    public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Count: " + rowCount * 50);
    }

    void CreateRow()
    {
        for (int x = -50; x < 50; x++)
        {
            GameObject newGuy = GameObject.Instantiate<GameObject>(prefab);
            Vector3 pos = new Vector3(x, 0, rowCount) * 5;
            prefab.transform.position = transform.TransformPoint(pos);            
        }
        rowCount++;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRow();
        }		
	}
}
