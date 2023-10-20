using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerFog : MonoBehaviour
{
    public float delayTime;
    public float shotPower;

    private Player ps;
    private Transform playerPosition;
    Transform fogPosition;
    Rigidbody2D rb;
    new Collider2D collider;
    UnityEngine.UI.Image image;

    private Vector2 playerDistance;
    private bool isStay;
    private bool isShot;
    private bool isOverlap;
    private Vector2 OverlapPos;
    private Vector2 overlapDistance;
    private float playerRotate;
    private bool canShot;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fogArea")
        {
            isStay = true;
        }
        if(collision.tag == "PlayerFog")
        {
            isOverlap = true;
            OverlapPos = collision.transform.position;
            if (collision.transform == fogPosition.transform)
            {
                OverlapPos = new Vector2(collision.transform.position.x + 1, collision.transform.position.y + 2);
            }
           
        }
        if(collision.tag == "shotLeng")
        {
            canShot = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "fogArea")
        {
            isStay = false;
        }
        if (collision.tag == "PlayerFog")
        {
            isOverlap = false;
        }
        if(isShot)
        {
            if(collision.tag == "shotLeng")
            {
                collider.isTrigger = false;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFog")
        {
            isOverlap = true;
        }
        if (isShot)
        {
            if (collision.gameObject.tag == "fogArea")
            {
                collider.isTrigger = true;
            }
        }
    }


    private void FogShoot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isShot)
            {
                collider.isTrigger = true;
                isShot = false;
                canShot = false;
                image.color=new Color(255,255,255, 255);
            }
            else
            {
                if (canShot)
                {
                    image.color = new Color(0.0f, 255, 0.0f, 255.0f);
                    rb.velocity = Vector3.zero;
                    rb.velocity = new Vector2(rb.velocity.x + shotPower * (float)math.cos(ToRadian(playerRotate)), rb.velocity.y + shotPower * (float)math.sin(ToRadian(playerRotate)));
                    isShot = true;
                }
            }
        }
  
        
                    
    }
    private void StayCheck()
    {
        if (!isShot)
        {
            if (!isStay)
            {

                rb.velocity = new Vector2(rb.velocity.x + playerDistance.x / delayTime, rb.velocity.y + playerDistance.y / delayTime);
            }
            else
            {
                if (rb.velocity.x != 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x / 1.12001f, rb.velocity.y);
                }
                if (rb.velocity.y != 0)
                {

                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 1.12001f);
                }
            }
        }
    }
    private void OverLapCheck()
    {
        if (isOverlap)
        {
            overlapDistance = new Vector2(OverlapPos.x - fogPosition.position.x, OverlapPos.y - fogPosition.position.y);
            rb.velocity = new Vector2(rb.velocity.x - overlapDistance.x * 0.4f, rb.velocity.y - overlapDistance.y * 0.4f);
        }
    }

    public double ToRadian(double angle)
    {
        return angle * Math.PI / 180f;
    }
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        ps = GameObject.Find("Player").GetComponent<Player>();
        fogPosition=GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider=GetComponent<Collider2D>();
        image=gameObject.GetComponent<UnityEngine.UI.Image>();
        delayTime *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        playerRotate=ps.GetPlayerRotate();
        playerDistance = new Vector2(playerPosition.position.x - fogPosition.position.x, playerPosition.position.y - fogPosition.position.y);
       
        StayCheck();
        OverLapCheck();
        FogShoot();
        rb.velocity = new Vector2(rb.velocity.x * 0.95f, rb.velocity.y * 0.95f);

        isOverlap = false;


    }
        
}
