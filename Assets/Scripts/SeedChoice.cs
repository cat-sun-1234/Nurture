using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedChoice : MonoBehaviour
{
    WateringController wc;
    SeedType[] seeds;
    public Vector3 seedPos;
    private void Awake()
    {
        wc = FindObjectOfType<WateringController>();
    }
    public void PlantSeed(int _I)
    {
        GameObject plant = GetSeed(seeds[_I]);
        if (wc.plant != null)
        {
            Destroy(wc.plant);
        }
        wc.plant = plant;
    }
    GameObject GetSeed(SeedType _ST)
    {
        GameObject seedObject = new GameObject();
        seedObject.transform.position = seedPos;
        SpriteRenderer newSprite = seedObject.AddComponent<SpriteRenderer>();
        newSprite.sprite = _ST.sprite;
        seedObject.name = _ST.name;
        return seedObject;
    }
}
[System.Serializable]
public struct SeedType
{
    public string name;
    public Sprite sprite;
    public int minFert;
    public float growthSpeed;
}
