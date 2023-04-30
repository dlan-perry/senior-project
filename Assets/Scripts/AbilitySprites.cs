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
    public Sprite directionalup;
    public Sprite directionaldown;
    public Sprite directionalleft;
    public Sprite directionalright;
    public float done = 0.0f;
    public float current = 0.0f;
    private string last;
    public float periodaoe = 6f;
    public float perioddir = 2f;
    public float periodheal = 12f;

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

        if(Input.GetKeyDown("o")&& periodaoe > 6)
        {
            current = done;
            transform.position = player.transform.position;
            spriteRenderer.sprite = aoe;
            periodaoe = 0;
        }

        if(Input.GetKeyDown("p")&& periodheal > 12)
        {
            current = done;
            transform.position = player.transform.position;
            spriteRenderer.sprite = heal;
            periodheal = 0;
        }

        if(Input.GetKeyDown("i")&& perioddir > 2)
        {
            Vector3 tmp = player.transform.position;
            current = done;
            switch(last){
                case "w":
                    tmp.y += 1f;
                    transform.position = tmp;
                    spriteRenderer.sprite = directionalup;
                    break;
                case "a":
                    tmp.x -= 1f;
                    transform.position = tmp;
                    spriteRenderer.sprite = directionalleft;
                    break;
                case "s":
                    tmp.y -= 1f;
                    transform.position = tmp;
                    spriteRenderer.sprite = directionaldown;
                    break;
                case "d":
                    tmp.x += 1f;
                    transform.position = tmp;
                    spriteRenderer.sprite = directionalright;
                    break;
                default:
                    break;
            }
            perioddir = 0;
        }

        if(current+.12 <= done)
        {
            spriteRenderer.sprite = null;
        } 

        done += UnityEngine.Time.deltaTime;
        periodaoe += UnityEngine.Time.deltaTime;
        perioddir += UnityEngine.Time.deltaTime;
        periodheal += UnityEngine.Time.deltaTime;

    }

}