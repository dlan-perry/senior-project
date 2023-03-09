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
        nameText.text = API_Helper.GetUser().username;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
