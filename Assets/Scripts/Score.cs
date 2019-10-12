using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score :  MonoBehaviour
{
    public TextMeshProUGUI monedaTXT;
    public int score;

   
    public void changeScore(int coinValue)
    {
        score += coinValue; 
        monedaTXT.text = "Monedas = " + score.ToString(); 
        
    }

 
}
