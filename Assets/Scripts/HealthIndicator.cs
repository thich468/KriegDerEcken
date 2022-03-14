using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{

    public GameObject player;
    float hpUnit;
    int startHp;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision pc = player.GetComponent<PlayerCollision>();
        startHp = pc.hp;
        hpUnit = 1f / startHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        float width = hpUnit * startHp;
        float height = gameObject.transform.localScale.y;
        float depth = gameObject.transform.localScale.z;
        gameObject.transform.localScale = new Vector3(width, height, depth );
    }
}
