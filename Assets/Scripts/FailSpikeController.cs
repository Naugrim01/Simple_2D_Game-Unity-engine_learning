using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSpikeController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Jack")
        {
            other.transform.GetComponent<Animator>().SetTrigger("fail");
        }
    }
}