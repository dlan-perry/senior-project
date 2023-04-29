using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToPlayer : MonoBehaviour
{
    public float speed = 0.5f;
    public float stopDistance = 4f;
    private GameObject player;

    private string enemyType;
    private string[] enemies = new [] {"pineapple", "apple", "orange"};

    public SpriteRenderer spriteRenderer;

    public Sprite apple_front;
    public Sprite apple_back;
    public Sprite apple_left;
    public Sprite apple_right;

    public Sprite pineapple_front;
    public Sprite pineapple_back;
    public Sprite pineapple_left;
    public Sprite pineapple_right;

    public Sprite orange_front;
    public Sprite orange_back;
    public Sprite orange_left;
    public Sprite orange_right;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("player");
        enemyType = enemies[UnityEngine.Random.Range(0, 3)];
        switch(enemyType)
        {
            case "pineapple":
                spriteRenderer.sprite = pineapple_front;
                break;
            case "apple":
                spriteRenderer.sprite = apple_front;
                break;
            case "orange":
                spriteRenderer.sprite = orange_front;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x_away = player.transform.position.x - transform.position.x;
        float y_away = player.transform.position.y - transform.position.y;

        if(Vector2.Distance(transform.position, player.transform.position) <= stopDistance) return;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        if(y_away <= 0.0f && Math.Abs(x_away) <= Math.Abs(y_away))
        {
            switch(enemyType)
            {
            case "pineapple":
                spriteRenderer.sprite = pineapple_front;
                break;
            case "apple":
                spriteRenderer.sprite = apple_front;
                break;
            case "orange":
                spriteRenderer.sprite = orange_front;
                break;
            default:
                break;
            }
        }

        if(y_away > 0.0f && Math.Abs(x_away) <= Math.Abs(y_away))
        {
            switch(enemyType)
            {
            case "pineapple":
                spriteRenderer.sprite = pineapple_back;
                break;
            case "apple":
                spriteRenderer.sprite = apple_back;
                break;
            case "orange":
                spriteRenderer.sprite = orange_back;
                break;
            default:
                break;
            }
        }

        if(x_away <= 0.0f && Math.Abs(y_away) <= Math.Abs(x_away) )
        {
            switch(enemyType)
            {
            case "pineapple":
                spriteRenderer.sprite = pineapple_left;
                break;
            case "apple":
                spriteRenderer.sprite = apple_left;
                break;
            case "orange":
                spriteRenderer.sprite = orange_left;
                break;
            default:
                break;
            }
        }

        if(x_away > 0.0f && Math.Abs(y_away) <= Math.Abs(x_away))
        {
            switch(enemyType)
            {
            case "pineapple":
                spriteRenderer.sprite = pineapple_right;
                break;
            case "apple":
                spriteRenderer.sprite = apple_right;
                break;
            case "orange":
                spriteRenderer.sprite = orange_right;
                break;
            default:
                break;
            }
        }

    }
}
