using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

    public int numQuads = 10;

    public Material meshMaterial;

    public float amplitude = 50;

    public Texture2D texture;

    Mesh m;

    void MakeTexture()
    {
        texture = new Texture2D(numQuads, numQuads);
        
        for (int x = 0; x < numQuads; x++)
        {
            for (int y = 0; y < numQuads; y++)
            {
                texture.SetPixel(x, y, Color.HSVToRGB((x + y) / (numQuads * 2.0f), 1, 1));
            }
        }
        texture.Apply();
    }

    // Use this for initialization
    void Start() {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();

        MakeTexture();
        
        m = mf.mesh;

        int verticesPerQuad = 4;
        int vertexCount = verticesPerQuad * numQuads * numQuads;

        Vector3[] vertices = new Vector3[vertexCount];
        Vector2[] uvs = new Vector2[vertexCount];

        int verticesPerTriangle = 6;
        int[] triangles = new int[verticesPerTriangle * numQuads * numQuads];


        Vector3 bottomLeft = new Vector3(-numQuads / 2, 0, -numQuads / 2);
        int vertex = 0;
        int triangleVertex = 0;
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
                vertices[vertex++] = tr;
                vertices[vertex++] = br;

                float f = (row + 1) / (float)numQuads;
                uvs[startVertex] = new Vector2(col / (float) numQuads, row / (float) numQuads);
                uvs[startVertex + 1] = new Vector2(col / (float) numQuads, (row + 1)/ (float) numQuads);
                uvs[startVertex + 2] = new Vector2((col + 1) / (float) numQuads, (row + 1) / (float) numQuads);
                uvs[startVertex + 3] = new Vector2((col + 1)/ (float) numQuads, row / (float) numQuads);
                Debug.Log(uvs[startVertex + 1]);

                triangles[triangleVertex++] = startVertex;
                triangles[triangleVertex++] = startVertex + 1;
                triangles[triangleVertex++] = startVertex + 2;

                triangles[triangleVertex++] = startVertex;
                triangles[triangleVertex++] = startVertex + 2;
                triangles[triangleVertex++] = startVertex + 3;
            }
        }
        m.vertices = vertices;
        m.triangles = triangles;
        m.uv = uvs;
        m.RecalculateNormals();
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mr.material = meshMaterial;
        mr.material.mainTexture = texture;
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
        m.RecalculateNormals();
        t += Time.deltaTime;
	}
}
