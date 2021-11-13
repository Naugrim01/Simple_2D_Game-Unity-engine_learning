using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{
    RestartPointsManager restartPointsManager;
    // Start is called before the first frame update
    void Start()
    {
        restartPointsManager = GameObject.Find("Manager").GetComponent<RestartPointsManager>();
        if (restartPointsManager == null)
        {
            Debug.LogError("RestartPointsManager not found.");
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            restartPointsManager.UpdateStartPoint(this.gameObject.transform);
        }
    }
}
