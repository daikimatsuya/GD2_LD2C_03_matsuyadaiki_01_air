using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    private Vector2 vector;
    private Vector2 rbCheck;

    public float maxSpeed;
    public float acceleration;
    public float brakeTime;
    public float brakePower;

    // Start is called before the first frame update
    private void VectorBrakeX()
    {
        if (rb.velocity.x > 0.1||rb.velocity.x<-0.1)
        {
            if(rb.velocity.x > 0.1f)
            {
                rb.velocity = new Vector2(rb.velocity.x - brakePower, rb.velocity.y);
                if(rb.velocity.x <= 0.0f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                }
            }
            if(rb.velocity.x < -0.1f)
            {
                rb.velocity = new Vector2(rb.velocity.x+brakePower, rb.velocity.y);
                if( rb.velocity.x >= 0.0f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                }
            }
        }
   
    }
    private void VectorBrakeY()
    {
        if (rb.velocity.y > 0.1 || rb.velocity.y < -0.1)
        {
            if (rb.velocity.y > 0.1f)
            {
                rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y - brakePower);
                if (rb.velocity.y <= 0.0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                }
            }
            if (rb.velocity.y < -0.1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + brakePower);
                if (rb.velocity.y >= 0.0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                }
            }
        }
    }
    public void PlayerMove()
    {
        vector= Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector.y = acceleration;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector.y = -acceleration;

        }
        if (Input.GetKey(KeyCode.UpArrow) == false)
        {
            if (Input.GetKey(KeyCode.DownArrow) == false)
            {
                VectorBrakeY();
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vector.x = -acceleration;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vector.x = acceleration;

        }
        if (Input.GetKey(KeyCode.LeftArrow) == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) == false)
            {
                VectorBrakeX();
            }
        }

        if (vector.x>maxSpeed)
        {
            vector.x = (float)maxSpeed;
        }
        else if (vector.x < -maxSpeed)
        {
            vector.x= -(float)maxSpeed;
        }
        if (vector.y>maxSpeed)
        {
            vector.y= (float)maxSpeed;
        }
        else if (vector.y < -maxSpeed)
        {
            vector.y=- (float)maxSpeed;
        }

        rb.velocity = new Vector2(rb.velocity.x + vector.x, rb.velocity.y + vector.y);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        int a = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int c = 0;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        int b = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //rbCheck = rb.velocity;
        PlayerMove();
    }
}
