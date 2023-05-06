using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myName;
    public Text myScore;
    public int currentScore;
    public void SendScore()
    {
        int.TryParse(myScore.text, out currentScore);
        if (currentScore > PlayerPrefs.GetInt("highscore"))
        {
            Debug.Log("¾¾¹ß");
            PlayerPrefs.SetInt("highscore", currentScore);
            HighScores.UploadScore(myName.text, currentScore);
        }
    }

}
