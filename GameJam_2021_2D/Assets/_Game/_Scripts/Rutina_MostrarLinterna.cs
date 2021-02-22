using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rutina_MostrarLinterna : MonoBehaviour
{
    public GameObject go_fader;
    public Button btn;
    public Image img;
    public Sprite spr;
    public AudioSource audioSource;

    Coroutine rutina = null;

    Player player;
    Linterna linterna;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        linterna = FindObjectOfType<Linterna>();
    }

    public void IniciarRutina ()
    {
        if (rutina == null)
            rutina = StartCoroutine(Rutina());
    }

    void Btn_Cerrar ()
    {
        img.gameObject.SetActive(false);
        go_fader.SetActive(false);

        player.enabled = true;
        player.OnActive.Invoke();
        linterna.enabled = true;

        btn.onClick.RemoveListener(delegate { Btn_Cerrar(); });
    }

    IEnumerator Rutina ()
    {
        img.sprite = spr;
        img.gameObject.SetActive(true);

        btn.gameObject.SetActive(false);

        go_fader.SetActive(true);

        player.enabled = false;
        player.OnDeactive.Invoke();
        linterna.enabled = false;

        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        btn.onClick.AddListener(delegate { Btn_Cerrar(); });

        btn.gameObject.SetActive(true);

        yield break;
    }
}
