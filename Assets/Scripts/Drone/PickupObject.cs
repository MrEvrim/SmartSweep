using System.Collections;
using UnityEngine;
using TMPro;

public class PickupObject : MonoBehaviour
{
    public Transform pickupDestination;
    public TMP_Text bilgiTxt;

    private GameObject currentPickup;
    private bool canDrop = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentPickup != null && !canDrop)
            {
                StartCoroutine(DropObjectRoutine());
                bilgiTxt.text = "";
            }
        }

        if (canDrop && currentPickup != null)
        {
            DropObject();
        }
    }

    IEnumerator DropObjectRoutine()
    {
        canDrop = true;
        yield return new WaitForSeconds(3);
        canDrop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickupable") && currentPickup == null)
        {
            // Objeyi al
            PickupObjectMethod(other.gameObject);
            bilgiTxt.text = "Gıda Kolisini bırakmak için 'R'ye bas.";
        }
    }

    private void PickupObjectMethod(GameObject pickup)
    {
        // Şu anki taşınan objeyi pickle
        currentPickup = pickup;
        currentPickup.transform.SetParent(pickupDestination);
        currentPickup.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void DropObject()
    {
        // Eğer bir şey taşıyorsa
        currentPickup.GetComponent<Rigidbody>().isKinematic = false;
        currentPickup.transform.SetParent(null);
        currentPickup = null;
        bilgiTxt.text = "Erzak Kolisini almak için kolinin üstüne gel";
    }
}