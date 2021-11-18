using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float heroSpeed;
    public float jumpForce;
    public Transform groundTester;
    public LayerMask layersToTest;
    public Transform startPoint;
    public AudioClip clip;
    Animator anim;
    Rigidbody2D rgdBody;
    bool dirToRight = true;
    private bool onTheGround;
    private float radius = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("spikeContact"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }
        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layersToTest);

        float horizontalMove = Input.GetAxis("Horizontal");
        rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y);


        anim.SetFloat("speed",Mathf.Abs(horizontalMove));

        if(horizontalMove < 0 && dirToRight)
        {
            Flip();
        }
        else if (horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }

        if(Input.GetKeyDown (KeyCode.Space)&&onTheGround)
        {
            rgdBody.AddForce (new Vector2 (0f, jumpForce));
            anim.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }

    void Flip()
    {

        dirToRight = !dirToRight;
        Vector2 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
    }

}
