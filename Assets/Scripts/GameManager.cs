using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer = 0;
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
    public ScoreCounter scoreCounter;
    AudioManager audioManager;
    // Start is called before the first frame update

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        //scoreCounter = new ScoreCounter();
        NewWave();
        //PlayerPrefs.SetInt("High Score", 420);
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
            float[] rand = randomRange();
            float x = Random.Range(playerPos.x + rand[0], playerPos.x + rand[1]);
            rand = randomRange();
            float y = Random.Range(playerPos.y + rand[0], playerPos.y + rand[1]);

            Vector2 vector = new Vector2(x, y);
            
            Vector3 enemyPos = new Vector3(vector.x, vector.y, playerPos.z);

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);

            enemyList.Add(enemy);
        }

        wave++;
    }

    private float[] randomRange()
    {
        float min = waveRange[0];
        float max = waveRange[1];

        float[] res = new float[2];

        int rand = Random.Range(0, 100);
        if(rand < 25)
        {
            res[0] = min;
            res[1] = max;
            return res;
        } if(rand < 50)
        {
            res[0] = min;
            res[1] = -max;
            return res;
        } if (rand < 75)
        {
            res[0] = -min;
            res[1] = max;
            return res;
        } else
        {
            res[0] = -min;
            res[1] = -max;
            return res;
        }
    }

    //game over
    public void GameOver()
    {
        audioManager.audioSource.clip = audioManager.audioClips[0];
        audioManager.audioSource.Play();
        StartCoroutine(audioManager.waitAudio());
        scoreCounter.SaveHighScore();
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


    public void IncreaseScore(int s)
    {
        score += s;
        
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
