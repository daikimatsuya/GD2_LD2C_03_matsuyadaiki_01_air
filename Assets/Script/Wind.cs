using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float coolTime;
    public float windTime;
    public float offTime;
    public bool backBeat;
        
    public float coolTimeBuff;
    public float windTimeBuff;
    public float offTimeBuff;
    private bool isCool;
    public GameObject area;
   
    // Start is called before the first frame update
    void Start()
    {
        area = transform.GetChild(0).gameObject;
        if(backBeat == true)
        {
            coolTimeBuff = (coolTime)*60;
            windTimeBuff = 0;
            area.SetActive(false);
        }
        else
        {
            windTimeBuff= windTime*60;
            coolTimeBuff = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(windTimeBuff > 0)
        {
            windTimeBuff--;
            if(windTimeBuff <= 0 && coolTimeBuff <= 0)
            {
                offTimeBuff=offTime*60;
                area.SetActive(false);
               
            }
        }
        if(coolTimeBuff > 0)
        {
            coolTimeBuff--;
            if(coolTimeBuff <= 0 && windTimeBuff <= 0)
            {
                offTimeBuff = offTime * 60;
                isCool = true;
            }
        }
        if (offTimeBuff > 0) {
            offTimeBuff--;
            if(offTimeBuff <= 0)
            {
                if(isCool)
                {
                    isCool = false;
                    area.SetActive(true);
                    windTimeBuff=windTime*60;
                }
                else
                {
                    coolTimeBuff= coolTime * 60;
                }
            }
        }
    }
}
