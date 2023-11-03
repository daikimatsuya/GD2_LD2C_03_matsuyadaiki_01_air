using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float coolTime;
    public float windTime;
    public bool backBeat;
        
   private float coolTimeBuff;
   private float windTimeBuff;
   public GameObject area;
   
    // Start is called before the first frame update
    void Start()
    {
        area = transform.GetChild(0).gameObject;
        if(backBeat == true)
        {
            coolTimeBuff = coolTime*60;
            windTimeBuff = 0;
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
                coolTimeBuff =coolTime * 60;
                area.SetActive(false);
            }
        }
        if(coolTimeBuff > 0)
        {
            coolTimeBuff--;
            if(coolTimeBuff <= 0 && windTimeBuff <= 0)
            {
                windTimeBuff=windTime * 60;
                area.SetActive(true);
            }
        }
    }
}
