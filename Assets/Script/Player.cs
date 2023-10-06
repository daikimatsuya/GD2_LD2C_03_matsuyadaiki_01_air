using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    private Vector2 vector;
    private Vector2 rbCheck;
    private bool isInGame;
    private int stageNumber;

    public float maxSpeed;
    public float acceleration;
    public float brakeTime;
    public float brakePower;
    public string stage1;

    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (isInGame)
        {
           
        }
    }

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

        rb.velocity = new Vector2(rb.velocity.x + vector.x, rb.velocity.y + vector.y);

        if (rb.velocity.x>maxSpeed)
        {
            rb.velocity = new Vector2((float)maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-(float)maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x,(float)maxSpeed);
        }
        else if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -(float)maxSpeed);
        }


    }

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isInGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rbCheck = rb.velocity;
        PlayerMove();
    }
}
