using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
public static class API_Helper
{

    public static User GetUser()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/users/2");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();


        return JsonUtility.FromJson<User>(json);


    }
}
