using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string stage1;
        
    private Player playerScript;

    public void SceneChanges(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }
    private void ChangeStage(int stage)
    {
        if(stage == 0)
        {
            return;
        }
        else
        {
            if (stage == 1)
            {
                SceneChanges(stage1);
            }
        }
    }

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
        if(Input.GetKeyDown(KeyCode.Space)) { 
            ChangeStage(playerScript.GetStageSelect());
        }
        if (playerScript.GetPlayerHitPoint() == 0)
        {

        }
    }
}
