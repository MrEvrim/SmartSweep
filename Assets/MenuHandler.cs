using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuHandler : MonoBehaviour
{
    public GameObject cameraRotator;
    public GameObject lockedMenuItem;
    public GameObject mainMenuItem;
    public GameObject howToPlayPanel, evPanel, toggPanel, dronePanel;
    public Button evButton, toggButton, droneButton;
    public TMP_Text objectiveText;


    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = "Ama�: Ba�lang�� kat�ndaki ��pleri toplad�ktan sonra yere d��en USB belle�i al ve alt kata in. Anahtar� al ve d��ar� ��k.";
        evPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotator.transform.Rotate(0,-.1f,0);
    }
    public void ClickToContinue()
    {
        lockedMenuItem.SetActive(false);
        mainMenuItem.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Home");
    }
    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
        mainMenuItem.SetActive(false);

    }
    public void EvBolumu()
    {
        objectiveText.text = "Ama�: Ba�lang�� kat�ndaki ��pleri toplad�ktan sonra yere d��en USB belle�i al ve alt kata in. Anahtar� al ve d��ar� ��k.";
        evButton.interactable = false;
        toggButton.interactable = true;
        droneButton.interactable = true;
        evPanel.SetActive(true);
        toggPanel.SetActive(false);
        dronePanel.SetActive(false);
    }
    public void TOGGBolumu()
    {
        objectiveText.text = "Ama�: Bir deprem olmak �zere! Acele et ve s�re dolmadan insanlara ula��p toplanma alan�na yeti�.";
        evButton.interactable = true;
        toggButton.interactable = false;
        droneButton.interactable = true;
        evPanel.SetActive(false);
        toggPanel.SetActive(true);
        dronePanel.SetActive(false);

    }
    public void DroneBolumu()
    {
        objectiveText.text = "Ama�: Evleri y�k�lan insanlara yard�m kolilerini ula�t�r.";
        evButton.interactable = true;
        toggButton.interactable = true;
        droneButton.interactable = false;
        evPanel.SetActive(false);
        toggPanel.SetActive(false);
        dronePanel.SetActive(true);

    }
    public void GeriButton()
    {
        howToPlayPanel.SetActive(false);
        mainMenuItem.SetActive(true);
    }


}
