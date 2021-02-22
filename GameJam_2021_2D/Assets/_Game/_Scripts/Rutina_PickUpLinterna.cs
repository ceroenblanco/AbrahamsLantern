using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Clips
{
    public float retrazo;
    public AudioClip clip;
}

public class Rutina_PickUpLinterna : MonoBehaviour
{
    public AudioSource audioSource;
    public Clips[] clips;
    [Space]
    public UnityEvent OnClipsEnd;

    Coroutine rutina = null;

    public void IniciarRutina()
    {
        if (rutina == null)
            rutina = StartCoroutine(Rutina());
    }

    IEnumerator Rutina ()
    {
        int i = 0;

        while (i < clips.Length)
        {
            yield return new WaitForSeconds(clips[i].retrazo);

            audioSource.Stop();

            audioSource.clip = clips[i].clip;

            audioSource.Play();

            i++;

            if (i < clips.Length)
                yield return new WaitForSeconds(audioSource.clip.length);
        }

        yield return null;

        OnClipsEnd.Invoke();

        yield break;
    }
}
