using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChoice : MonoBehaviour
{
    GameObject terrain;
    public List<TerrainType> terrains;
    public Vector3 terrainPos;
    public int terrainID;

    public void FormTerrain(int _TT)
    {
        terrainID = _TT;
        if (terrain != null)
        {
            Destroy(terrain);
        }
        terrain = GetTerrain(terrains[_TT]);
    }
    public GameObject GetTerrain(TerrainType _TT)
    {
        GameObject terrainObject = new GameObject();
        terrainObject.transform.position = terrainPos;
        SpriteRenderer newSprite = terrainObject.AddComponent<SpriteRenderer>();
        newSprite.sprite = _TT.sprite;
        terrainObject.name = _TT.name;
        return terrainObject;
    }
}
[System.Serializable]
public struct TerrainType
{
    public string name;
    public Sprite sprite;
}

