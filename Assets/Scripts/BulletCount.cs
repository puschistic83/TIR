using UnityEngine;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public GameObject _bulletMagazin;
    private TextMeshProUGUI _textOutput;

    private void Start()
    {
        _bulletMagazin = GameObject.Find("BulletMagazin");
        _textOutput = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textOutput.text = _bulletMagazin.transform.childCount.ToString();
    }
}
