using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutoDestructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Autodestruction", 0.35f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Autodestruction()
    {
        Destroy(this.gameObject);
    }
}
