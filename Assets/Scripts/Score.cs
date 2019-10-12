using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score :  MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;

   
    public void changeScore(int coinValue)
    {
        score += coinValue; 
        text.text = "x" + score.ToString(); 
        
    }

 
}
