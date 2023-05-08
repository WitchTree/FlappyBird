using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject leaderBoard;
    public TMPro.TextMeshProUGUI playerInput;
    private string playerName;
    [SerializeField] DBManager dbmanager;
    
    
    public GameManager gameManager;
    

    public void Restart()
    {        
        SceneManager.LoadScene("Main");
        if(GameManager.instance.isGameover)
        {
            GameManager.instance.isGameover = false;
        }

    }

    public void SubmitDB()
    {
        playerName=playerInput.text;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        ScoreData DATA = new ScoreData(playerName,gameManager.score);
        string jsondata = JsonUtility.ToJson(DATA);
        reference.Child("Player").Child("_current").SetRawJsonValueAsync(jsondata);  
        for(int i=0;i<30;i++)
        {
            dbmanager.ReadDB();
        }
        
    }

    public void turnOnLeaderBoard()
    {
        gameOver.SetActive(false);
        leaderBoard.SetActive(true);
        for(int i=0;i<30;i++)
        {
            dbmanager.ReadDB();
        }
        
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
