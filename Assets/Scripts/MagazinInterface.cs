using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagazinInterface : MonoBehaviour
{
    [SerializeField] private float _speedActivationImageMagazin;

    private bool _activation;
    private float _colorA;

    void Update()
    {

        if (_activation)
        {
            _colorA += _speedActivationImageMagazin;
        }
        else
        {
            _colorA -= _speedActivationImageMagazin;
        }

        if (gameObject.GetComponent<SpriteRenderer>().color.a >= 1) _activation = false;


        _colorA = Mathf.Clamp(_colorA, 0, 1);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, _colorA);
        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, _colorA);
    }
    public void ActivationImageMagazin()
    {
        _activation = true;
    }

}
