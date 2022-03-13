using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public Transform shadow;
    Vector3 shadowOffset;



    public float speed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        shadowOffset = transform.position + shadow.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        this.transform.position = this.transform.position + new Vector3(horizontal*speed*Time.fixedDeltaTime, vertical*speed * Time.fixedDeltaTime, 0);
        shadow.transform.position = transform.position + shadowOffset;
    }
}
