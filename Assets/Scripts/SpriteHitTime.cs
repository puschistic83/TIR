using System.Collections;
using UnityEngine;

public class SpriteHitTime : MonoBehaviour
{
    [SerializeField] private float _time;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_spriteRenderer.color.a > 0)
        {
            StartCoroutine(TimeLive());
            _spriteRenderer.color -= new Color(0, 0, 0, 0.001f);
        }
        else Destroy(gameObject);

    }
    public IEnumerator TimeLive()
    {
        yield return new WaitForSeconds(_time);
    }
}
