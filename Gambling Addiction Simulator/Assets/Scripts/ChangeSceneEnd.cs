using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneEnd : MonoBehaviour
{
    [SerializeField] private GameObject uiElement;
    [SerializeField] private string Scene;


    private void Start()
    {
        // ui element is active
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(false);
        }
    }

    private void Update()
    {
        // Checking for input from the player
        if (uiElement.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(Scene);
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);
    }

}
