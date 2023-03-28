using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int scorePoint = 0;
    public Text scoreText;
    public User dylan = null;
    //public bool inGame = true;
    //public float pointIncreasedPerSecond = 1f;
    public float period = 0.1f;

    public void Update()
    {
        

        scoreText.text = "Score: " + scorePoint.ToString();
        
        if(period > 5)
        {
        //API_Helper.ScoreUser(2, scorePoint);
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
        
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
