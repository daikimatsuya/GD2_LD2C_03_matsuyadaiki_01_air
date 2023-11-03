using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchingArea : MonoBehaviour
{
    private Transform playerPos;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerPos=GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemy= transform.parent.GetComponent<Enemy>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.GetPlayerPos(playerPos.position);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
