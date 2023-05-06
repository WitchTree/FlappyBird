using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject leaderBoard;
    public void Restart()
    {        
        SceneManager.LoadScene("Main");

    }

    public void turnOnLeaderBoard()
    {
        gameOver.SetActive(false);
        leaderBoard.SetActive(true);
    }

    public void turnOffLeaderBoard()
    {
        leaderBoard.SetActive(false);
        gameOver.SetActive(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
