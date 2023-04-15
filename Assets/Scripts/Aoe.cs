using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aoe : MonoBehaviour
{
    private GameObject player;
    public Sprite aoe;
    public float done = 0.0f;
    public float current = 0.0f;
    
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            current = done;
            transform.position = player.transform.position;
            spriteRenderer.sprite = aoe;
        }

        if(current+.25 <= done)
        {
            spriteRenderer.sprite = null;
        } 

        done += UnityEngine.Time.deltaTime;

    }

}
