using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nota : MonoBehaviour
{
    public SpriteRenderer sprRnd;
    public Fader fader;
    public Button btn_cerrar;
    public AudioSource audioSource;

    Player player;

    void Cerrar ()
    {
        audioSource.Stop();

        fader.RayTarget(false);
        fader.gameObject.SetActive(false);

        transform.localScale = Vector3.one;
        sprRnd.sortingLayerName = "Player";
        sprRnd.sortingOrder = 0;

        player.enabled = true;
        player.OnActive.Invoke();

        Time.timeScale = 1;

        btn_cerrar.onClick.RemoveListener(delegate { Cerrar(); });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player = collision.transform.GetComponent<Player>();
            player.enabled = false;
            player.OnDeactive.Invoke();

            Time.timeScale = 0;

            sprRnd.sortingLayerName = "UI";
            sprRnd.sortingOrder = 1;

            fader.RayTarget(true);
            fader.gameObject.SetActive(true);

            transform.localScale = new Vector3(transform.localScale.x * 5, transform.localScale.y * 5, transform.localScale.z);

            audioSource.Play();

            btn_cerrar.onClick.AddListener(delegate { Cerrar(); });
        }
    }
}
