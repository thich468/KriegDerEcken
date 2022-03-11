using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private int ttl = 250;
    public GameObject explosionPrefab;

    private void Start()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){ return; }
        
        GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 5f);
        //Destroy(collision.gameObject);
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
