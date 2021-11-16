using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public Transform navStartPoint;
    public Transform navEndPoint;

    private Vector2 startPoint;
    private Vector2 endPoint;

    private Vector2 currentPlatformPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        //transform.Translate(speed, 0, 0);
        transform.position = currentPlatformPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        other.transform.parent = transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " out");
        other.transform.parent = null;
    }

}
