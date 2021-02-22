using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Rutina_UltimaNota : MonoBehaviour
{
    public GameObject go_panelGameOver, go_imgFoto;
    public Fader fader;
    public Button btn;
    public AudioSource audioSource;

    Player player;
    Coroutine rutina;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Btn_Continuar ()
    {
        if (rutina == null)
            rutina = StartCoroutine(Rutina_Final());
    }

    public void ActivarRutina ()
    {
        if (rutina == null)
            rutina = StartCoroutine(Rutina());
    }

    IEnumerator Rutina ()
    {
        player.enabled = false;
        player.OnDeactive.Invoke();
        player.anim.SetBool("EnMovimiento", false);
        player.linterna.enabled = false;

        go_imgFoto.SetActive(true);

        btn.gameObject.SetActive(false);
        go_panelGameOver.SetActive(true);

        btn.onClick.AddListener(delegate { Btn_Continuar(); });

        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        btn.gameObject.SetActive(true);

        rutina = null;

        yield break;
    }

    IEnumerator Rutina_Final ()
    {
        fader.RayTarget(true);

        fader.gameObject.SetActive(true);

        yield return fader.Fade(1, fader.duracionFade);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        yield break;
    }
}
