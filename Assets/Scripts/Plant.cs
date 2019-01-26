using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float waterLevel; //level of water in the plant
    public float growthRate; //rate at which it grows

    // Update is called once per frame
    void Update()
    {
        if (waterLevel <= 0.0f)
        {
            this.GetComponent<Animator>().SetBool("isWithering", true);
            //respawn code
            GameObject newPlant = Object.Instantiate(Resources.Load("Prefabs/Plant"), GameObject.Find("PlantSpawnPoint").transform) as GameObject;
            newPlant.transform.parent = null;
            GameObject.Find("Button").GetComponent<WateringController>().RespawnPlant(newPlant); //sets new plant for water controller
            Destroy(this.gameObject);
        }
    }
}
