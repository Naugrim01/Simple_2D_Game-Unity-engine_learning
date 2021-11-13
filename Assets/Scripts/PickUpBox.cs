using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    CounterController counterController;
    // Start is called before the first frame update
    void Start()
    {
        counterController = GameObject.Find("Manager").GetComponent<CounterController>();
        if(counterController == null)
        {
            Debug.LogError("CounterController not found.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Jack")
        {
            Destroy(this.gameObject);
            counterController.IncrementCounter();
        }
    }
}