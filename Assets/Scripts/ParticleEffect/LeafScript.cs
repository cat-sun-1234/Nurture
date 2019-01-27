using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    public float fallSpeed;
    float timer;
    float curDir;
    private void Awake()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward, Random.Range(-1, 1));
        curDir = Mathf.Clamp(curDir + (Random.Range(-5, 6) / 10.0f), -1.5f, 1.5f);
        //Debug.Log((Vector3.down + (Vector3.right * curDir)));
        gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + (Vector3.down + (Vector3.right * (curDir))) * fallSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        transform.localScale = (Vector3.one * ((5 - timer) / 5.0f));
        if (timer > 25)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
