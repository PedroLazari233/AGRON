using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject regPage1, regPage2, regPage3;

    [SerializeField]
    InputField emailCredential, passwordCredential;

    [SerializeField]
    InputField emailForPasswordReset;

    Hashtable emailPassword = new Hashtable();
    Hashtable emailUsername = new Hashtable();

    [SerializeField]
    GameObject perfilPage1;

    [SerializeField]
    Text welcomeUsername;

    // Start is called before the first frame update
    void Awake()
    {
        emailPassword.Add("pedro@gmail.com", "123");
        emailUsername.Add("pedro@gmail.com", "Pedro");

        emailPassword.Add("bruno@gmail.com", "123");
        emailUsername.Add("bruno@gmail.com", "Bruno");

        emailPassword.Add("mauricio@gmail.com", "123");
        emailUsername.Add("mauricio@gmail.com", "Maurício");

        regPage1.SetActive(true);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
        perfilPage1.SetActive(false);
    }

    public void enter()
    {
        if (emailPassword.ContainsKey(emailCredential.text))
        {
            if ((string)emailPassword[emailCredential.text] == (string)passwordCredential.text) {
                regPage1.SetActive(false);
                regPage2.SetActive(false);
                regPage3.SetActive(false);
                EnterUserProperties((string)emailUsername[emailCredential.text]);
            }
        }
        
    }

    public void forgotMyPassword()
    {
        regPage1.SetActive(false);
        regPage2.SetActive(true);
        regPage3.SetActive(false);
    }

    public void sendPassword()
    {
        if(emailForPasswordReset.text != "")
        {
            regPage1.SetActive(false);
            regPage2.SetActive(false);
            regPage3.SetActive(true);
        }        
    }

    public void tryEnterAgain()
    {
        regPage1.SetActive(true);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
    }

    public void EnterUserProperties(string username)
    {
        welcomeUsername.text = string.Concat(welcomeUsername.text, username);
        perfilPage1.SetActive(true);
    }
}
