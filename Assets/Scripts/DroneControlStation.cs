using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneControlStation : MonoBehaviour
{
    public GameObject Drone;
    public GameObject DieSon;
    public GameObject img;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DieSon"))
        {
            DieSon.GetComponent<MoveSon>().enabled = false;
            Drone.GetComponent<DroneCont>().enabled = true;

            GameObject mainCamera = DieSon.transform.Find("Camera").gameObject;
            if (mainCamera != null)
            {
                Destroy(mainCamera);
            }
            img.SetActive(true);
            Destroy(gameObject);
        }
    }
}
