using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System;

public class GimmickBlockBlue : MonoBehaviour
{
    public int gimmickSelect;
    public int maxPower;
    public int maxMove;

    new RectTransform transform;
    WindmillBlue Windmill;
    private float power;
    private Vector2 initialPos;
    private float initialRad;
    private float powerBuff;
    private float BuffBuff;

    private void Gimmick(int nam)
    {

        //消滅
        if (nam == 0)
        {
            power = Windmill.GetPower();
            if (power >= maxPower)
            {
                Destroy(gameObject);
            }
        }

        //移動１〜４
        {
            //移動上
            if (nam == 1)
            {
                power = Windmill.GetPower();

                if (power > powerBuff)
                {
                    if (powerBuff < maxMove)
                    {
                        powerBuff += 5;
                    }

                }
                if (power < powerBuff)
                {
                    powerBuff -= 5;
                }
                transform.localPosition = new Vector3(initialPos.x, initialPos.y + powerBuff);
            }

            //移動下
            if (nam == 2)
            {
                power = Windmill.GetPower();

                if (power > powerBuff)
                {
                    if (powerBuff < maxMove)
                    {
                        powerBuff += 5;
                    }

                }
                if (power < powerBuff)
                {
                    powerBuff -= 5;
                }
                transform.localPosition = new Vector3(initialPos.x, initialPos.y - powerBuff);
            }

            //移動右
            if (nam == 3)
            {
                power = Windmill.GetPower();

                if (power > powerBuff)
                {
                    if (powerBuff < maxMove)
                    {
                        powerBuff += 5;
                    }

                }
                if (power < powerBuff)
                {
                    powerBuff -= 5;
                }
                transform.localPosition = new Vector3(initialPos.x + powerBuff, initialPos.y);
            }

            //移動左
            if (nam == 4)
            {
                power = Windmill.GetPower();

                if (power > powerBuff)
                {
                    if (powerBuff < maxMove)
                    {
                        powerBuff += 5;
                    }

                }
                if (power < powerBuff)
                {
                    powerBuff -= 5;
                }
                transform.localPosition = new Vector3(initialPos.x - powerBuff, initialPos.y);
            }
        }
        
        //時計回りに回転
        if(nam== 5)
        {
            power = Windmill.GetPower();
            powerBuff = power;
            if (power > 0)
            {
                BuffBuff += powerBuff;
            }
            else if (power <= 0)
            {
                if (BuffBuff > 0)
                {
                    BuffBuff -= 100;
                }
            }
            transform.rotation = Quaternion.Euler(0, 0, -BuffBuff/500);
        }
    }
    public double ToRadian(double angle)
    {
        return angle * Math.PI / 180f;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        initialPos = transform.localPosition;
        initialRad = transform.localRotation.z;
        Windmill = GameObject.FindWithTag("WindmillBlue").GetComponent<WindmillBlue>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Gimmick(gimmickSelect);
    }
}
