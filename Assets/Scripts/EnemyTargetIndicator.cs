using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetIndicator : MonoBehaviour
{
    public Transform target;
    public Transform[] Targets;
    public List<GameObject> IndicatorsList = new List<GameObject>();
    public List<GameObject> IndicatorsPrefabs = new List<GameObject>();
    public float HideDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform enemy in Targets)
        {
            
            Vector3 direction = enemy.position - transform.position;
            if (direction.magnitude < HideDistance)
            {
                SetChildrenActive(false);
            }
            else
            {
                SetChildrenActive(true);
                float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg * -1;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void CreateIndicators(Transform[] enemies)
    {
        GameObject indicator = Instantiate(IndicatorsPrefabs[Random.Range(0, IndicatorsPrefabs.Count)], transform.position, Quaternion.identity);
        IndicatorsList.Add(indicator);
    }

    private void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
            {
                child.gameObject.SetActive(value);
            }
    }

    public void SetEnemyTargets(Transform[] targets)
    {
        this.Targets = targets;
    }
}
