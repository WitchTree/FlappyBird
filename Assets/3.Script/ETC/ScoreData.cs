using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData 
{
    public string Name="";
    public int Score = 0;

    public ScoreData(string name,int score)
    {
        Name=name;
        Score = score;
    }
}
