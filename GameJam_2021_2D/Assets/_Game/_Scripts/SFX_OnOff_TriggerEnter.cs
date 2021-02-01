using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX_OnOff_TriggerEnter : MonoBehaviour
{
    public AudioMixer mixer;

    public bool On_Or_Off;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (On_Or_Off)
        {
            mixer.SetFloat("SoundVol", 0);
        }
        else
        {
            mixer.SetFloat("SoundVol", -80);
        }

        gameObject.SetActive(false);
    }
}
