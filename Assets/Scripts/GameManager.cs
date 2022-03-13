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
        Vector3 playerPos = player.transform.position;
        Debug.Log(playerPos.ToString());
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(playerPos.x + 7, playerPos.x + 13);
            float y = Random.Range(playerPos.y + 7, playerPos.y + 13);
            Vector2 vector = Quaternion.Euler(0,0, Random.Range(0f, 359.9f))* new Vector2(x,y);
            Vector3 enemyPos = new Vector3(vector.x, vector.y, playerPos.z);
            GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
            enemyList.Add(enemy);
        }

    }

    //game over
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }
}
