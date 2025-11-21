using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusiqueEnBoucle : MonoBehaviour
{
    [Header("Paramètres Musique")]
    public AudioClip musique;
    [Range(0f, 1f)]
    public float volume = 0.7f;
    public bool jouerAuDémarrage = true;
    
    private AudioSource audioSource;

    void Awake()
    {
        // Créer l'AudioSource s'il n'existe pas
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Configurer l'AudioSource
        audioSource.clip = musique;
        audioSource.volume = volume;
        audioSource.loop = true; // ← IMPORTANT: Activer la boucle
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        // Démarrer la musique si demandé
        if (jouerAuDémarrage && musique != null)
        {
            JouerMusique();
        }
    }

    // Méthode pour démarrer la musique
    public void JouerMusique()
    {
        if (musique != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Méthode pour arrêter la musique
    public void ArrêterMusique()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Méthode pour mettre en pause
    public void MettreEnPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // Méthode pour reprendre
    public void Reprendre()
    {
        if (!audioSource.isPlaying && musique != null)
        {
            audioSource.UnPause();
        }
    }

    // Méthode pour changer de musique
    public void ChangerMusique(AudioClip nouvelleMusique)
    {
        bool étaitEnLecture = audioSource.isPlaying;
        
        audioSource.Stop();
        audioSource.clip = nouvelleMusique;
        
        if (étaitEnLecture && nouvelleMusique != null)
        {
            audioSource.Play();
        }
    }

    // Méthode pour changer le volume
    public void ChangerVolume(float nouveauVolume)
    {
        volume = Mathf.Clamp01(nouveauVolume);
        audioSource.volume = volume;
    }

    // Méthode pour vérifier si la musique joue
    public bool EstEnLecture()
    {
        return audioSource.isPlaying;
    }
}