using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFog : MonoBehaviour
{
    public float delayTime;

    private Transform playerPosition;
    Transform fogPosition;
    Rigidbody2D rb;

    private Vector2 playerDistance;
    private bool isStay;
    private bool isShot;
    private bool isOverlap;
    private Vector2 OverlapPos;
    private Vector2 overlapDistance;

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
    }


    private void FogShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        fogPosition=GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        delayTime *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = new Vector2(playerPosition.position.x - fogPosition.position.x, playerPosition.position.y - fogPosition.position.y);
        if (!isStay)
        {
            rb.velocity = new Vector2(rb.velocity.x + playerDistance.x / delayTime, rb.velocity.y + playerDistance.y / delayTime);
        }
        else
        {
            if(rb.velocity.x != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x/1.01001f, rb.velocity.y);
            }
            if(rb.velocity.y != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y/1.01001f);
            }
        }

        if(isOverlap)
        {
            overlapDistance = new Vector2(OverlapPos.x - fogPosition.position.x, OverlapPos.y - fogPosition.position.y);
            rb.velocity = new Vector2(rb.velocity.x - overlapDistance.x *0.5f, rb.velocity.y - overlapDistance.y*0.5f );
        }

        rb.velocity = new Vector2(rb.velocity.x * 0.99f, rb.velocity.y * 0.99f);
    }
}
