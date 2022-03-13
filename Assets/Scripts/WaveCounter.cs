using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public GameManager gameManager;
    Text counter;
    // Start is called before the first frame update
    void Start()
    {
         counter = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Wave: " + gameManager.GetWave();
    }
}
