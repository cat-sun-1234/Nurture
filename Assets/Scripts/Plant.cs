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
        }
    }
}
