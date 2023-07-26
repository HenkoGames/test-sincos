using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterValidation : MonoBehaviour
{
    public bool isValid = false;

    public RegistrationHandler handler;

    public void CheckInHandler() 
    {
        handler.StateChange();
    }
}
