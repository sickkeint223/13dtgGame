using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSceneMusicDelay : MonoBehaviour
{

    [SerializeField] private AudioSource darkMusic;
    [SerializeField] private float musicDelayTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DarkMusicDelay(musicDelayTime));
    }
    
    private IEnumerator DarkMusicDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

        if(darkMusic != null)
        {
            darkMusic.Play();
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
   
}
