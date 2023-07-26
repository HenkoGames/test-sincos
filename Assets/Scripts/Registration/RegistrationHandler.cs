using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RegistrationHandler : MonoBehaviour
{
    public RegisterValidation[] Field;

    public Button buttonNext;

    public int stage = 1;

    public Text connectText;
    private void Awake()
    {
        buttonNext.onClick.AddListener(Next);
        buttonNext.interactable = false;

        foreach(RegisterValidation f in Field)
        {
            f.handler = this;
        }
    }
    public void Next()
    {
        if(stage == 1)
        {
            stage = 2;
            buttonNext.interactable = false;
            Field[0].gameObject.SetActive(false);
            Field[1].gameObject.SetActive(false);
            Field[2].gameObject.SetActive(true);
            Field[3].gameObject.SetActive(true);
        }
        else if(stage == 2)
        {
            Connect();
        }
    }
    public void StateChange()
    {
        if(stage == 1)
        {
            if(CheckField(0) && CheckField(1))
            {
                buttonNext.interactable = true;
            }
            else
            {
                buttonNext.interactable = false;
            }
        }
        else if (stage == 2)
        {
            if (CheckField(2) && CheckField(3))
            {
                buttonNext.interactable = true;
            }
            else
            {
                buttonNext.interactable = false;
            }
        }
    }

    public bool CheckField(int number)
    {
        if (Field[number].isValid) return true;
        else return false;
    }
    
    public void Connect()
    {
        Field[2].gameObject.SetActive(false);
        Field[3].gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(false);
        StartCoroutine(ConnectionCor());
    }

    IEnumerator ConnectionCor()
    {
        float time = Random.Range(3f,5f);
        connectText.gameObject.SetActive (true);
        connectText.text = "Connecting...";
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Congrats");
        SceneManager.UnloadSceneAsync("Start");
    }
}
