using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer;
    GameObject player;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject gameOverCanvas;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public int enemiesPerWave = 10;
    public float[] waveRange = { 6f, 10f };
    private int wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        NewWave();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(enemyList.Count);
        if(enemyList.Count == 0)
        {
            NewWave();
        }
        
    }
    
    //new wave of enemies
    void NewWave()
    {
        if (player == null) { return; }
        Vector3 playerPos = player.transform.position;
        Debug.Log(playerPos.ToString());
        for(int i = 0; i < enemiesPerWave; i++)
        {
            float x = Random.Range(playerPos.x + waveRange[0], playerPos.x + waveRange[1]);
            float y = Random.Range(playerPos.y + waveRange[0], playerPos.y + waveRange[1]);
            Vector2 vector = Quaternion.Euler(0,0, Random.Range(0f, 359.9f))* new Vector2(x,y);
            vector = new Vector2(playerPos.x, playerPos.y) + vector;
            Vector3 enemyPos = new Vector3(vector.x, vector.y, playerPos.z);
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], enemyPos, Quaternion.identity);
            enemyList.Add(enemy);
        }
        wave++;

    }

    //game over
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }

    public int GetWave()
    {
        return wave;
    }
}
