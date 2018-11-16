using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour {

    public int quadsPerTile = 10;

    public Material meshMaterial;

    public float amplitude = 50;

    Mesh m;

    // Use this for initialization
    void Awake() {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>(); // Container for the mesh
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>(); // Draw

        m = mf.mesh;

        int verticesPerQuad = 6;
        Vector3[] vertices = new Vector3[verticesPerQuad * quadsPerTile * quadsPerTile];
        Vector2[] uv = new Vector2[verticesPerQuad * quadsPerTile * quadsPerTile];

        int[] triangles = new int[verticesPerQuad * quadsPerTile * quadsPerTile];

        Vector3 bottomLeft = new Vector3(-quadsPerTile / 2, 0, -quadsPerTile / 2);
        int vertex = 0;
        float minY = float.MaxValue;
        float maxY = float.MinValue;
        for (int row = 0; row < quadsPerTile; row++)
        {
            for (int col = 0; col < quadsPerTile; col++)
            {
                Vector3 bl = bottomLeft + new Vector3(col, SampleCell(transform.position.x + col, transform.position.z + row), row);
                Vector3 tl = bottomLeft + new Vector3(col, SampleCell(transform.position.x + col, transform.position.z + row + 1), row + 1);
                Vector3 tr = bottomLeft + new Vector3(col + 1, SampleCell(transform.position.x + col + 1, transform.position.z + row + 1), row + 1);
                Vector3 br = bottomLeft + new Vector3(col + 1, SampleCell(transform.position.x + col + 1, transform.position.z + row), row);

                int startVertex = vertex;
                vertices[vertex++] = bl;
                vertices[vertex++] = tl;
                vertices[vertex++] = br;

                vertices[vertex++] = br;
                vertices[vertex++] = tl;
                vertices[vertex++] = tr;

                vertex = startVertex;
                float fNumQuads = quadsPerTile;
                uv[vertex++] = new Vector2(col / fNumQuads, row / fNumQuads);
                uv[vertex++] = new Vector2(col / fNumQuads, (row + 1) / fNumQuads);
                uv[vertex++] = new Vector2((col + 1) / fNumQuads, row / fNumQuads);

                uv[vertex++] = new Vector2((col + 1) / fNumQuads, row / fNumQuads);
                uv[vertex++] = new Vector2(col / fNumQuads, (row + 1)/ fNumQuads);
                uv[vertex++] = new Vector2((col + 1)/ fNumQuads, (row + 1)/ fNumQuads);

                for (int i = 0; i < 6; i++)
                {
                    triangles[startVertex + i] = startVertex + i;
                }

                if (bl.y > maxY)
                {
                    maxY = bl.y;
                }
                if (bl.y < minY)
                {
                    minY = bl.y;
                }
            }
        }
        Debug.Log("MinY: " + minY);
        Debug.Log("MaxY: " + maxY);
        m.vertices = vertices;
        m.uv = uv;
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
            vertices[i].y = SampleCell(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z + t);
        }
        m.vertices = vertices;
        t += Time.deltaTime;
        m.RecalculateNormals();
	}
    
}
