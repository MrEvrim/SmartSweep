using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG;
using DG.Tweening;
using UnityEngine.UI;

public class GarbageCollecting : MonoBehaviour
{
    public float totalGarbageCount, collectedGarbageCount;
    public Slider temizlikBar;
    public GameObject garbageGroupGameObject, dieSon, landingPoint, outsideCheckpoint;
    public Camera fallDownCutsceneCamera;
    public Transform waypointLocations;
    public AudioSource audioSourceVacuumSound, audioSourceFallingSound;
    public AudioClip vacuumingSound1, vacuumingSoundLoop, fallingSound, screamSound;
    private void Start()
    {
        totalGarbageCount = garbageGroupGameObject.transform.childCount;
        temizlikBar.maxValue = totalGarbageCount;
        VacuumSound();
    }
    private void Update()
    {
        if (collectedGarbageCount / totalGarbageCount <= .33f)
        {
            temizlikBar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (collectedGarbageCount / totalGarbageCount >= .33f && collectedGarbageCount / totalGarbageCount <= .66f)
        {
            temizlikBar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            temizlikBar.fillRect.GetComponent<Image>().color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Garbage"))
        {
            other.transform.DOMove(transform.position, 2f, false);
            StartCoroutine(DestroyGarbage());
        }
        IEnumerator DestroyGarbage()
        {
            yield return new WaitForSeconds(0.5f);
            collectedGarbageCount++;
            temizlikBar.value = collectedGarbageCount;
            Destroy(other.gameObject);
        }
        if(other.name == "FlashDrive")
        {
            StartCoroutine(GameObject.Find("TaskMaster_Ev").GetComponent<TaskMaster_Ev>().FlashDriveSequence());

        }
        if(other.name == "FallingSoundTriggerZone")
        {
            FallingSoundAndScream();
        }
        if(other.name == "Key")
        {
            outsideCheckpoint.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    void VacuumSound()
    {
        audioSourceVacuumSound.PlayOneShot(vacuumingSound1);
        audioSourceVacuumSound.clip = vacuumingSoundLoop;
        audioSourceVacuumSound.PlayDelayed(vacuumingSound1.length-0.1f);
    }
    void FallingSoundAndScream()
    {
        audioSourceFallingSound.PlayOneShot(fallingSound);
        audioSourceFallingSound.clip = screamSound;
        audioSourceFallingSound.PlayDelayed(fallingSound.length + 1f);
    }
}