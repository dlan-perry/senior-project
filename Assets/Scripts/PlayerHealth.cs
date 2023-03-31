using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    private const float maxHealth = 100f;
    public float health = maxHealth;
    private Image HealthBar;
    public float period = 12f;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
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
            SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
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
