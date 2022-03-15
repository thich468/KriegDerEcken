using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public GameManager GameManager;
    public Transform Player;
    public GameObject indicatorprefab;
    private List<GameObject> indicators = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        List<GameObject> enemies = GameManager.enemyList;
        foreach(GameObject indicator in indicators)
        {
            Destroy(indicator);
        }
        indicators.Clear();
        foreach (GameObject enemy in enemies)
        {
            
            Vector3 direction = Player.position - enemy.transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            GameObject indicator = Instantiate(indicatorprefab, transform.position, Quaternion.Euler(0, 0, angle - 90));
            
            indicator.transform.SetParent(gameObject.transform, false);
            indicators.Add(indicator);
        }
    }
}
