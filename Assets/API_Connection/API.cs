using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;

public class API : MonoBehaviour
{

    public static Bearer bearer;
    public bool isLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("API Test Start");

        getLeaderboard(2);
    }


    public static bool followUser(int user_id, int follow_id)
    {
        string data = "{ \"user_id\": " + user_id + ",\"follow_id\": " + follow_id + " }";
        UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:8000/follow", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
        request.SetRequestHeader("Content-Type", "application/json");
        Debug.Log(API.bearer.access_token);
        request.SetRequestHeader("Authorization", "Bearer " + API.bearer.access_token);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        request.SendWebRequest();



        if (request.result != UnityWebRequest.Result.Success)
        {
            return false;
        }
        else
        {
            return true;
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

    public static User getUserByToken(string token)
    {



        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/user/me");
        request.Headers.Add("Authorization", "Bearer " + API.bearer.access_token);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        Debug.Log("JSON IS ->" + json);
        return JsonUtility.FromJson<User>(json);
    }


    public static bool registerUser(string username, string password)
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
            return false;
        }
        else
        {
            return true;
        }
    }

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

    public static void score(int score)
    {

        string json = "{ \"score\": " + score + " }";
        UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:8000/score");
        
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer " + API.bearer.access_token);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);


        www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log("Score Error");
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    public void login(string username, string password)
    {
        Debug.Log("getting the request");
        StartCoroutine(postRequest(username, password));
    }

    private IEnumerator WaitingForJson()
    {
            yield return new WaitForSeconds(10000f);
    }

    public IEnumerator postRequest(string username, string password)
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
            API.bearer = JsonUtility.FromJson<Bearer>(uwr.downloadHandler.text);
            PlayerPersist.setToken(API.bearer.access_token);
            isLoaded = true;
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b")){
            API.followUser(2, 3);
        }
    }
}
