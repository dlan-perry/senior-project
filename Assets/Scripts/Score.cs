using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scorePoint = 0;
    //public Text scoreText;
    public TextMeshProUGUI scoreText;
    //public bool inGame = true;
    //public float pointIncreasedPerSecond = 1f;

    private void Start()
    {
        scorePoint = 0;
    }

    /*public void ResetScore()
    {
        scorePoint = 0;
    }*/

    public void Update()
    {
        scoreText.text = "Score: " + scorePoint.ToString();
        
        //scorePoint += pointIncreasedPerSecond * Time.fixedDeltaTime;


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //inGame = false;
            //MainMenu();
            Application.Quit(); //just quit on escape for now
            //SceneManager.LoadScene("Game", LoadSceneMode.Single); //quit back to main menu on escape
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single); //quit back to main menu on escape
    }
}
