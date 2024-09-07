using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneFadeOut : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public bool fadeout = false;
    public float fadeTime;

    // Update is called once per frame
    void Update()
    {
        if(fadeout == true)
        {
            if(canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= fadeTime * Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void fadeOut()
    {
        fadeout = true;
    }
}
