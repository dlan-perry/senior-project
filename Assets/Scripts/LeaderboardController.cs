using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;       //Interact with UI elements
using TMPro;                //For TextMeshPro interaction
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    int MaxScores = 10;
    public TextMeshProUGUI[] GlobalScores;
    public TextMeshProUGUI[] GlobalUsers;
    string[,] scores;

    // Start is called before the first frame update
    void Start()
    {
        // get scores at start
        ShowScores();
    }

    void GetLBScores()
    {
        //use to populate array
        scores = new string[,] {{ "Player 1" , "15"},
                                { "Player 2" , "4"},
                                { "Player 3" , "12333333"},
                                { "Player 4" , "9000"}};
    }

    public void ShowScores()
    {
        GetLBScores(); // get scores before displaying
        
        //display scores onto TMP elements
        for (int i = 0; i < scores.GetLength(0); i++)
        {
            GlobalUsers[i].text = scores[i, 0];
            GlobalScores[i].text = scores[i, 1];
            
        }

        //GlobalScores[0].SetText(scores.GetLength(0).ToString());
        //GlobalUsers[0].text = scores[0, 0];
        //GlobalScores[0].text = scores[0, 1];

        if (scores.GetLength(0) < MaxScores)
        {
            for (int i = scores.GetLength(0); i < MaxScores; i++)
            {
                GlobalUsers[i].text = "--";
                GlobalScores[i].text = "--";
            }
        }

    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
