using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class WindmillBlue : MonoBehaviour
{

    private float power;
    private float convertPower;
    private int setStoreTime;
    private int storeTime;
    private bool ishitWind;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFog")
        {
            Collider2D collider = collision.GetComponent<Collider2D>();
            if (!collider.isTrigger)
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                power += (float)System.Math.Sqrt((rb.velocity.x * rb.velocity.x)) * convertPower;
                ishitWind = true;
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFog")
        {
            ishitWind = false;
        }
    }

    public float GetPower()
    {
        return power;
    }

    private void Store()
    {
        if (storeTime < 0)
        {
            if (power > 0)
            {
                power -= 10;
                if (power < 0)
                {
                    power = 0;
                }
            }
        }
        if (ishitWind)
        {
            storeTime = setStoreTime * 60;
        }
        else
        {
            storeTime -= 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        setStoreTime = 2;
        storeTime = setStoreTime * 60;
        convertPower = 0.01f;
    
    }

    // Update is called once per frame
    void Update()
    {
        Store();
    }
}
