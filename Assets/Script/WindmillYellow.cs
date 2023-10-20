using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class WindmillYellow : MonoBehaviour
{
  
    private float power;
    public float convertPower;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFog")
        {
            Collider2D collider = collision.GetComponent<Collider2D>();
            if (!collider.isTrigger)
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                power += (float)System.Math.Sqrt((rb.velocity.x * rb.velocity.x)) * convertPower;
            }
        }

    }

    public float GetPower()
    {
        return power;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
