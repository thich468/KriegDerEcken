using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private int ttl = 250;
    public GameObject explosionPrefab;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){ return; }
        
        GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 5f);

        //test game
        gameManager.GetEnemyList().Remove(collision.gameObject);
        Destroy(collision.gameObject);
        
        
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
