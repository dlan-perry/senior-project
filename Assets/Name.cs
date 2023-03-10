using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
public class Name : MonoBehaviour
{

    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        User dylan = API_Helper.GetUser();
        nameText.text = "User_ID : " + dylan.user_id;
        nameText.text += "\n" + "Username : " + dylan.username;

        nameText.text += "\n" + "Password : " + dylan.password;
        nameText.text += "\n" + "Salt : " + dylan.salt;
        nameText.text += "\n" + "High Score : " + dylan.high_score;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
