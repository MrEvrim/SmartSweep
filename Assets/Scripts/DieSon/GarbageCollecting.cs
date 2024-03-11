using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG;
using DG.Tweening;

public class GarbageCollecting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Garbage"))
        {
            other.transform.DOMove(transform.position, 2f, false);
            StartCoroutine(DestroyGarbage());
        }
        IEnumerator DestroyGarbage()
        {
            yield return new WaitForSeconds(0.75f);
            Destroy(other.gameObject);
        }
    }
}