using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeyChangeScene : MonoBehaviour
{

    

    [SerializeField] private GameObject uiElement;

    private void OnTriggerStay(Collider trigger)
    {
        // when F is pressed the player is sent to the casino scene
        if (other.CompareTag("PlayerCapsule"))
        {

            uiElement.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("CasinoScene");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCapsule"))
        {
            uiElement.SetActive(false);
        }
    }
}
