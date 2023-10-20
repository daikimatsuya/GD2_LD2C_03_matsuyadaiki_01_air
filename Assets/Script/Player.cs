using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    RectTransform tf;

    private Vector2 vector;
    private Vector2 rbCheck;
    private float playerRotate;
    private bool isInGame;

    public float maxSpeed;
    public float acceleration;
    public float brakeTime;
    public float brakePower;
    private int stageSelect;
    private bool isInGate;

    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "gate")
        {
            isInGate = true;
        }
        if (isInGate)
        {
            if (collision.tag == "stage1Gate")
            {
                stageSelect = 1;
            }
        }
        if (isInGame)
        {
           
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "gate")
        {
            stageSelect = 0;
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

        /*プレイヤーの移動*/{
            //プレイヤーの速度加算と角度代入
            //上下左右
            if (Input.GetKey(KeyCode.UpArrow))
            {                                
                playerRotate = 90.0f;
                vector.y = acceleration * (float)math.sin(ToRadian(playerRotate));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {           
                playerRotate = -90.0f;
                vector.y = acceleration * (float)math.sin(ToRadian(playerRotate));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {       
                playerRotate = 180.0f;
                vector.x = acceleration * (float)math.cos(ToRadian(playerRotate));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
   
                playerRotate = 0.0f;
                vector.x = acceleration * (float)math.cos(ToRadian(playerRotate));
            }
            //斜め
            if(Input.GetKey(KeyCode.UpArrow)&& Input.GetKey(KeyCode.LeftArrow)){
                playerRotate = 135.0f;
            }
            if (Input.GetKey(KeyCode.UpArrow)&& Input.GetKey(KeyCode.RightArrow)){
                playerRotate = 45.0f;
            }
            if(Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.LeftArrow)){
                playerRotate = -135.0f;
            }
            if (Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.RightArrow)){
                playerRotate = -45.0f;
            }

            //プレイヤーのブレーキ
            if (Input.GetKey(KeyCode.UpArrow) == false)
            {
                if (Input.GetKey(KeyCode.DownArrow) == false)
                {
                    VectorBrakeY();
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) == false)
            {
                if (Input.GetKey(KeyCode.RightArrow) == false)
                {
                    VectorBrakeX();
                }
            }
        }

        rb.velocity = new Vector2(rb.velocity.x + vector.x, rb.velocity.y + vector.y);



        //clamp
        {
            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector2((float)maxSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x < -maxSpeed)
            {
                rb.velocity = new Vector2(-(float)maxSpeed, rb.velocity.y);
            }
            if (rb.velocity.y > maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, (float)maxSpeed);
            }
            else if (rb.velocity.y < -maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -(float)maxSpeed);
            }
        }


        tf.transform.rotation = Quaternion.Euler(0f, 0f, playerRotate);
    }
    public int GetStageSelect()
    {
        return stageSelect;
    }

    public double ToRadian(double angle)
    {
        return angle * Math.PI / 180f;
    }
    public float GetPlayerRotate()
    {
        return playerRotate;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf=GetComponent<RectTransform>();
        isInGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}
