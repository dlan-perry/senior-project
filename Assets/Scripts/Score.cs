using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Score : MonoBehaviour
{
    public static int scorePoint = 0;
    public Text scoreText;
    //public float pointIncreasedPerSecond = 1f;


    public void Update()
    {
        scoreText.text = "Score: " + scorePoint.ToString();
        //scorePoint += pointIncreasedPerSecond * Time.fixedDeltaTime;
    }

}
