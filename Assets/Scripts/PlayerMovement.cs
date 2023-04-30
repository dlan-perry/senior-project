using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xInput, yInput;
    public int speed = 10;
    private bool isMoving;
    public float periodaoe = 6f;
    public float perioddir = 2f;
    public int aoe = 5;
    private string last;

    public SpriteRenderer spriteRenderer;
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    public GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        last = "s";
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
 
        isMoving = (xInput != 0 || yInput != 0);
 
        if (isMoving)
        {
            var moveVector = new Vector3(xInput , yInput, 0);   
            rb.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime), transform.position.y + moveVector.y * speed * Time.deltaTime));
            //Score.scorePoint += 1;
        }

        if(Input.GetKeyDown("a")) 
        {
            last = "a";
            spriteRenderer.sprite = left;
        }
        else if(Input.GetKeyDown("s"))
        {
            last = "s";
            spriteRenderer.sprite = front;
        }
        else if(Input.GetKeyDown("w"))
        {
            last = "w";
            spriteRenderer.sprite = back;
        }
        else if(Input.GetKeyDown("d"))
        {
            last = "d";
            spriteRenderer.sprite = right;
        }

        if(Input.GetKeyDown("a")) {last = "a";}
        else if(Input.GetKeyDown("s")){last = "s";}
        else if(Input.GetKeyDown("w")){last = "w";}
        else if(Input.GetKeyDown("d")){last = "d";}

        if(Input.GetKeyDown("i") && perioddir > 2)
        {
            objs = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject obj in objs)
            {
                switch(last)
                {
                    case "a":
                        Vector3 tmp = new Vector3(-2f, 0, 0);
                        tmp+=transform.position;
                        if(Vector3.Distance(tmp, obj.transform.position)< 2)
                        {
                            obj.GetComponent<EnemyStats>().damageEnemy(9f);
                        }
                        break;

                    case "s":
                        Vector3 tm = new Vector3(0, -2f, 0);
                        tm+=transform.position;
                        if(Vector3.Distance(tm, obj.transform.position)< 2)
                        {
                            obj.GetComponent<EnemyStats>().damageEnemy(9f);
                        }
                        break;
                    case "d":
                        Vector3 t = new Vector3(2f, 0, 0);
                        t+=transform.position;
                        if(Vector3.Distance(t, obj.transform.position)< 2)
                        {
                            obj.GetComponent<EnemyStats>().damageEnemy(9f);
                        }
                        break;
                    case "w":
                        Vector3 tmpp = new Vector3(0, 2f, 0);
                        tmpp+=transform.position;
                        if(Vector3.Distance(tmpp, obj.transform.position)< 2)
                        {
                            obj.GetComponent<EnemyStats>().damageEnemy(9f);
                        }
                        break;
                }
            }
            perioddir = 0;

        }




        if(Input.GetKeyDown("o")&& periodaoe > 6)
        {
            objs = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject obj in objs)
            {
                if(Vector3.Distance(transform.position, obj.transform.position) < aoe)
                {
                    obj.GetComponent<EnemyStats>().damageEnemy(5f);
                }

            }

            periodaoe = 0;
        }
        periodaoe += UnityEngine.Time.deltaTime;
        perioddir += UnityEngine.Time.deltaTime;

    }


}
