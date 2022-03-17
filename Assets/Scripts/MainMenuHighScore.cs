using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "High Score:" + PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
