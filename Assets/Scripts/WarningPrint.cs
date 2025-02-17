using UnityEngine;

public class WarningPrint : MonoBehaviour
{
    private static Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void WarningActivation()
    {
        _animator.Play("Base Layer.OnWarning");
    }
}