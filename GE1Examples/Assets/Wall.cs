﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public int height = 10;
	// Use this for initialization
	void Start () {
        CreateWall(10, height);
	}

    void CreateWall(int width, int height)
    {
        int halfw = width / 2;
        float gap = 1.1f;
        for (int row = 0; row < height; row++)
        {
            for (int col = -halfw; col < halfw; col++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Rigidbody>();
                float x = col * gap;
                float y = 0.5f + (row * gap);
                
                cube.transform.position = transform.TransformPoint(new Vector3(x, y, 0));
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 0.8f);
                cube.transform.parent = this.transform;
                cube.transform.rotation = this.transform.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
