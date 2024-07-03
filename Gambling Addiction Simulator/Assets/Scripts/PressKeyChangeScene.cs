using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeyChangeScene : MonoBehaviour
{

    [SerializeField] private string CasinoScene;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerStay(Collider other)
    {
        // when F is pressed the player is sent to the casino scene
        if (other.CompareTag("Player"))
        {

            uiElement.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(CasinoScene);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(false);
        }
    }
}
