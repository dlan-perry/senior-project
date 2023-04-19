using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;       //Interact with UI elements
using TMPro;                //For TextMeshPro interaction
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    int MaxScores = 10;
    public TextMeshProUGUI[] GlobalScores, FriendScores;
    public TextMeshProUGUI[] GlobalUsers, FriendUsers;
    //public TextMeshProUGUI[] AddButtons;
    public TMP_Text UserHead, ScoreHead;
    //public TMP_Text Button;
    string[,] scores1, scores2;

    // Start is called before the first frame update
    void Start()
    {
        // get scores at start
        ShowScores();
    }

    public void GetLBScores()
    {
        //populate scores1 for global, scores2 for friends

        //use to populate array
        scores1 = new string[,] {{ "Player 1" , "15"},
                                { "Player 2" , "4"},
                                { "Player 3" , "12333333"},
                                { "Player 4" , "9000"}};

        scores2 = new string[,] {{ "Player 11" , "1234235"},
                                { "Player 21" , "4234234"},
                                { "Player 311" , "12332543"},
                                { "Player 41" , "90000000"}};
    }

    public void ShowScores()
    {
        GetLBScores(); // get scores before displaying
        
        //display scores onto TMP elements
        for (int i = 0; i < scores1.GetLength(0); i++)
        {
            GlobalUsers[i].text = scores1[i, 0];
            GlobalScores[i].text = scores1[i, 1];

            FriendUsers[i].text = scores2[i, 0];
            FriendScores[i].text = scores2[i, 1];
        }

        //GlobalScores[0].SetText(scores.GetLength(0).ToString());
        //GlobalUsers[0].text = scores[0, 0];
        //GlobalScores[0].text = scores[0, 1];

        if (scores1.GetLength(0) < MaxScores)
        {
            for (int i = scores1.GetLength(0); i < MaxScores; i++)
            {
                GlobalUsers[i].text = "--";
                GlobalScores[i].text = "--";
            }
        }

    }

    public void AddUser(TextMeshProUGUI u)
    {
        //send player username and leaderboard username to api
        string ThatUser = u.text; //The user being attempted to follow
        string ThisUser = PlayerPersist.getUser(); //The user making the follow request

        //ScoreHead.text = ThisUser; //for testing to show the users on screen
        //UserHead.text = ThatUser;
        Debug.Log("Current User: " + ThisUser);
        Debug.Log("User to Add: " + ThatUser);


        /*
        //changing plus sign if following
        if (ThatUser == "already following")
        {
            //b.text = "-";
        }
        else
        {
            //b.text = "+";
        }*/

    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
