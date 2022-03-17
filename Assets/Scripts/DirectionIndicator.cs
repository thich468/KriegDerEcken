using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(100)]
public class DirectionIndicator : MonoBehaviour
{
    public float screenBorderSize = 0.01f;
    public GameObject indicatorPrefab;
    GameObject indicatorObject;

    // Start is called before the first frame update
    void Start()
    {
        indicatorObject = Instantiate(indicatorPrefab);
        indicatorObject.transform.SetParent(transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPoint.x<0 || screenPoint.x > Screen.width || screenPoint.y < 0 || screenPoint.y > Screen.height)
        {
            //out of camera
            indicatorObject.SetActive(true);

            Vector3 clampedScreenPoint = screenPoint;
            clampedScreenPoint.x = Mathf.Clamp(clampedScreenPoint.x, Screen.width * screenBorderSize, Screen.width - Screen.width * screenBorderSize);
            clampedScreenPoint.y = Mathf.Clamp(clampedScreenPoint.y, Screen.height * screenBorderSize, Screen.height - Screen.height * screenBorderSize);

            indicatorObject.transform.position = Camera.main.ScreenToWorldPoint(clampedScreenPoint);
            Vector3 lookDirection = transform.position - Camera.main.transform.position;
            lookDirection.z = 0;
            indicatorObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
        }
        else
        {
            //inside camera
            indicatorObject.SetActive(false);
        }
    }
}
