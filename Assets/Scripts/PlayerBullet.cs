using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    
    private int ttl = 250;
    public GameObject explosionPrefab;
    GameManager gameManager;
    public GameObject healthItemPrefab;
    private float healthdropProbability = 0.15f;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){ return; }
        if (collision.gameObject.CompareTag("Health")) { return; }

        GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 5f);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Random.Range(0f, 1f) > (1f - healthdropProbability))
            {
                SpawnHealthItem(collision.gameObject.transform);
            }
        }
        

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

    void SpawnHealthItem(Transform trans)
    {
        GameObject item = Instantiate(healthItemPrefab, trans.position, Quaternion.identity);
        Destroy(item, 10f);
        
    }
}
