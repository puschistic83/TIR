using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hoverFx;
    [SerializeField]
    private AudioClip pressedFx;

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(pressedFx);
    }
}
