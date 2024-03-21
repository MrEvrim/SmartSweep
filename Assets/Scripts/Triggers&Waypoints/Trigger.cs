using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Trigger : MonoBehaviour
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
        Waypoint waypoint1 = cam.GetComponent<Waypoint>();
        waypoint1.enabled = false;



        gorevTxt.text = "*2* vatandaşı kurtar";

        Waypoint1 waypoint2 = cam.GetComponent<Waypoint1>();
        waypoint2.enabled = true;

        Destroy(objectToDestroy);

        Destroy(gameObject);
    }
}