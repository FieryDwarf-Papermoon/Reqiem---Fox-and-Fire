using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMasanger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip GlassAudio;
    [SerializeField] private AudioClip BattleAudio;
    [SerializeField] private AudioClip CastleAudio;
    [SerializeField] private AudioClip MenuAudio;

    public void Start()
    {
        audioSource.clip = GlassAudio;
        audioSource.Play();
    }
    public void MusicGlass()
    {
        audioSource.clip = GlassAudio;
        audioSource.Play();
    }

    public void MusicBattle()
    {
        audioSource.clip=BattleAudio;
        audioSource.Play();
    }

    public void MusicCastle()
    {
        audioSource.clip = CastleAudio;
        audioSource.Play();
    }

}
