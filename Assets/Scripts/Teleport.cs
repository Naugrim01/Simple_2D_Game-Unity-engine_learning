using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {

            SceneManager.LoadScene(nextLevel);//
            Time.timeScale = 1f;//

        }

    }


}
