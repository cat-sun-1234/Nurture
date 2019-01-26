using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedChoice : MonoBehaviour
{
    public GameObject spriteObject;
    WateringController wc;
    public List<SeedType> seeds;
    public Vector3 seedPos;
    private void Awake()
    {
        wc = FindObjectOfType<WateringController>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlantSeed(seeds[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlantSeed(seeds[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlantSeed(seeds[2]);
        }
    }
    public void PlantSeed(SeedType _ST)
    {
        GameObject seedObject = new GameObject();
        seedObject.transform.position = seedPos;
        SpriteRenderer newSprite = seedObject.AddComponent<SpriteRenderer>();
        newSprite.sprite = _ST.sprite;
        seedObject.name = _ST.name;
        wc.plant = seedObject;
    }
}
[System.Serializable]
public struct SeedType
{
    public string name;
    public Sprite sprite;
}
