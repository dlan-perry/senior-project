using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabInputLogin: MonoBehaviour
{
    public TMP_InputField UsernameInput; //0
    public TMP_InputField PasswordInput; //1
    public int InputSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            InputSelected--;
            if (InputSelected < 0)
            {
                InputSelected = 1;
            }
            SelectInputField();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 1)
            {
                InputSelected = 0;
            }
            SelectInputField();
        }

        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0: UsernameInput.Select();
                    break;
                case 1: PasswordInput.Select();
                    break;
                //case 2: LoginButton.Select();
                    //break;
            }
        }
    }

    public void UsernameSelected() => InputSelected = 0;
    public void PasswordSelected() => InputSelected = 1;
    //public void LoginSelected() => InputSelected = 2;
}
