using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public static class PlayerPersist
{
    static string user = "";
    static string token = "";
    static int score = 0;
    static int user_id = 0;
    
    //public TMP_InputField username, password;
    //public TMP_Text errorBox;

    public static string LoginAttempt(string u, string p)
    {

        //check if boxes are populated
        if (u == "" || p == "")
        {
            return "Please enter Username and Password.";
        }
        else
        {
            Debug.Log("calling the login function");
            
            return "Success";
        }
        //send info to backend
        //validate?
        //if good, go to main menu
    }

    public static string getUser()
    {
        if (user != null){
            return user;
        }
        else
        {
            return "NULL";
        }
    }

    public static int getID(){
        return user_id;
    }

    public static string getToken()
    {
        return token;
    }

    public static int getScore()
    {
        return score;
    }

    public static void setUser(string u)
    {
        user = u;
    } 

    public static void setToken(string t)
    {
        token = t;
    }

    public static void setScore(int s)
    {
        API.score(s);
        score = s;
    }

    public static void setData(User u) {
        PlayerPersist.user = u.username;
        PlayerPersist.user_id = u.user_id;
    }
}

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private GameObject score;
    public TMP_InputField username, password;
    //public string userString = "-_-";
    public TMP_Text errorBox, userBox;
    string user, token;
    API api;

    void Start()
    {
        api = new API();
        Time.timeScale = 1;
        //LeaderboardtoMainMenu(); //testing
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //don't do this
        user = PlayerPersist.getUser();
        token = PlayerPersist.getToken();
        if (userBox != null)
        {
            userBox.text = user;
        }
    }

    public void Login()
    {
        Debug.Log("called the login");

        string response;
        //response = PlayerPersist.LoginAttempt(username.text, password.text);
        StartCoroutine(api.postRequest(username.text, password.text));
        Debug.Log("called the login");
        StartCoroutine(waitForResponse());
        if (API.bearer != null)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            User u = API.getUserByToken(PlayerPersist.getToken());
            PlayerPersist.setData(u);
            Debug.Log("From userdata, the user's  name is " + u.username);

            Debug.Log("The user's  name is " + PlayerPersist.getUser());
            userBox.text = "TESTTESTTEST";
        }
        else
        {
            errorBox.text = "Error when logging in";
        }
    }

    public void Register()
    {
        Debug.Log("called the register");
        API.registerUser(username.text, password.text);
    }

    IEnumerator waitForResponse()
    {
        Debug.Log("Waiting for bearer token to be received");
        yield return new WaitForSeconds(10f);
        yield return new WaitForSeconds(10f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single); //Loads Game scene
        //score.ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit(); //quit button
    }

    public void ToLogin()
    {
        SceneManager.LoadScene("Login", LoadSceneMode.Single); //Reload login screen
    }

    public void MainMenutoLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single); //single was giving problems, trying additive
    }

    public void LeaderboardtoMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //also trying additive
    }

    public void ToRegister()
    {
        SceneManager.LoadScene("Register", LoadSceneMode.Single); //Reload register screen
    }
}
