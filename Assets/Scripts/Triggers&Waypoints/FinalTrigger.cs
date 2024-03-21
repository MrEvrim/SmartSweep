using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{
    public GameObject toggObject;
    public TMP_Text gorevTxt;
    public GameObject alkıscilar;
    public TMP_Text timer;
    public GameObject panelObject; // Canvas içindeki panel objesi
    public float fadeDuration = 3f; // Saydamlığın azalma süresi (saniye)

    private CanvasGroup panelCanvasGroup; // Panelin CanvasGroup bileşeni
    private Image panelImage; // Panel içindeki Image bileşeni

    private void Start()
    {
        // Panelin CanvasGroup bileşenini al
        panelCanvasGroup = panelObject.GetComponent<CanvasGroup>();
        // Panelin saydamlığını başlangıçta 0 yaparak gizle
        panelCanvasGroup.alpha = 0f;

        // Panel içindeki Image bileşenini al
        panelImage = panelObject.GetComponentInChildren<Image>();
        // Panelin içindeki Image bileşeninin saydamlığını da başlangıçta 0 yaparak gizle
        Color tempColor = panelImage.color;
        tempColor.a = 0f;
        panelImage.color = tempColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Togg"))
        {
            // Timer'ı ve gorevTxt'yi devre dışı bırak
            timer.enabled = false;
            gorevTxt.text = "Tebrikler Sivillerin HAYATINI KURTARDIN !!!";

            // Togg objesinin ToggContoroller ve AudioSource bileşenlerini devre dışı bırak
            toggObject.GetComponent<ToggContoroller>().enabled = false;
            toggObject.GetComponent<AudioSource>().enabled = false;

            // Alkıscıları etkinleştir
            alkıscilar.SetActive(true);

            // Panelin saydamlığını azaltarak görünür hale getir
            StartCoroutine(FadeInPanel());
        }
    }

    IEnumerator FadeInPanel()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Zamanı güncelle
            elapsedTime += Time.deltaTime;

            // Panelin saydamlığını azalt
            panelCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Panel içindeki Image bileşeninin saydamlığını güncelle
            Color tempColor = panelImage.color;
            tempColor.a = panelCanvasGroup.alpha;
            panelImage.color = tempColor;

            yield return null;
        }
        // Panel tamamen görünür hale geldiğinde işlemi bitir
        panelCanvasGroup.alpha = 1f;
        Color finalColor = panelImage.color;
        finalColor.a = 1f;
        panelImage.color = finalColor;
    }
}