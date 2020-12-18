using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text player1;
    private int scoreP1;
    public Text player2;
    private int scoreP2;
    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored(bool player)
    {
        if (!player)
        {
            scoreP1++;
            player1.text = "" + scoreP1;
            if (scoreP1 >= 3)
            {
                GameWin("Player 1");
            }
            else
            {
                Debug.Log("Player 1 Scored\n" + "Score is " + scoreP1 + "-" + scoreP2);
            }
        }
        if (player)
        {
            scoreP2++;
            player2.text = "" + scoreP2;
            if (scoreP2 >= 3)
            {
                GameWin("Player 2");
            }
            else
            {
                Debug.Log("Player 2 Scored\n" + "Score is " + scoreP1 + "-" + scoreP2);
            }
        }
    }

    void GameWin(string winner)
    {
        Debug.Log(winner + " Won!");
        scoreP1 = 0;
        scoreP2 = 0;
        player1.text = "00";
        player2.text = "00";
    }
}
