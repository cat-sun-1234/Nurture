using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    float timer;
    private void Awake()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward, Random.Range(-1, 1));
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
