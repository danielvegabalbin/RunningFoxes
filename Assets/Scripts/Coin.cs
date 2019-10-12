using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour //ControlScene
{
    public int coinValue = 1;
    Score score;

    public void Update()
    {
        score = GameObject.FindGameObjectWithTag("ScoreGO").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other .gameObject.CompareTag("Player"))
        {
            score.changeScore(coinValue);
        }
    }



}