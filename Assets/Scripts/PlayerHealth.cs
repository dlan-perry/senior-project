using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{   
    private const float maxHealth = 100f;
    public float health = maxHealth;
    private Image HealthBar;
    public float period = 12f;
    string user, token; //pull user and token from persistant variables
    public TextMeshProUGUI DeathScore; //to show on death
    public GameObject DeathCanvas, InGameScore;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        user = PlayerPersist.getUser();
        token = PlayerPersist.getToken(); //populate from persiatant at start
        DeathCanvas.SetActive(false);
        InGameScore.SetActive(true);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("p") && period > 12)
        {
            health+=10;
            if(health>100)
                health = 100;
            period = 0;
        }

        HealthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            // show lose screen
            // send score
            // reset score
            if (!dead)
            {
                PlayerPersist.setScore(Score.scorePoint);
                DeathScore.text = "Score: " + PlayerPersist.getScore().ToString();
                DeathCanvas.SetActive(true);
                InGameScore.SetActive(false);
                dead = true;
            }
            
            //SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
        }

        period += UnityEngine.Time.deltaTime;
        
    }

    public float getHealth()
    {
        return health;
    }

    public void changeHealth(float damage)
    {
        if(health >= damage)
            health=health-damage;
    }
}
