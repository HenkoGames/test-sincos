using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageHandler : MonoBehaviour
{
    private Text errorText;
    private string lastMessage = "";

    private void Awake()
    {
        try
        {
            errorText = GetComponent<Text>();
        }
        catch 
        {
            Debug.Log("ErrorMessageHandler component must have Text component in the same object");
            gameObject.SetActive(false);
        }

        Hide();
    }

    public void Show(string message)
    {
        errorText.text = message;
    }
    public string Show()
    {
        errorText.text = lastMessage;
        return lastMessage;
    }

    public void Hide()
    {
        lastMessage = errorText.text;
        errorText.text = "";
    }
}
