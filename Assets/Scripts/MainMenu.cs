using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private GameObject score;

    void Start()
    {
        Time.timeScale = 1;
        //LeaderboardtoMainMenu(); //testing
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //don't do this
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

    public void MainMenutoLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single); //single was giving problems, trying additive
    }

    public void LeaderboardtoMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //also trying additive
    }
}
