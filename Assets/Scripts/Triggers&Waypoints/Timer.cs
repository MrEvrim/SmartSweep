using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerTxt;
    public TMP_Text gorevTxt;
    public GameObject togg;
    //Toplam geri sayım süresi (2.5 dakika)
    private float remainingTime = 240f;

    void Update()
    {
      
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        timerTxt.text = $"Depreme Kalan Süre : {string.Format("{0:00}:{1:00}", minutes, seconds)}";

        if (remainingTime <= 120f)
            timerTxt.color = Color.yellow; 

        if (remainingTime <= 60f)
            timerTxt.color = Color.red; 
        //Eğer süre biterse
        if (remainingTime == 0)
        {
            gorevTxt.text = "Başaramadın Tekrar Dene. Tekrar denemek için ''R'' TUŞUNA BAS!";
            gorevTxt.color = Color.red;
            togg.GetComponent<ToggContoroller>().enabled = false;
            remainingTime += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        }

    }
    private void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}