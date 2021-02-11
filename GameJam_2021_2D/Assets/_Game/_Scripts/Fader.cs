using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour 
{
	public Image imgFader;

	public float duracionFade;

	public void Set_Alfa (float nuevoAlfa)
	{
		imgFader.color = new Color (imgFader.color.r, imgFader.color.g, imgFader.color.b, nuevoAlfa);
	}

	public void RayTarget (bool nuevoValor)
	{
		imgFader.raycastTarget = nuevoValor;
	}

    public void set_Escala (float nuevoTamaño_x, float nuevoTamaño_y)
    {
        imgFader.transform.localScale = new Vector2(nuevoTamaño_x, nuevoTamaño_y);
    }

	public IEnumerator Fade (float alfaFinal, float duracion)
	{
		float fadeVel = Mathf.Abs (imgFader.color.a - alfaFinal) / duracion;

		while (!Mathf.Approximately (imgFader.color.a, alfaFinal))
		{
			float fadeAlfa = imgFader.color.a;

			fadeAlfa = Mathf.MoveTowards(fadeAlfa, alfaFinal, fadeVel * Time.unscaledDeltaTime);

			Set_Alfa (fadeAlfa);

			yield return null;
		}

		yield return null;
		StopCoroutine(Fade(alfaFinal, duracion));
	}

    public IEnumerator Fade_Scale(float tamañoFinal, float duracion)
    {
        float fadeVel = Mathf.Abs(imgFader.transform.localScale.x - tamañoFinal) / duracion;

        while (!Mathf.Approximately(imgFader.transform.localScale.x, tamañoFinal))
        {
            float fadeScale = imgFader.transform.localScale.x;

            fadeScale = Mathf.MoveTowards(fadeScale, tamañoFinal, fadeVel * Time.unscaledDeltaTime);

            set_Escala(fadeScale, fadeScale);

            yield return null;
        }

        yield return null;
        StopCoroutine(Fade_Scale(tamañoFinal, duracion));
    }
}
