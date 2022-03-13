using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleShooting : MonoBehaviour
{
    public float frequency = 2.0f;
    float shootingFrequency;
    float elapsedTime = 0;
    public GameObject bulletPrefab;
    public float force = 50f;
    // Start is called before the first frame update
    void Start()
    {
        shootingFrequency = frequency + Random.Range(-0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootingFrequency)
        {
            Shoot();
            elapsedTime = 0f;
            shootingFrequency = frequency + Random.Range(-0.5f, 0.5f);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gameObject.transform.up * force, ForceMode2D.Impulse);
    }
}
