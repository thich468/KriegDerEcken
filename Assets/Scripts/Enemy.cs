using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public float distance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform != null && player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
            direction.Normalize();
            movement = direction;
        }
        
    }

    public void FixedUpdate()
    {
        if (transform != null && player != null)
        {
            Vector3 direction = player.position - transform.position;

            //Debug.Log(direction.magnitude);

            if (direction.magnitude > distance)
            {
                moveCharacter(movement);
            }
        }
        
        
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
