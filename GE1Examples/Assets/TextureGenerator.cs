using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TerrainTile))]
public class TextureGenerator : MonoBehaviour {
    TerrainTile tt;
    public Texture2D texture;
	// Use this for initialization
	void Start () {
        tt = GetComponent<TerrainTile>();
        texture = new Texture2D(tt.quadsPerTile, tt.quadsPerTile);
        for (int x = 0; x < tt.quadsPerTile; x++)
        {
            for (int y = 0; y < tt.quadsPerTile; y++)
            {
                float h = (x + y) / (float)(tt.quadsPerTile * 2.0f);

                texture.SetPixel(x, y, Color.HSVToRGB(h, 1, 1));
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        GetComponent<MeshRenderer>().material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
