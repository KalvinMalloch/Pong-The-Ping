using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text PlayerOne;
    public Text PlayerTwo;
    public int playerOnePoints = 0;
    public int playerTwoPoints = 0;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerOne.text = "Player 1 Score: " + playerOnePoints;
        PlayerTwo.text = "Player 2 Score: " + playerTwoPoints;
    }
}
