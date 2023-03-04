using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public float damage = 1f;
    public float period = 0.1f;
    public PlayerHealth p;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth p = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(period > .1 && p != null)
        {
            p.changeHealth(damage);
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }
}
