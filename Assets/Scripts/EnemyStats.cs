using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 100f;
    public float damage = 0f;
    public float period = 0.1f;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
         if(period > .1)
        {
            health-=damage;
            SetColor(Color.white);
            
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    

    if(health <= 0)
    {
        Score.scorePoint += 1;
        Destroy(gameObject);
    }

    }

    public void damageEnemy(float d)
    {
        SetColor(new Color(1,1,1,0));
        health-=d;
    }

    private void SetColor(Color color)
    {
        material.SetColor("_Color", color);
    }
}
