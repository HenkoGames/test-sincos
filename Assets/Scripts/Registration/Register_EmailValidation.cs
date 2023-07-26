using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register_EmailValidation : RegisterValidation
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
            Debug.Log("Register_EmailValidation component must have InputField component in the same object");
            gameObject.SetActive(false);
        }

        input.onValueChanged.AddListener(delegate { ValueCheck(); CheckInHandler();});

    }

    public bool ValueCheck()
    {


        var trimmedEmail = input.text.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            error.Show("Enter valid email");
            return isValid = false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(input.text);
            if(addr.Address == trimmedEmail)
            {
                error.Hide();
                return isValid = true;
            }
        }
        catch
        {
            error.Show("Enter valid email");
            return isValid = false;
        }

        error.Show("Enter valid email");
        return isValid = false;
    }
}
