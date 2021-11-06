using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float heroSpeed;
    public float jumpForce;
    Animator anim;
    Rigidbody2D rgdBody;
    bool dirToRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if(Input.GetKeyDown (KeyCode.Space))
        {
            rgdBody.AddForce (new Vector2 (0f, jumpForce));
            anim.SetTrigger("jump");
        }
    }

    void Flip()
    {

        dirToRight = !dirToRight;
        Vector2 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }
}
