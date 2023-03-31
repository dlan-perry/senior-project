using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;
using System.IO;
public static class API_Helper
{

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
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("username=" + username + "&password=" + password + "&salt=none"));
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/users/", formData);
        www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    //put 0 if you want just the top 10, or the user_id if you would like the top 10 of the following list
    public static List<string> getLeaderboard(int user_id) {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/scores/" + user_id.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();


        return JsonUtility.FromJson<List<string>>(json);
    }

    public static string login(string username, string password) {


        Hashtable param = new Hashtable();
        param.Add("username", username);
        param.Add("password", password);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/token/");

        string json = JsonUtility.ToJson(param);

        byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(json);


        request.Method = "POST";
        request.ContentType = "application/json; charset=UTF-8";
        request.Accept = "application/json";
        request.ContentLength = postBytes.Length;


        Stream requestStream = request.GetRequestStream();


        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string result;


        StreamReader reader = new StreamReader(response.GetResponseStream());

        string response_json = reader.ReadToEnd();


        return JsonUtility.FromJson<string>(response_json);

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
}

