using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    public GameObject footstep;
    private AudioSource footstepAudio;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);

        // Gets the audio
        footstepAudio = footstep.GetComponent<AudioSource>();

        if (footstepAudio == null)
        {
            Debug.LogError("AudioSource component missing from the footstep GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            PlayFootsteps(0.25f); // Pan right 25%
        }

        if (Input.GetKeyDown("s"))
        {
            PlayFootsteps(-0.20f); // Pan left 25%
        }

        if (Input.GetKeyDown("a"))
        {
            PlayFootsteps(-0.25f); // Pan left 25%
        }

        if (Input.GetKeyDown("d"))
        {
            PlayFootsteps(0.20f);  //Pan right 25%
        }

        if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d")) // stop footstep audio when keys up
        {
            StopFootsteps();
        }
    }

    void PlayFootsteps(float pan)
    {
        if (footstepAudio != null)
        {
            footstep.SetActive(true);
            footstepAudio.panStereo = pan; 
        }
    }

    void StopFootsteps()
    {
        if (footstepAudio != null)
        {
            footstep.SetActive(false); 
        }
    }
}
