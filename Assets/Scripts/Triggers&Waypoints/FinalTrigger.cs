using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{
    public GameObject toggObject;
    public TMP_Text gorevTxt;
    public GameObject alkıscilar;
    public TMP_Text timer;
    public GameObject panelObject;
    public float fadeDuration = 3f;
    public string nextSceneName = "CityDay"; // Name of the scene to load next

    private CanvasGroup panelCanvasGroup;
    private Image panelImage;

    private void Start()
    {
        panelCanvasGroup = panelObject.GetComponent<CanvasGroup>();
        panelCanvasGroup.alpha = 0f;

        panelImage = panelObject.GetComponentInChildren<Image>();
        Color tempColor = panelImage.color;
        tempColor.a = 0f;
        panelImage.color = tempColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Togg"))
        {
            timer.enabled = false;
            gorevTxt.text = "Tebrikler Sivillerin HAYATINI KURTARDIN !!!";

            toggObject.GetComponent<ToggContoroller>().enabled = false;
            toggObject.GetComponent<AudioSource>().enabled = false;

            alkıscilar.SetActive(true);

            StartCoroutine(FadeInPanel());
        }
    }

    IEnumerator FadeInPanel()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            panelCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            Color tempColor = panelImage.color;
            tempColor.a = panelCanvasGroup.alpha;
            panelImage.color = tempColor;

            yield return null;
        }

        panelCanvasGroup.alpha = 1f;
        Color finalColor = panelImage.color;
        finalColor.a = 1f;
        panelImage.color = finalColor;

        // Load the next scene after fade-in completes
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}