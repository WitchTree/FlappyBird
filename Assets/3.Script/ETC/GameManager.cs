using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
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

    void Update() {
        if (isGameover) {
            SceneManager.LoadScene("Gameover");
        }
    }
}
