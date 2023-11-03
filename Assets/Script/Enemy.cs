using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    private Vector2 playerPos;
    private Vector2 playerDistance;
    private new Transform transform;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>(); 
        rb = GetComponent<Rigidbody2D>(); 
    }
    public void GetPlayerPos(Vector2 Pos)
    {
        playerPos = Pos;
        playerDistance = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        rb.velocity = new Vector2(rb.velocity.x + playerDistance.x / 1.0f, rb.velocity.y + playerDistance.y / 1.0f); 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
  
    }
}
