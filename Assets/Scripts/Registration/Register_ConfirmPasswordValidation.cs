using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register_ConfirmPasswordValidation : RegisterValidation
{
    public InputField input;
    public ErrorMessageHandler error;

    public Register_NewPasswordValidation passwordOriginal;

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
        if (input.text != "")
        {
            if (input.text != passwordOriginal.input.text)
            {
                error.Show("Its different passwords!");
                return isValid = false;
            }
            error.Hide();
            return isValid = true;
        }
        error.Hide();
        return isValid = false;
    }
}
