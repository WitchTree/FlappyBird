using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public string DBUri = "https://flappybird-9f716-default-rtdb.asia-southeast1.firebasedatabase.app/";
    DatabaseReference reference;
    [SerializeField] private Text scoreText;
    public GameManager gameManager;
    public int BestScore;
    public int CurrentScore;


    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBUri);
        ReadDB();
    }

    public void ReadDB()
    {
        reference = FirebaseDatabase.DefaultInstance.GetReference("Player");
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;  
                
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary ScoreData = (IDictionary)data.Value;
                    //Debug.Log("Á¡¼ö :" + ScoreData["Score"]);

                }
            }
        });
    }

}



