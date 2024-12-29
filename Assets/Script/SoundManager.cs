using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource; // Komponen AudioSource untuk memutar suara

    [Header("Audio Clips")]
    public List<AudioClip> audioClips; // Daftar lagu atau suara yang tersedia

    /// <summary>
    /// Memutar suara atau lagu berdasarkan indeks dari daftar.
    /// </summary>
    /// <param name="clipIndex">Indeks audio dalam daftar.</param>
    public void PlayAudio(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Count)
        {
            audioSource.Stop(); // Berhenti memutar audio saat ini
            audioSource.clip = audioClips[clipIndex]; // Atur audio clip baru
            audioSource.Play(); // Mainkan audio
        }
        else
        {
            Debug.LogWarning("Clip index out of range!");
        }
    }
}
