using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A HUD
/// </summary>
public class HUD : MonoBehaviour
{
    #region Fields

    // scoring support
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI coinText;

    int score;
    int coin;


    const string ScorePrefix = "Score: ";
    const string coins = "Coin: ";
  


    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        coinText.text = coins + score.ToString();
        scoreText.text = ScorePrefix + score.ToString();
        
       
        //scoreText.color = Color.white;
    }

    internal void AddCoin()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds the given points to the score
    /// </summary>
    /// <param name="points">points</param>
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
    public void AddCoin(int points)
    {
        coin += points;
        coinText.text = coins + coin.ToString();
    }



}
