using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Physics2D.gravity = new Vector3(0.0f, 0.0f, 0.0f);
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
