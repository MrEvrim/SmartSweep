using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleColliderHandler : MonoBehaviour
{
    public GameObject teleportDestination; // Teleport hedefi boş GameObject referansı
    public GameObject toggObject; // Togg objesi 
    public TMP_Text gorevTxt;
    public Camera mainCamera; // Ana kamera referansı
    public Image someImage; // Etkinleştirilecek image referansı

    private void Start()
    {
        // Ana kamerayı başlangıçta kapalı yap
        if (mainCamera != null)
            mainCamera.enabled = false;

        // Image'i başlangıçta etkinleştir
        if (someImage != null)
            someImage.gameObject.SetActive(true);


        gorevTxt.text = "Togg'u kontrol etmek için araça bağlan.";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DieSon"))
        {
            mainCamera.GetComponent<Waypoint>().enabled = true;


            other.transform.position = teleportDestination.transform.position;
            other.transform.rotation = teleportDestination.transform.rotation;

            BoxCollider boxCollider = other.GetComponent<BoxCollider>();
            boxCollider.enabled = false;

            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            MoveSon moveScript = other.GetComponent<MoveSon>();
            moveScript.enabled = false;

            other.transform.parent = toggObject.transform;

            ToggContoroller toggController = toggObject.GetComponent<ToggContoroller>();
            toggController.enabled = true;


            GameObject firstShotCamera = GameObject.Find("FirstShot");
            Destroy(firstShotCamera);

            mainCamera.enabled = true;

            gorevTxt.text = "*3* vatandaşı kurtar";

            Destroy(gameObject);
        }
    }
}