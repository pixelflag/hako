using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinGet;
    [SerializeField]
    private AudioClip swish;
    [SerializeField]
    private AudioClip damage;
    [SerializeField]
    private AudioClip dead;
    [SerializeField]
    private AudioClip spawn;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayOneShot(SeType type)
    {
        audio.PlayOneShot(GetClip(type));
    }

    public AudioClip GetClip(SeType type)
    {
        switch (type)
        {
            case SeType.COIN:   return coinGet;
            case SeType.SWISH:  return swish;
            case SeType.SPAWN:  return spawn;
            case SeType.DAMAGE: return damage;
            case SeType.DEAD:   return dead;
        }
        return coinGet;
    }


}
