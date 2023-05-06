using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager Instance;
    public GameManager gamemanager;
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

    public void UpdateScoreUI(long score)
    {
        scoreText.text = string.Format("Score: {0}", score);
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

}
