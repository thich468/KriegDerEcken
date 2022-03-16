using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public int hp;
    public GameObject explosionPrefab;
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
            gameManager.GetEnemyList().Remove(collision.gameObject);


            damage(2);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            damage(1);
        }
    }

    private void damage(int amount)
    {
        hp -= amount;
        Debug.Log(hp + "HP");
        if (hp < 1)
        {
            gameManager.GameOver();
        }
    }


}
