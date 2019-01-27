using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFallScript : MonoBehaviour
{
    float timer;
    public float spawnPerSecond;
    public float spawnPosMod;
    //public ParticleSystem particles;
    public GameObject prefab;
    public Vector3 spawnPos;
    public bool isActive;

    public void SetActive(bool _A)
    {
        isActive = _A;
    }
    public void SetPosition(Vector3 _P)
    {
        spawnPos = _P;
    }
    private void Update()
    {
        //particles 
        if(isActive)
        {
            timer += Time.deltaTime;
            if (timer >= (1 / spawnPerSecond)) 
            {
                timer = 0;
                GameObject newLeaf = Instantiate(prefab, spawnPos + (Vector3.right * ((Random.Range(-10, 11)* spawnPosMod) / 10.0f)), Quaternion.Euler(0, 0, 0));
                newLeaf.transform.SetParent(this.transform);
            }
        }
    }
}

