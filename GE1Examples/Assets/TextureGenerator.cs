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
        texture = new Texture2D(tt.numQuads, tt.numQuads);
        for (int x = 0; x < tt.numQuads; x++)
        {
            for (int y = 0; y < tt.numQuads; y++)
            {
                float h = (x + y) / (float)(tt.numQuads * 2.0f);

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
