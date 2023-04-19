using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;


public static class API_Helper
{

    public static string token = "";



    public static void followUser(int user_id, int follow_id)
    {
        string data = "{ \"user_id\": " + user_id + ",\"follow_id\": " + follow_id + " }";
        var request = new UnityWebRequest("http://127.0.0.1:8000/follow", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();



        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }


    public static User GetUser(int user_id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/users/" + user_id.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();


        return JsonUtility.FromJson<User>(json);


    }

    public static void registerUser(string username, string password)
    {

        string data = "{\"username\": \"" + username + "\",\"password\":\"" + password + "\",\"salt\": \"\"}";
        var request = new UnityWebRequest("http://127.0.0.1:8000/users/", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("BAAAAD");
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    //put 0 if you want just the top 10, or the user_id if you would like the top 10 of the following list
    public static Leaderboard getLeaderboard(int user_id)
    {
        HttpWebRequest request = null;
        if (user_id != 0)
        {
            request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/scores/" + user_id.ToString());
        }
        else
        {
            request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/scores/");

        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();
        Debug.Log(json);
        return JsonUtility.FromJson<Leaderboard>(json);
    }

    public static string login(string username, string password)
    {
        return "bruh";
    }


    public static string score(int score, string token)
    {
        string json = "{ score: " + score + " }";
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/score", json);
        www.SetRequestHeader("Authorization", "Bearer: " + token);
        www.SetRequestHeader("Content-Type", "application/json");

        www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            return null;
        }
        else
        {
            Debug.Log("Form upload complete!");
            return "token";
        }
    }


    public static IEnumerator postRequest(string username, string password)
    {
        Debug.Log("called this method");
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest uwr = UnityWebRequest.Post("http://127.0.0.1:8000/token", form);

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            
        }
    }
}


