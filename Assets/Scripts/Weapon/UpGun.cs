using UnityEngine;

public class UpGun : MonoBehaviour
{
    [SerializeField] private GameObject _gunArm;

    public static int _summCount;
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _gunArm.SetActive(true);
            _summCount++;
            Destroy(gameObject);
        }
    }
}
