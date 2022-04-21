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

    Hashtable cred = new Hashtable();

    // Start is called before the first frame update
    void Awake()
    {
        cred.Add("pedro@gmail.com", "123");

        regPage1.SetActive(true);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
    }

    public void enter()
    {
        if (cred.ContainsKey(emailCredential.text))
        {
            if ((string)cred[emailCredential.text] == (string)passwordCredential.text) {
                regPage1.SetActive(false);
                regPage2.SetActive(false);
                regPage3.SetActive(false);
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
}
