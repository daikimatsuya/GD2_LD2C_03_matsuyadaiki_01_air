using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlockBlue : MonoBehaviour
{
    public int gimmickSelect;
    public int maxPower;
    public int maxMove;

    new RectTransform transform;
    WindmillBlue Windmill;
    private float power;
    private Vector2 initialPos;
    private float powerBuff;

    private void Gimmick(int nam)
    {

        //Á–Å
        if (nam == 0)
        {
            power = Windmill.GetPower();
            if (power >= maxPower)
            {
                Destroy(gameObject);
            }
        }

        //ˆÚ“®ã
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

        //ˆÚ“®‰º
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

        //ˆÚ“®‰E
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

        //ˆÚ“®¶
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
        Windmill = GameObject.FindWithTag("WindmillBlue").GetComponent<WindmillBlue>();
    }

    // Update is called once per frame
    void Update()
    {
        Gimmick(gimmickSelect);
    }
}
