using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public string DBUri = "https://flappybird-c06fd-default-rtdb.asia-southeast1.firebasedatabase.app/";
    DatabaseReference reference; 
    public TMPro.TextMeshProUGUI score1;
    public TMPro.TextMeshProUGUI score2;
    public TMPro.TextMeshProUGUI score3;
    public TMPro.TextMeshProUGUI score4;
    public TMPro.TextMeshProUGUI score5;

    public TMPro.TextMeshProUGUI name1;
    public TMPro.TextMeshProUGUI name2;
    public TMPro.TextMeshProUGUI name3;
    public TMPro.TextMeshProUGUI name4;
    public TMPro.TextMeshProUGUI name5;
    public GameManager gameManager;   



    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(DBUri);
        for(int i=0;i<30;i++)
        {
            ReadDB();
        }
        
    }


    public void ReadDB()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Player").OrderByChild("Score").
        GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;  
                string best=snapshot.Child("_1").Child("Score").Value.ToString();
                string second=snapshot.Child("_2").Child("Score").Value.ToString();
                string third=snapshot.Child("_3").Child("Score").Value.ToString();
                string fourth=snapshot.Child("_4").Child("Score").Value.ToString();
                string last=snapshot.Child("_5").Child("Score").Value.ToString();
                string current=snapshot.Child("_current").Child("Score").Value.ToString();

                string bestPlayer=snapshot.Child("_1").Child("Name").Value.ToString();
                string secondPlayer=snapshot.Child("_2").Child("Name").Value.ToString();
                string thirdPlayer=snapshot.Child("_2").Child("Name").Value.ToString();
                string fourthPlayer=snapshot.Child("_2").Child("Name").Value.ToString();
                string lastPlayer=snapshot.Child("_2").Child("Name").Value.ToString();
                string currentPlayer=snapshot.Child("_current").Child("Name").Value.ToString();

                int bestScore;
                int secondScore;
                int thirdScore;
                int fourthScore;
                int lastScore;
                int currentScore;

                int.TryParse(best, out bestScore);
                int.TryParse(second, out secondScore);
                int.TryParse(third, out thirdScore);
                int.TryParse(fourth, out fourthScore);
                int.TryParse(last, out lastScore);
                int.TryParse(current, out currentScore);

                if(currentScore>bestScore){    
                    ScoreData DATA = new ScoreData(currentPlayer,currentScore);
                    string jsondata = JsonUtility.ToJson(DATA);
                    reference.Child("Player").Child("_1").SetRawJsonValueAsync(jsondata); 

                }

                else if(currentScore>=secondScore&&currentScore<bestScore){
                    
                    ScoreData DATA = new ScoreData(currentPlayer,currentScore);
                    string jsondata = JsonUtility.ToJson(DATA);
                    reference.Child("Player").Child("_2").SetRawJsonValueAsync(jsondata);    
                }

                else if(currentScore>=thirdScore&&currentScore<secondScore){
                    
                    ScoreData DATA = new ScoreData(currentPlayer,currentScore);
                    string jsondata = JsonUtility.ToJson(DATA);
                    reference.Child("Player").Child("_3").SetRawJsonValueAsync(jsondata);    
                }

                else if(currentScore>=fourthScore&&currentScore<thirdScore){
                   
                    ScoreData DATA = new ScoreData(currentPlayer,currentScore);
                    string jsondata = JsonUtility.ToJson(DATA);
                    reference.Child("Player").Child("_4").SetRawJsonValueAsync(jsondata);    
                }

                else if(currentScore>=lastScore&&currentScore<fourthScore){
                    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                    ScoreData DATA = new ScoreData(currentPlayer,currentScore);
                    string jsondata = JsonUtility.ToJson(DATA);
                    reference.Child("Player").Child("_5").SetRawJsonValueAsync(jsondata);    
                }


                else
                {
                    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                }
                best=snapshot.Child("_1").Child("Score").Value.ToString();
                second=snapshot.Child("_2").Child("Score").Value.ToString();
                third=snapshot.Child("_3").Child("Score").Value.ToString();
                fourth=snapshot.Child("_4").Child("Score").Value.ToString();
                last=snapshot.Child("_5").Child("Score").Value.ToString();
                current=snapshot.Child("_current").Child("Score").Value.ToString();

                bestPlayer=snapshot.Child("_1").Child("Name").Value.ToString();
                secondPlayer=snapshot.Child("_2").Child("Name").Value.ToString();
                thirdPlayer=snapshot.Child("_3").Child("Name").Value.ToString();
                fourthPlayer=snapshot.Child("_4").Child("Name").Value.ToString();
                lastPlayer=snapshot.Child("_5").Child("Name").Value.ToString();
                currentPlayer=snapshot.Child("_current").Child("Name").Value.ToString();

                int.TryParse(best, out bestScore);
                int.TryParse(second, out secondScore);
                int.TryParse(third, out thirdScore);
                int.TryParse(fourth, out fourthScore);
                int.TryParse(last, out lastScore);
                int.TryParse(current, out currentScore);

                name1.text = string.Format("{0}", bestPlayer);
                name2.text=string.Format("{0}", secondPlayer);
                name3.text = string.Format("{0}", thirdPlayer);
                name4.text=string.Format("{0}", fourthPlayer);
                name5.text=string.Format("{0}", lastPlayer);

                score1.text=string.Format("{0}", bestScore);
                score2.text=string.Format("{0}", secondScore);
                score3.text=string.Format("{0}", thirdScore);
                score4.text=string.Format("{0}", fourthScore);
                score5.text=string.Format("{0}", lastScore);                
                
            }
        });
        

        
    }

}



