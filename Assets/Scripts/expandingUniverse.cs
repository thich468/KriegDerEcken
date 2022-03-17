using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expandingUniverse : MonoBehaviour
{

    float parralax = 6f;

    public float speedX = 0.1f;
    public float speedY = 0.1f;
    private float curX;
    private float curY;

    // Start is called before the first frame update
    void Start()
    {
        //curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        //curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }


    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;
        mat.mainTextureOffset = offset;
        //curX += Time.deltaTime * speedX;
        //curY += Time.deltaTime * speedY;
        //GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX,curY));
    }
}
