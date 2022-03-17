using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer;
    public GameObject player;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] public TargetLineRenderer targetLineRenderer;
    [SerializeField] public Transform[] points;
    public GameObject gameOverCanvas;
    public GameObject PauseCanvas;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public int enemiesPerWave = 2;

    public float[] waveRange = { 6f, 10f };
    private int wave = 0;
    private int score = 0;
    ScoreCounter scoreCounter;
    // Start is called before the first frame update

    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        scoreCounter = new ScoreCounter();
        NewWave();
    }


    // Update is called once per frame
    void Update()
    {

        //Debug.Log(enemyList.Count);

        if (Input.GetKeyDown("escape"))
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (enemyList.Count == 0)
        {
            NewWave();
        }
    }

    
    //new wave of enemies
    void NewWave()
    {
        //every third wave, one more enemy per wave
        if(wave % 3 == 0)
        {
            enemiesPerWave++;
        }

        if (player == null) { return; }
        Vector3 playerPos = player.transform.position;
        //Debug.Log(playerPos.ToString());

        for(int i = 0; i < enemiesPerWave; i++)
        {

            float x = Random.Range(playerPos.x + waveRange[0], playerPos.x + waveRange[1]);
            float y = Random.Range(playerPos.y + waveRange[0], playerPos.y + waveRange[1]);

            Vector2 vector = Quaternion.Euler(0,0, Random.Range(0f, 359.9f))* new Vector2(x,y);
            vector = new Vector2(playerPos.x, playerPos.y) + vector;
            Vector3 enemyPos = new Vector3(vector.x, vector.y, playerPos.z);

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);

            enemyList.Add(enemy);
        }

        wave++;
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
        scoreCounter.SaveHighScore();
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;

    }


    public void IncreaseScore()
    {
        score += 5;
        
    }

    public int GetScore()
    {
        
        return score;
    }

    public int GetWave()
    {
        return wave;
    }
}
