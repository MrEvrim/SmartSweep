using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class DeliveryConfirmation : MonoBehaviour
{
    public TMP_Text infobox;
    private int dagitilanBox=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
        {
            dagitilanBox++;
        }
    }
    private void Update()
    {
        infobox.text = $"Dağıtılan Erzak Kolisi = {dagitilanBox}";

        if (dagitilanBox == 2)
        {
            Debug.Log("bitsinnn artık");
        }
    }
}
