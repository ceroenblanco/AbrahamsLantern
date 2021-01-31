using UnityEngine.Audio;
using System;
using UnityEngine;

[Serializable]
public class Sonidos
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup AMG;

    [Range(0, 1f)]
    public float volume;

    [Range(-1f, 3f)]
    public float pitch;

    public bool playOnAwake;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
	public Sonidos[] sonidos;

	public static AudioManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sonidos s in sonidos)
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.outputAudioMixerGroup = s.AMG;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;

			s.source.playOnAwake = s.playOnAwake;
			s.source.loop = s.loop;
		}
	}

	void Start()
	{
        foreach (Sonidos s in sonidos)
        {
            if (s.playOnAwake)
            {
                Play(s.name);
            }
        }
    }

	public void Play (string name)
	{
		Sonidos s = Array.Find (sonidos, Sonido => Sonido.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sonido: " + name + " no encontrado!");
			return;
		}



		s.source.Play ();
	}

	public void Volumen (string name, float newVol)
	{
		Sonidos s = Array.Find (sonidos, Sonido => Sonido.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sonido: " + name + " no encontrado!");
			return;
		}


		s.source.volume = newVol;
	}

	public void Pitch (string name, float newPitch)
	{
		Sonidos s = Array.Find (sonidos, Sonido => Sonido.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sonido: " + name + " no encontrado!");
			return;
		}


		s.source.pitch = newPitch;
	}

	public void AumentarFrecuencia (string name, float addPitch)
	{
		Sonidos s = Array.Find (sonidos, Sonido => Sonido.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sonido: " + name + " no encontrado!");
			return;
		}


		s.source.pitch += addPitch;
	}

	public void Stop(string name)
	{
		Sonidos s = Array.Find (sonidos, Sonido => Sonido.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sonido: " + name + " no encontrado!");
			return;
		}


		s.source.Stop ();
	}
}
