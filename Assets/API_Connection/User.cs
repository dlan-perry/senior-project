using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class User
{
    public string username;
    public int user_id;
    public string password;
    public string salt;
    public string high_score;
    public string high_score_date;
}

[System.Serializable]
public class Leaderboard
{
    public UserScore[] scores;
}

[System.Serializable]
public class UserScore
{
    public string username;
    public int user_id;
    public int high_score;
}

[System.Serializable]
public class Bearer
{
    public string access_token;
}



