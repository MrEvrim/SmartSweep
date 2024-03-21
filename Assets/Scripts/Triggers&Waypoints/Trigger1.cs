using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Trigger1 : MonoBehaviour
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
        Waypoint1 waypoint2 = cam.GetComponent<Waypoint1>();
        waypoint2.enabled = false;

        Waypoint2 waypoint3 = cam.GetComponent<Waypoint2>();
        waypoint3.enabled = true;

        gorevTxt.text = "Son vatandaşı kurtar";

        Destroy(objectToDestroy);

        Destroy(gameObject);
    }
}
