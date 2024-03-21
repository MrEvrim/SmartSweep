using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject cameraRotator;
    public GameObject lockedMenuItem;
    public GameObject mainMenuItem;
    public GameObject howToPlayPanel;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
