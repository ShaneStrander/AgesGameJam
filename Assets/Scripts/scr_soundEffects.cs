using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class scr_soundEffects : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip sfJump, sfBounce, sfBubble, sfButtonSelect, sfCratePop, sfDeathSound;
    
    public void playSound(AudioClip sfx)
    {
        sound.clip = sfx;
        sound.Play();
    }
}
