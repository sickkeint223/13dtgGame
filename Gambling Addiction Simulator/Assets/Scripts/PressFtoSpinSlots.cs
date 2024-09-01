using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFtoSpinSlots : MonoBehaviour
{

    [SerializeField] private GameObject uiElement;
    [SerializeField] private AudioSource slotsWin;
    [SerializeField] private AudioSource slotsLose;
    [SerializeField] private float probability = 0.1f; // probability to play the slots winning audio
    [SerializeField] private GameObject nameText; 
    [SerializeField] private GameObject winText; // the text to display when the player gets a win
    [SerializeField] private float textDisplayTime = 5f; // how long the text shows for

    private void Start()
    {
        // ui element is active
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }

        if (winText != null)
        {
            winText.SetActive(false);
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
            PlayRandomAudio(); 
        }
    }



    // This basically checks against the probability to see which sound to play then plays it
    
    private void PlayRandomAudio()
    {

        // generates random float number between 0 and 1 
        float randomValue = Random.value;

        if (randomValue < probability)
        {
            slotsWin.Play();
            ShowWinText(); 
        }
        else
        {
            slotsLose.Play();
        }
        
    }

    private void ShowWinText()
    {
        if (winText != null)
        {
            winText.SetActive(true); // displays the win text
            Debug.Log("showing win text");

            if (uiElement != null)  // hiding the uiElement text while the winning text is shown
            {
                uiElement.SetActive(false);
                Debug.Log("hiding press f to spin text with winText showing");
            }

            StartCoroutine(hideWinTextAfterDelay()); // hides the win text after a delay
        }
    }

    private IEnumerator hideWinTextAfterDelay()
    {
        yield return new WaitForSeconds(textDisplayTime); // waits for the time to hide it

        if (winText != null)
        {
            winText.SetActive(false); // hides the text   
            Debug.Log("hiding win text after the delay");

            
            if (uiElement != null) // shows press f to spin text again after the win text is gone
            {
                uiElement.SetActive(true);
                Debug.Log("Showing press f to spin text after the win text is gone");
            }
        }
        

    }

}
