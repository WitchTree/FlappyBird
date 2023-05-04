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

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBUri);
        WriteDB();
        ReadDB();
    }

    public void WriteDB()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        ScoreData DATA1 = new ScoreData(10);
        ScoreData DATA2 = new ScoreData(5);
        string jsondata1 = JsonUtility.ToJson(DATA1);
        string jsondata2 = JsonUtility.ToJson(DATA2);
        reference.Child("Player").Child("_1").SetRawJsonValueAsync(jsondata1);
        reference.Child("Player").Child("_2").SetRawJsonValueAsync(jsondata2);

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


                    Debug.Log("Á¡¼ö :" + ScoreData["Score"]);
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class ScoreData
{
    public int Score = 0;

    public ScoreData(int score)
    {
        Score = score;
    }
}

