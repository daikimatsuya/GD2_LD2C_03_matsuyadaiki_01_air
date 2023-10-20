using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlockYellow : MonoBehaviour
{
    public int gimmickSelect;
    public int maxPower;

    new Transform transform;
    WindmillYellow Windmill;
    private float power;

    private void Gimmick(int nam)
    {
        if(nam == 0)//Ž©‰ó
        {
            power = Windmill.GetPower();
            if(power >=maxPower)
            {
                Destroy(gameObject);
            }
        }
        if(nam == 1)
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        Windmill=GameObject.Find("WindmillYellow").GetComponent<WindmillYellow>();
    }

    // Update is called once per frame
    void Update()
    {

        Gimmick(gimmickSelect);
    }
}
