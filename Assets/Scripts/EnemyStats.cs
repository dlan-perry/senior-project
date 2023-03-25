using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 100f;
    public float damage = 1f;
    public float period = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         if(period > .1)
        {
            health-=damage;
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    

    if(health <= 0)
    {
        Destroy(gameObject);
    }

    }
}
