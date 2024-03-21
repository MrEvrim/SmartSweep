using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class TaskMaster_Ev : MonoBehaviour
{
    public GarbageCollecting garbageCollecting;
    public TMP_Text gorevText;
    public GameObject flashDisk, dieSon, landingPoint, dontFallCollider;
    public CinemachineVirtualCamera flashDiskCamera;
    public Camera fallDownCutsceneCamera;
    public Transform waypointLocations;
    public Camera freeLookCamera;

    private bool flashDiskCutscenePlayed = false;
    private bool flashDriveSequencePlayed = false;

    void Update()
    {
        if (!flashDiskCutscenePlayed && garbageCollecting.totalGarbageCount - garbageCollecting.collectedGarbageCount == 0)
        {
            StartCoroutine(FlashDiskCutscene());
            flashDiskCutscenePlayed = true;
        }
        if (!flashDriveSequencePlayed && flashDisk.activeSelf == false)
        {
            StartCoroutine(FlashDriveSequence());
            flashDriveSequencePlayed = true;
        }
    }

    IEnumerator FlashDiskCutscene()
    {
        flashDiskCamera.enabled = true;
        flashDisk.transform.DOJump(new Vector3(6.31f, 16.193f, 9.167f), 0, 1, 3, false);
        yield return new WaitForSeconds(5);
        gorevText.text = "G�rev: Gizemli objeyi s�p�r.";
        flashDiskCamera.enabled = false;
    }

    public IEnumerator FlashDriveSequence()
    {
        GameObject.Find("DieSon").GetComponent<MoveSon>().enabled = false;
        dontFallCollider.gameObject.SetActive(false);
        flashDisk.SetActive(false);
        // robot ses burda �alacak
        yield return new WaitForSeconds(1f);
        Vector3[] pathArray = new Vector3[waypointLocations.childCount];
        for (int i = 0; i < pathArray.Length; i++)
        {
            pathArray[i] = waypointLocations.GetChild(i).position;
        }
        dieSon.transform.LookAt(pathArray[1]);

        dieSon.transform.DOPath(pathArray, 7f, PathType.Linear, PathMode.Full3D);
        freeLookCamera.GetComponent<AudioListener>().enabled = false; //�al��mayabilir
        fallDownCutsceneCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(8.4f);
        dieSon.transform.rotation = landingPoint.transform.rotation;
        yield return new WaitForSeconds(.2f);
        gorevText.text = "G�rev: Anahtar� al ve evden ��k.";
        dieSon.transform.position = landingPoint.transform.position;
        freeLookCamera.GetComponent<AudioListener>().enabled = true; //�al��mayabilir
        fallDownCutsceneCamera.gameObject.SetActive(false);
        GameObject.Find("DieSon").GetComponent<MoveSon>().enabled = true;
    }
}
