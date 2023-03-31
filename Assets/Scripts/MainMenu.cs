using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public static class PlayerPersist
{
    static string user = "";
    static string token = "";
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
            user = u;
            
            return "Success";
        }
        //send info to backend
        //validate?
        //if good, go to main menu
    }

    public static string getUser()
    {
        return user;
    }

    public static string getToken()
    {
        return token;
    }

    public static void setUser(string u)
    {
        user = u;
    } 

    public static void setToken(string t)
    {
        token = t;
    }
}

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private GameObject score;
    public TMP_InputField username, password;
    //public string userString = "-_-";
    public TMP_Text errorBox, userBox;
    string user, token;

    void Start()
    {
        Time.timeScale = 1;
        //LeaderboardtoMainMenu(); //testing
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //don't do this
        user = PlayerPersist.getUser();
        token = PlayerPersist.getToken();
        userBox.text = user;
    }

    public void Login()
    {
        string response;
        response = PlayerPersist.LoginAttempt(username.text, password.text);

        if (response == "Success")
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            errorBox.text = response;
        }
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
}
