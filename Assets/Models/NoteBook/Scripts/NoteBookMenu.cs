using UnityEngine;


public class NoteBookMenu : MonoBehaviour
{
    private Animator _an;

    private void Awake()
    {
        _an = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _an.SetBool("Menu", !_an.GetBool("Menu"));
        }
    }
    
}
