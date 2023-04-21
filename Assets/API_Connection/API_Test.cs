using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class API_Test : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        //API_Helper.registerUser("Reginald", "Lesman");
        
        API_Helper.login("Dylan", "test");
        Debug.Log("in test");
        

    }



    // Update is called once per frame
    void Update()
    {

        scoreText.text = "hey reed";
    }
}
