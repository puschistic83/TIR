using UnityEngine;

public class Magazin : MonoBehaviour
{
    [SerializeField] private GunRaycast _gunRaycast;
    [SerializeField] private GunCollider _gunCollider;
    [SerializeField] private MagazinInterface _magazin;

    private MoveCharacter _character;
    private void Start()
    {
        _character = GameObject.Find("Character").GetComponent<MoveCharacter>();
    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (UpGun._summCount == 2)
            {
                _character.CountMaganzinInInventory++;
                _magazin.ActivationImageMagazin();
                Destroy(gameObject);
            }
            else WarningPrint.WarningActivation();
        }

    }
}
