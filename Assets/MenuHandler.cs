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
        objectiveText.text = "Amaç: Baþlangýç katýndaki çöpleri topladýktan sonra yere düþen USB belleði al ve alt kata in. Anahtarý al ve dýþarý çýk.";
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
        objectiveText.text = "Amaç: Baþlangýç katýndaki çöpleri topladýktan sonra yere düþen USB belleði al ve alt kata in. Anahtarý al ve dýþarý çýk.";
        evButton.interactable = false;
        toggButton.interactable = true;
        droneButton.interactable = true;
        evPanel.SetActive(true);
        toggPanel.SetActive(false);
        dronePanel.SetActive(false);
    }
    public void TOGGBolumu()
    {
        objectiveText.text = "Amaç: Bir deprem olmak üzere! Acele et ve süre dolmadan insanlara ulaþýp toplanma alanýna yetiþ.";
        evButton.interactable = true;
        toggButton.interactable = false;
        droneButton.interactable = true;
        evPanel.SetActive(false);
        toggPanel.SetActive(true);
        dronePanel.SetActive(false);

    }
    public void DroneBolumu()
    {
        objectiveText.text = "Amaç: Evleri yýkýlan insanlara yardým kolilerini ulaþtýr.";
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
