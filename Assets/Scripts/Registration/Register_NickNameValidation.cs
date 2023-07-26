using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Register_NickNameValidation : RegisterValidation
{
    public InputField input;
    public ErrorMessageHandler error;


    private void Awake()
    {
        try
        {
            input = GetComponent<InputField>();
        }
        catch 
        {
            Debug.Log("Register_NickNameValidation component must have InputField component in the same object");
            gameObject.SetActive(false);
        }

        input.onValueChanged.AddListener(delegate { ValueCheck(); CheckInHandler();});

    }

    bool ValueCheck()
    {
        foreach(char i in input.text)
        {
            if (!((i >= 'a' && i <= 'z') || (i >= 'A' && i <= 'Z')))
            {
                error.Show("All letters must be latin(a - z, A - Z)");
                return isValid = false;
            }

        }

        if(input.text.Length <= 2)
        {
            error.Show("Lenght must be more than 2 symbols");
            return isValid = false;
        }

        error.Hide();
        return isValid = true;
    }

}