using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject uiElement;
    [SerializeField] private GameObject uiElement2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }

            if (uiElement2 != null)
            {
                uiElement2.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }

            if (uiElement2 != null)
            {
                uiElement2.SetActive(false);
            }
        }
    }
}
