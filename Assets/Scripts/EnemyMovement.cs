using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    



    public float speed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 pos = transform.position;
        Debug.Log(pos.x);
        if (pos.x <= 10 && pos.y <= 10)
        {
            Debug.Log(pos.x);
            Debug.Log(pos.y);
            float horizontal = 2f;
            float vertical = 1f;
            this.transform.position = this.transform.position + new Vector3(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime, 0);

        }else if (pos.x >= 9 && pos.y >= -6)
        {
            Debug.Log(pos.x);
            Debug.Log(pos.y);
            float horizontal = 0f;
            float vertical = -1f;
            this.transform.position = this.transform.position + new Vector3(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime, 0);


        }else if(pos.x >= -15 && pos.y <= -5)
        {
            float horizontal = -2f;
            float vertical = 0f;
            this.transform.position = this.transform.position + new Vector3(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime, 0);

        }



    }
}