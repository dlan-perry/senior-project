using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbilitySprites : MonoBehaviour
{
    private GameObject player;
    public Sprite aoe;
    public Sprite heal;
    public Sprite directional;
    public float done = 0.0f;
    public float current = 0.0f;
    private string last;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        last = "";
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")) {last = "w";}
        if(Input.GetKeyDown("a")) {last = "a";}
        if(Input.GetKeyDown("s")) {last = "s";}
        if(Input.GetKeyDown("d")) {last = "d";}

        if(Input.GetKeyDown("o"))
        {
            current = done;
            transform.position = player.transform.position;
            spriteRenderer.sprite = aoe;
        }

        if(Input.GetKeyDown("p"))
        {
            current = done;
            transform.position = player.transform.position;
            spriteRenderer.sprite = heal;
        }

        if(Input.GetKeyDown("i"))
        {
            Vector3 tmp = player.transform.position;
            current = done;
            switch(last){
                case "w":
                    tmp.y += 1f;
                    transform.position = tmp;
                    //transform.position.x = player.transform.position.x;
                    //transform.position.y = player.transform.position.y + 1;
                    break;
                case "a":
                    tmp.x -= 1f;
                    transform.position = tmp;
                    //transform.position.x = player.transform.position.x - 1;
                    //transform.position.y = player.transform.position.y;
                    break;
                case "s":
                    tmp.y -= 1f;
                    transform.position = tmp;
                    //transform.position.x = player.transform.position.x - 1;
                    //transform.position.y = player.transform.position.y;
                    break;
                case "d":
                    tmp.x += 1f;
                    transform.position = tmp;
                    //transform.position.x = player.transform.position.x;
                    //transform.position.y = player.transform.position.y - 1;
                    break;
                default:
                    break;
            }
            spriteRenderer.sprite = directional;
        }

        if(current+.12 <= done)
        {
            spriteRenderer.sprite = null;
        } 

        done += UnityEngine.Time.deltaTime;

    }

}