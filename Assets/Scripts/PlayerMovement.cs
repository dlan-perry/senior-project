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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
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

        if(Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("w"))
        {
            Score.scorePoint += 1;
        }

    }

}
