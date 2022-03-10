using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    private int ttl = 250;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){ return; }
        Destroy(gameObject); 
    }

    void FixedUpdate()
    {
        if(ttl == 0)
        {
            Destroy(gameObject);
        }
        ttl--;
    }
}
