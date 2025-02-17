using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class Zametki : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Animator _an;

    private void Awake()
    {
        _an = GetComponent<Animator>();
        _text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    private void OnMouseEnter()
    {
        _an.SetBool("ActOpen", true);
    }
    private void OnMouseOver()
    {
        _text.GetComponent<TMP_Text>().color = Color.white;
    }
    private void OnMouseExit()
    {
        _an.SetBool("ActOpen", false);
        _text.GetComponent<TMP_Text>().color = Color.black;

    }
}
