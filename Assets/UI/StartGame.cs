using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SrartGame : MonoBehaviour
{
    [SerializeField] private float visibleSpeed = 1;   
    [SerializeField] private CanvasGroup menu;
    [SerializeField] private CanvasGroup nazvanie1;
    [SerializeField] private CanvasGroup nazvanie2;
    [SerializeField] private CanvasGroup nazvanie3;

    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
       
        menu.alpha = 0;
        nazvanie1.alpha = 0;
        nazvanie2.alpha = 0;
        nazvanie3.alpha = 0;
        
    }

    IEnumerator ScreenActive()
    {
        yield return new WaitForSeconds(visibleSpeed);
        menu.DOFade(1, 3).SetLink(gameObject);
        yield return new WaitForSeconds(1);
        nazvanie1.DOFade(1,1);
        _audioSource.PlayOneShot(_audioClip);
        yield return new WaitForSeconds(1);
        nazvanie2.DOFade(1, 1);
        _audioSource.PlayOneShot(_audioClip);
        yield return new WaitForSeconds(1);
        nazvanie3.DOFade(1, 1);
        _audioSource.PlayOneShot(_audioClip);

    }
    


    private void Start()
    {
        StartCoroutine(ScreenActive());
    }
    
}
