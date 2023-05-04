using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager Instance;
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

    public void UpdateScoreUI(int score) 
    {
        scoreText.text = string.Format("Score: {0}", score);
    }
}
