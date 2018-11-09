﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

    public int numQuads = 10;

    public Material meshMaterial;

    public float amplitude = 50;

    Mesh m;

    // Use this for initialization
    void Start() {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();

        m = mf.mesh;

        int verticesPerQuad = 6;
        int vertexCount = verticesPerQuad * numQuads * numQuads;

        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[vertexCount];

        Vector3 bottomLeft = new Vector3(-numQuads / 2, 0, -numQuads / 2);
        int vertex = 0;
        for (int row = 0; row < numQuads; row++)
        {
            for (int col = 0; col < numQuads; col++)
            {
                Vector3 bl = bottomLeft + new Vector3(col, SampleCell(col, row), row);
                Vector3 tl = bottomLeft + new Vector3(col, SampleCell(col, row + 1), row + 1);
                Vector3 tr = bottomLeft + new Vector3(col + 1, SampleCell(col + 1, row + 1), row + 1);
                Vector3 br = bottomLeft + new Vector3(col + 1, SampleCell(col + 1, row), row);

                int startVertex = vertex;
                vertices[vertex++] = bl;
                vertices[vertex++] = tl;
                vertices[vertex++] = br;
                vertices[vertex++] = br;
                vertices[vertex++] = tl;
                vertices[vertex++] = tr;

                for (int i = 0; i < 6; i++)
                {
                    triangles[startVertex + i] = startVertex + i;
                }                
            }
        }
        m.vertices = vertices;
        m.triangles = triangles;        
        m.RecalculateNormals();
        mr.material = meshMaterial;
	}

    float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }

    float SampleCell(float x, float y)
    {
        return Mathf.PerlinNoise(x / 10, y / 10) * 20;
        /*
        return Mathf.Sin(Map(x, 0, numQuads, 0, Mathf.PI))
            * Mathf.Sin(Map(y, 0, numQuads, 0, Mathf.PI)) * 40;
            */
        
    }

    float t = 0;
	// Update is called once per frame
	void Update () {
        Vector3[] vertices = m.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = SampleCell(vertices[i].x, vertices[i].z + t);
        }
        m.vertices = vertices;
        t += Time.deltaTime;
	}
}
