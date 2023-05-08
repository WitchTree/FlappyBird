using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System;


public class UIManager : MonoBehaviour
{
    private static UIManager Instance;
    public GameManager gamemanager;
    public string DBUri = "https://flappybird-c06fd-default-rtdb.asia-southeast1.firebasedatabase.app/";

    public static UIManager instance 
    {
        get 
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<UIManager>();
            }
            return Instance;
        }
    }

    [SerializeField]private Text scoreText;
    [SerializeField] private Text GameOverScore;
    [SerializeField] private Text bestScoreText; 
    [SerializeField] private GameObject newObject;
    [SerializeField] private GameObject copper;
    [SerializeField] private GameObject silver;
    [SerializeField] private GameObject gold;

    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBUri);
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = string.Format("Score: {0}", score);
        if(score<10)
        {
            copper.SetActive(true);
            GameOverScore.text = string.Format("00{0}", score);
        }
        else if(score<100&&score>10)
        {
            
            GameOverScore.text = string.Format("0{0}", score);
            if(score<50)
            {
                silver.SetActive(true);
            }
            else
            {
                gold.SetActive(true);
            }
        }
        else
        {
            gold.SetActive(true);
            GameOverScore.text = string.Format("{0}", score);
        }

        
        FirebaseDatabase.DefaultInstance.GetReference("Player").OrderByChild("Score").
        GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;  
                string best=snapshot.Child("_1").Child("Score").Value.ToString();
                int bestScore;
                int.TryParse(best, out bestScore);

                if(score>=bestScore)
                {
                    newObject.SetActive(true);
                    if(score<10)
                    {
                        GameOverScore.text = string.Format("00{0}", score);
                    }
                    else if(score<100&&score>10)
                    {
                        GameOverScore.text = string.Format("0{0}", score);
                    }
                    else
                    {
                        GameOverScore.text = string.Format("{0}", score);
                    }
                }

                else
                {
                    if(bestScore<10)
                    {
                        bestScoreText.text = string.Format("00{0}", bestScore);
                    }
                    else if(bestScore<100&&bestScore>10)
                    {
                        bestScoreText.text = string.Format("0{0}", bestScore);
                    }
                    else
                    {
                        bestScoreText.text = string.Format("{0}", bestScore);
                    }
                }

            }
        });

    }

   

}
