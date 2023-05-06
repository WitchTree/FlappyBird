using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public string DBUri = "https://flappybird-9f716-default-rtdb.asia-southeast1.firebasedatabase.app/";
    DatabaseReference reference;
    [SerializeField] GameObject gameOver;
    [SerializeField] private DBManager dbmanager;


    [SerializeField]
    private void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBUri);
        Time.timeScale = 1;
    }
    public static GameManager instance 
    {
        get 
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }
    }

    public int score;
    public bool isGameover;

    public void WriteDB()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        ScoreData DATA = new ScoreData(score);
        string jsondata = JsonUtility.ToJson(DATA);
        reference.Child("Player").Child("_current").SetRawJsonValueAsync(jsondata);        

    }

    void Update() {
        if (isGameover) {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            WriteDB();
            
        }
    }
}
