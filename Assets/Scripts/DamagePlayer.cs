using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public PlayerHealth p;
    public float damage = 1f;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectsWithTag("health")[0].GetComponent<PlayerHealth>();
        //PlayerHealth p = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            p.changeHealth(damage);
        }
    }
}
