using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginController : MonoBehaviour
{
    public TMP_InputField username, password;
    public string userString = "-_-";
    public TMP_Text userTMPText;

    // Start is called before the first frame update
    void Start()
    {
        //
        //DontDestroyOnLoad(transform.gameObject);
        //maybe don't ^
        userTMPText.text = userString;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void LoginButton()
    {
        //stuff to do when login is pressed
        userString = username.GetComponent<TMP_InputField>().text;
        userTMPText.text = username.GetComponent<TMP_InputField>().text;
        //DontDestroyOnLoad(transform.gameObject);
    }
}
