using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public int hp = 15;
    public GameObject explosionPrefab;

    public GameObject healthItemPrefab;
    private float healthdropProbability = 0.05f;
    public GameObject healthParticles;
    // Start is called before the first frame update
    void Start()
    {
        //hp = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision!");
        //Diamond
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            //gameManager.GameOver();
            GameObject explosion = Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            explosion.transform.localScale = explosion.transform.localScale * 3;
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion, 5f);
            Destroy(collision.gameObject);
            gameManager.IncreaseScore(25);
            gameManager.GetEnemyList().Remove(collision.gameObject);
            if (Random.Range(0f, 1f) > (1f - healthdropProbability))
            {
                SpawnHealthItem(collision.gameObject.transform);
            }


            damage(2);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            damage(1);
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            Debug.Log("Health Collision!");
            hp += 3;
            if(hp > 15)
            {
                hp = 15;
            }
            GameObject particles = Instantiate(healthParticles, collision.gameObject.transform.position, Quaternion.identity);
            //particles.transform.localScale = particles.transform.localScale * 3;
            gameManager.IncreaseScore(10);
            particles.GetComponent<ParticleSystem>().Play();
            Destroy(particles, 5f);
            Destroy(collision.gameObject);
        }
    }

    private void damage(int amount)
    {
        hp -= amount;
        //Debug.Log(hp + "HP");
        if (hp < 1)
        {
            gameManager.GameOver();
        }
    }

    void SpawnHealthItem(Transform trans)
    {
        GameObject item = Instantiate(healthItemPrefab, trans.position, Quaternion.identity);
        Destroy(item, 10f);
        
    }


}
