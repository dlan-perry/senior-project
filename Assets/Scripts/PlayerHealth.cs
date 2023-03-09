using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   
    private const float maxHealth = 100f;
    public float health = maxHealth;
    private Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = health / maxHealth;    
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
