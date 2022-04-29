using System;
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

    [SerializeField]
    Text textErrorCredentials;

    [SerializeField]
    Text textErrorNoEmail;

    [SerializeField]
    GameObject propertiesPage1;

    [SerializeField]
    Animator dataVisualizationLayer;

    [SerializeField]
    List<GameObject> areaButtons;

    Hashtable umidadeAr = new Hashtable();
    Hashtable umidadeSolo = new Hashtable();
    Hashtable mmChovidos = new Hashtable();

    [SerializeField]
    Text umAr, umSolo, mmCho;

    [SerializeField]
    GameObject dataVisu, details;

    [SerializeField]
    Text detailUmAr, detailUmSolo, detailMmCho, hintUmAr, hintUmSolo, hintMmCho;

    [SerializeField]
    Transform buttonDetail;

    // Start is called before the first frame update
    void Awake()
    {
        emailPassword.Add("pedro@gmail.com", "123");
        emailUsername.Add("pedro@gmail.com", "Pedro");

        emailPassword.Add("bruno@gmail.com", "123");
        emailUsername.Add("bruno@gmail.com", "Bruno");

        emailPassword.Add("mauricio@gmail.com", "123");
        emailUsername.Add("mauricio@gmail.com", "Maurício");

        umidadeAr.Add("AreaButton", "90%");
        umidadeAr.Add("AreaButton(1)", "25%");
        umidadeAr.Add("AreaButton(2)", "46%");
        umidadeAr.Add("AreaButton(3)", "79%");
        umidadeAr.Add("AreaButton(4)", "12%");
        umidadeAr.Add("AreaButton(5)", "88%");
        umidadeAr.Add("AreaButton(6)", "54%");

        umidadeSolo.Add("AreaButton", "45%");
        umidadeSolo.Add("AreaButton(1)", "10%");
        umidadeSolo.Add("AreaButton(2)", "20%");
        umidadeSolo.Add("AreaButton(3)", "54%");
        umidadeSolo.Add("AreaButton(4)", "06%");
        umidadeSolo.Add("AreaButton(5)", "65%");
        umidadeSolo.Add("AreaButton(6)", "90%");

        mmChovidos.Add("AreaButton", "96 mm");
        mmChovidos.Add("AreaButton(1)", "12 mm");
        mmChovidos.Add("AreaButton(2)", "30 mm");
        mmChovidos.Add("AreaButton(3)", "76 mm");
        mmChovidos.Add("AreaButton(4)", "10 mm");
        mmChovidos.Add("AreaButton(5)", "107 mm");
        mmChovidos.Add("AreaButton(6)", "46 mm");



        regPage1.SetActive(true);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
        perfilPage1.SetActive(false);
        propertiesPage1.SetActive(false);
    }

    public void enter()
    {
        if(emailCredential.text == "" || emailCredential.text == null || passwordCredential.text == "" || passwordCredential.text == null)
        {
            textErrorCredentials.gameObject.SetActive(true);
        }
        else
        {
            textErrorCredentials.gameObject.SetActive(false);
            if (emailPassword.ContainsKey(emailCredential.text))
            {
                if ((string)emailPassword[emailCredential.text] == (string)passwordCredential.text)
                {
                    regPage1.SetActive(false);
                    regPage2.SetActive(false);
                    regPage3.SetActive(false);
                    EnterUserProperties((string)emailUsername[emailCredential.text]);
                }
                else
                {
                    textErrorCredentials.gameObject.SetActive(true);
                }
            }
            else
            {
                textErrorCredentials.gameObject.SetActive(true);
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
        if(emailForPasswordReset.text == "" || emailForPasswordReset == null)
        {
            textErrorNoEmail.gameObject.SetActive(true);
        }
        else
        {
            textErrorNoEmail.gameObject.SetActive(false);
            regPage1.SetActive(false);
            regPage2.SetActive(false);
            regPage3.SetActive(true);
        }
    }

    public void tryEnterAgain()
    {
        textErrorCredentials.gameObject.SetActive(false);
        regPage1.SetActive(true);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
    }

    public void EnterUserProperties(string username)
    {
        welcomeUsername.text = string.Concat(welcomeUsername.text, username);
        regPage1.SetActive(false);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
        propertiesPage1.SetActive(false);
        perfilPage1.SetActive(true);
    }

    public void BackUserProperties()
    {
        //welcomeUsername.text = string.Concat(welcomeUsername.text, username);
        regPage1.SetActive(false);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
        propertiesPage1.SetActive(false);
        perfilPage1.SetActive(true);
    }

    public void showAreaButton(GameObject areaButton)
    {
        foreach (GameObject go in areaButtons)
        {
            if (areaButton.Equals(go))
            {
                Debug.Log(go.name);
                if (areaButton.activeSelf)
                {
                    areaButton.SetActive(false);
                }
                else
                {
                    areaButton.SetActive(true);
                    umAr.text = (string)umidadeAr[go.name];
                    umSolo.text = (string)umidadeSolo[go.name];
                    mmCho.text = (string)mmChovidos[go.name];

                    detailUmAr.text = umAr.text;
                    detailUmSolo.text = umSolo.text;
                    detailMmCho.text = mmCho.text;

                    Hint(detailUmAr.text, detailUmSolo.text, detailMmCho.text);
                }
            }
            else
            {
                go.SetActive(false);
            }
        }
    }

    public void OpenOrClose()
    {
        int count = 0;
        foreach(GameObject go in areaButtons)
        {
            if(go.activeSelf == true)
            {
                count++;
                
            }
        }
        if (count > 0)
        {
            if (!dataVisualizationLayer.GetBool("Open"))
            {
                dataVisualizationLayer.SetBool("Open", true);

            }
        }
        else if(count == 0)
        {
            if (dataVisualizationLayer.GetBool("Open"))
            {
                dataVisualizationLayer.SetBool("Open", false);
            }
        }
        
    }

    public void ShowDetails()
    {
        if (!dataVisualizationLayer.GetBool("ShowDetails") && dataVisualizationLayer.GetBool("Open"))
        {
            dataVisualizationLayer.SetBool("ShowDetails", true);
            dataVisu.SetActive(false);
            details.SetActive(true);

            buttonDetail.Rotate(0.0f, 0.0f, 180.0f, Space.World);
        }
        else if (dataVisualizationLayer.GetBool("ShowDetails") && dataVisualizationLayer.GetBool("Open"))
        {
            dataVisualizationLayer.SetBool("ShowDetails", false);
            dataVisu.SetActive(true);
            details.SetActive(false);

            buttonDetail.Rotate(0.0f, 0.0f, 180.0f, Space.World);
        }
    }

    public void EnterProperty()
    {
        propertiesPage1.SetActive(true);
        perfilPage1.SetActive(false);
        regPage1.SetActive(false);
        regPage2.SetActive(false);
        regPage3.SetActive(false);
    }

    public void Hint(string hintAr, string hintSolo, string hintMm)
    {
        string castedHintAr = hintAr.Remove(hintAr.LastIndexOf('%')).TrimEnd();
        int intHintAr = Int16.Parse(castedHintAr);

        string castedHintSolo = hintSolo.Remove(hintSolo.LastIndexOf('%')).TrimEnd();
        int intHintSolo = Int16.Parse(castedHintSolo);

        string castedHintMm1 = hintMm.Remove(hintMm.LastIndexOf('m')).TrimEnd();
        string castedHintMm2 = castedHintMm1.Remove(castedHintMm1.LastIndexOf('m')).TrimEnd();
        int intHintMm = Int16.Parse(castedHintMm2);

        if (intHintAr < 50)
        {
            hintUmAr.text = "Ruim para Pulverização";
        }
        else
        {
            hintUmAr.text = "Boa para Pulverização";
        }

        if (intHintSolo < 50)
        {
            hintUmSolo.text = "Seca para Adubagem";
        }
        else
        {
            hintUmSolo.text = "Úmida para Adubagem";
        }

        if (intHintMm < 50)
        {
            hintMmCho.text = "Necessidade de Irrigar";
        }
        else
        {
            hintMmCho.text = "Sem Necessidade de Irrigar";
        }
    }
}
