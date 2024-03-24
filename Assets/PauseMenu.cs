using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, howToPlayPanel, evPanel, toggPanel, dronePanel;
    public TMP_Text objectiveText;
    public Button evButton, toggButton, droneButton;
    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = "Amaç: Baþlangýç katýndaki çöpleri topladýktan sonra yere düþen USB belleði al ve alt kata in. Anahtarý al ve dýþarý çýk.";
        evPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!howToPlayPanel.activeSelf)
            {
                if(pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1.0f;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = .0f;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }
    public void HowToPlayPanelActivator()
    {
        howToPlayPanel.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GeriButton()
    {
        howToPlayPanel.SetActive(false);
        pauseMenu.SetActive(true);
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
}
