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
        //positions of start and stop moving platform
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //modification of prathorm position
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPlatformPosition;
    }
    //when player is on the platform:
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            other.transform.parent = transform;
        }
    }
    //when player is leaving the platform
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " out");
            other.transform.parent = null;
        }
    }

}
