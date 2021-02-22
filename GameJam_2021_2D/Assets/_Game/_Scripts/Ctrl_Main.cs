using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ctrl_Main : MonoBehaviour
{
    Player player;

    public Fader fader;
    public TextMeshProUGUI txt;
    public Button btn_reiniciar;

    [Tooltip("Nombre de la pista de sonido de fondo actual")]
    public string nombreMusicaActual;
    AudioManager audioManager;

    public GameObject go_panelPause;

    Coroutine rutina;

    private void Awake()
    {
        fader.Set_Alfa(1);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        StartCoroutine(Rutina_Inicial());
    }

    private void Update()
    {
        if (!go_panelPause.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            player.enabled = false;

            Time.timeScale = 0;

            go_panelPause.SetActive(true);
        }
    }

    void Reiniciar ()
    {
        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            if (string.IsNullOrEmpty(nombreMusicaActual))
            {
                audioManager.Stop(nombreMusicaActual);

                audioManager.Play("Musica1");
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Btn_CerrarPanelPause ()
    {
        Time.timeScale = 1;

        go_panelPause.SetActive(false);

        player.enabled = true;
    }

    public void Btn_Salir ()
    {
        if (rutina == null)
            rutina = StartCoroutine(Rutina_Salir());
    }

    public void GameOver ()
    {
        player.gameObject.SetActive(false);

        txt.gameObject.SetActive(true);

        btn_reiniciar.onClick.AddListener(delegate { Reiniciar(); });

        fader.gameObject.SetActive(true);
    }

    public void ReproducirSonido (string newSonido)
    {
        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
            audioManager.Play(newSonido);
    }

    IEnumerator Rutina_Inicial ()
    {
        fader.gameObject.SetActive(true);

        fader.RayTarget(false);

        yield return fader.Fade(0, fader.duracionFade);

        fader.gameObject.SetActive(false);

        yield break;
    }

    IEnumerator Rutina_Salir ()
    {
        fader.gameObject.SetActive(true);

        fader.RayTarget(true);

        yield return fader.Fade(1, fader.duracionFade);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        rutina = null;

        yield break;
    }
}
