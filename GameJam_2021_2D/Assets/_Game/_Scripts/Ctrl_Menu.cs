using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Menu : MonoBehaviour
{
    public Fader fader;

    public void Btn_Comenzar ()
    {
        StartCoroutine(Rutina_Comenzar());
    }

    public void Btn_Salir ()
    {
        StartCoroutine(Rutina_Salir());
    }

    IEnumerator Rutina_Comenzar ()
    {
        fader.RayTarget(true);

        yield return fader.Fade(1, fader.duracionFade);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

        yield break;
    }

    IEnumerator Rutina_Salir()
    {
        fader.RayTarget(true);

        yield return fader.Fade(1, fader.duracionFade);

        Application.Quit();

        yield break;
    }
}
