using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register_NewPasswordValidation : RegisterValidation
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
            Debug.Log("Register_ConfirmPasswordValidation component must have InputField component in the same object");
            gameObject.SetActive(false);
        }

        input.onValueChanged.AddListener(delegate { ValueCheck(); CheckInHandler(); });

    }

    public bool ValueCheck()
    {
        bool haveUpper = false;
        bool haveNumber = false;
        if(input.text == "")
        {
            error.Hide();
            return isValid = false;
        }

        foreach(char c in input.text)
        {
            if(char.IsUpper(c)) haveUpper = true;   
            if(char.IsNumber(c)) haveNumber = true;

            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || char.IsNumber(c)))
            {
                error.Show("All letters must be latin or numbers(a - z, A - Z, 0-9)");
                return isValid = false;
            }
            
        }

        if(input.text.Length < 8) 
        {
            error.Show("Lenght must be more than 8 symbols");
            return isValid = false;
        }

        if (!haveNumber)
        {
            error.Show("Password must have at least one number");
            return isValid = false;
        }

        if (!haveUpper)
        {
            error.Show("Password must have at least one upper symbol");
            return isValid = false;
        }

        error.Hide();
        return isValid = true;
    }
}
