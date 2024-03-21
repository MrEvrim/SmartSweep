using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Trigger2 : MonoBehaviour
{
    // Bu değişken Unity arayüzünde atanacak objeyi tutar
    public GameObject objectToDestroy;
    public TMP_Text gorevTxt;
    public Camera cam;


    private void OnTriggerEnter(Collider other)
    {
        // Eğer tetikleyiciye belirli bir obje girerse
        if (other.gameObject.CompareTag("Togg"))
        {
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        Waypoint2 waypoint3 = cam.GetComponent<Waypoint2>();
        waypoint3.enabled = false;

        gorevTxt.text = "Aldığın 3 yolcuyu güvenli bölgeye bırak.";

        Waypoint3 waypoint4 = cam.GetComponent<Waypoint3>();
        waypoint4.enabled = true;

        Destroy(objectToDestroy);

        Destroy(gameObject);
    }
}