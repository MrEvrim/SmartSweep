using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoOutScript : MonoBehaviour
{
    public GameObject fadeoutEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "OutsideCheckpoint")
        {
            fadeoutEffect.SetActive(true);
            StartCoroutine(GoingOutFade());
        }
        IEnumerator GoingOutFade()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("City");
        }
    }
}
