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
        Debug.Log("Getting Scores");
        //populate scores1 for global, scores2 for friends
        UserScore[] global = API.getLeaderboard(0).scores;
        UserScore[] local = API.getLeaderboard(2).scores;
        //use to populate array

        scores1 = new string[global.GetLength(0),2];
        for (int i = 0; i < global.GetLength(0); i++) {
            scores1[i, 0] = global[i].user_id.ToString() + ":" + global[i].username;
            scores1[i, 1] = global[i].high_score.ToString() ;
        }

        scores2 = new string[local.GetLength(0), 2];
        for (int i = 0; i < local.GetLength(0); i++)
        {
            scores2[i, 0] = local[i].user_id.ToString() + ":" + local[i].username;
            scores2[i, 1] = local[i].high_score.ToString();
        }

    }

    public void ShowScores()
    {
        Debug.Log("Called Show Scores");
        Debug.Log("Calling GetLBSScores()");

        GetLBScores(); // get scores before displaying
        Debug.Log("Finished Calling GetLBSscores()");
        
        //display scores onto TMP elements
        for (int i = 0; i < GlobalUsers.GetLength(0) && i < scores1.GetLength(0); i++)
        {
            GlobalUsers[i].text = scores1[i, 0];
            GlobalScores[i].text = scores1[i, 1];

        }

        for (int i = 0; i < FriendUsers.GetLength(0) && i < scores2.GetLength(0); i++)
        {
            FriendUsers[i].text = scores2[i, 0];
            FriendScores[i].text = scores2[i, 1];

        }

        //GlobalScores[0].SetText(scores.GetLength(0).ToString());
        //GlobalUsers[0].text = scores[0, 0];
        //GlobalScores[0].text = scores[0, 1];
        /*
        if (scores1.GetLength(0) < MaxScores)
        {
            for (int i = scores1.GetLength(0); i < MaxScores; i++)
            {
                GlobalUsers[i].text = "--";
                GlobalScores[i].text = "--";
            }
        }
        */
    }

    public void AddUser(TextMeshProUGUI u)
    {
        //send player username and leaderboard username to api
        string ThatUser = u.text; //The user being attempted to follow
        string ThisUser = PlayerPersist.getUser(); //The user making the follow request

        //ScoreHead.text = ThisUser; //for testing to show the users on screen
        //UserHead.text = ThatUser;
        Debug.Log("Current User: " + ThisUser);
        Debug.Log("User to Add: " + ThatUser.Split(":")[1] + " with user_id of " + ThatUser.Split(":")[0]);


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
