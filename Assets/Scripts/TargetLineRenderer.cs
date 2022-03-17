using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLineRenderer : MonoBehaviour
{
    private LineRenderer lr;
    public Transform[] points;

    public Transform player;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLines(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i] != null)
            {
               lr.SetPosition(i, points[i].position); 
            }
        }
        
    }
}
