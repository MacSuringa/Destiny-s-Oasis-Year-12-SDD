using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColourMap, FalloffMap};
    public DrawMode drawMode;

    public int mapSize;

    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistence;
    public float lacunarity;

    public bool useFalloff;

    public bool autoUpdate;

    public TerrainType[] regions;

    float[,] falloffMap;

    int seed;

    void Awake()
    {
        int seed = Random.Range(0, 10000);
        falloffMap = FalloffGen.GenerateFalloffMap(mapSize);
    }

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapSize, mapSize, seed, noiseScale, octaves, persistence, lacunarity);

        Color[] colourMap = new Color[mapSize * mapSize];
        for(int y = 0; y < mapSize; y++)
        {
            for (int x = 0; x < mapSize; x++)
            {
                if (useFalloff)
                {
                    noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
                }

                float currentHeight = noiseMap[x, y];
                for (int i =0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapSize + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGen.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGen.TextureFromColourMap(colourMap, mapSize, mapSize));
        }
        else if (drawMode == DrawMode.FalloffMap)
        {
            display.DrawTexture(TextureGen.TextureFromHeightMap(FalloffGen.GenerateFalloffMap(mapSize)));
        }

    }

    void OnValidate()
    {
        if (mapSize < 1)
        {
            mapSize = 1;
        }

        if (lacunarity < 1)
        {
            lacunarity = 1;
        }

        if (octaves < 0)
        {
            octaves = 0;
        }

        int seed = Random.Range(0, 10000);
        falloffMap = FalloffGen.GenerateFalloffMap(mapSize);
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}