using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlockYellow : MonoBehaviour
{
    public int gimmickSelect;
    public int maxPower;
    public int maxMove;

    new RectTransform transform;
    public WindmillYellow Windmill;
    private float power;
    private Vector2 initialPos;
    private float powerBuff;

    private void Gimmick(int nam)
    {
        //消滅
        if(nam == 0)//自壊
        {
            power = Windmill.GetPower();
            if(power >=maxPower)
            {
                Destroy(gameObject);
            }
        }

        //移動上
        if (nam == 1)
        {
            power = Windmill.GetPower();

            if(power>powerBuff)
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
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        initialPos = transform.localPosition;
        Windmill=GameObject.FindWithTag("WindmillYellow").GetComponent<WindmillYellow>();

    }

    // Update is called once per frame
    void Update()
    {

        Gimmick(gimmickSelect);
    }
}
