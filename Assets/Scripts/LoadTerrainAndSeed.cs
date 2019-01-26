using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTerrainAndSeed : MonoBehaviour
{

    public GameObject wateringController;

    public GameObject terrain0;
    public GameObject terrain1;
    public GameObject terrain2;
    public GameObject terrain3;

    public GameObject seed0;
    public GameObject seed1;
    public GameObject seed2;
    public GameObject seed3;

    private int terrainType = -1;
    private int seedType = -1;

    // Start is called before the first frame update
    void Start()
    {
        terrainType = PlayerPrefs.GetInt("TerrainID", 4);
        seedType = PlayerPrefs.GetInt("SeedID", 3);

        GameObject chosenIsland;
        GameObject chosenSeed = null;

        Vector2 islandPos = new Vector2 (0f, -4f);

        switch (terrainType)
        {
            case 0:
                chosenIsland = Instantiate (terrain0, islandPos, Quaternion.identity);
                break;
            case 1:
                chosenIsland = Instantiate (terrain1, islandPos, Quaternion.identity);
                break;
            case 2:
                chosenIsland = Instantiate (terrain2, islandPos, Quaternion.identity);
                break;
            case 3:
                chosenIsland = Instantiate (terrain3, islandPos, Quaternion.identity);
                break;
        }

        Vector2 seedPos0 = new Vector2 (0f, -2.3f);
        Vector2 seedPos1 = new Vector2 (0f, -2.3f);
        Vector2 seedPos2 = new Vector2 (0f, -2.3f);
        Vector2 seedPos3 = new Vector2 (-0.5f, -0.4f);

        switch (seedType)
        {
            case 0:
                chosenSeed = Instantiate (seed0, seedPos0, Quaternion.identity);
                break;
            case 1:
                chosenSeed = Instantiate (seed1, seedPos1, Quaternion.identity);
                break;
            case 2:
                chosenSeed = Instantiate (seed2, seedPos2, Quaternion.identity);
                break;
            case 3:
                chosenSeed = Instantiate (seed3, seedPos3, Quaternion.identity);
                break;
        }

        wateringController.SendMessage("SetPlant", chosenSeed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
