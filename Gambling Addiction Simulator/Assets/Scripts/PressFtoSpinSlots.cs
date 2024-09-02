using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFtoSpinSlots : MonoBehaviour
{

    [SerializeField] private GameObject uiElement; // the text
    [SerializeField] private AudioSource slotsWin; // winning audio
    [SerializeField] private AudioSource slotsLose; // losing audio
    [SerializeField] private float probability = 0.1f; // probability to play the slots winning audio
    [SerializeField] private GameObject nameText; // player name text
    [SerializeField] private GameObject winText; // the text to display when the player gets a win
    [SerializeField] private float textDisplayTime = 5f; // how long the text shows for
    [SerializeField] private GameObject outOfMoney; // shows text after player runs out of money

    private int Losses = 0; // counts how many losses after the player gets a win
    private bool playerWonLast = false; // sees if player won 


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

        if (winText != null)
        {
            outOfMoney.SetActive(false);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {

            if (Losses < 4) // once player has lost 4 times it no longer shows the "press f to spin" text
            {
                uiElement.SetActive(true);
            }
            else
            {
                ShowOutMoneyText();
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

    private void Update() 
  {
        // Checks for input from player
        if (uiElement.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (Losses < 4) // lets player keep spinning if less than 4 losses
            {
                PlayRandomAudio(); 
            }
            else
            {
                Debug.Log("ran out of money");
                ShowOutMoneyText();
            }
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
            Losses = 0;
            playerWonLast = true;
        }
        else
        {
            slotsLose.Play();

            if (playerWonLast) // only counts losses after a win
            {
                Losses++;
                Debug.Log("losses: " + Losses); // shows how many losses

                if (Losses >= 4)
                {
                    ShowOutMoneyText();
                }
            }
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

    private void ShowOutMoneyText()
    {
        if (outOfMoney != null)
        {
            outOfMoney.SetActive(true);
            Debug.Log("no money, showing text");

            StartCoroutine(hideOutOfMoneyTextAfterDelay(7f));
        }

        if (uiElement != null)
        {
            uiElement.SetActive(false); // hides press f to spin text after player lost all money
        }
    }

    private IEnumerator hideOutOfMoneyTextAfterDelay(float delay)

    {
        yield return new WaitForSeconds(delay); // waits for the float time

        if (outOfMoney != null)
        {
            outOfMoney.SetActive(false); // hides the text   
            Debug.Log("hiding out of money text");
        }
    }
}
