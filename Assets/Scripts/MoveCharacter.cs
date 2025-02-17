using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private float _speedCharacter;
    [SerializeField] private float _speedAimMove;

    private Transform[] _aimArray;
    private Rigidbody _rigidbody;
    private GameObject _gunRaycast;
    private GameObject _gunCollider;
    private int _indexWeapon = 1;
    private GameObject _bulletMagazin;
    
    public float Sensivity;
    public int CountMaganzinInInventory;
    public bool _activation = true;


    private void Awake()
    {
        _bulletMagazin = new GameObject("BulletMagazin");
        UpGun._summCount = 0;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        _gunCollider = transform.GetChild(0).gameObject;
        _gunRaycast = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        float AxisX = Input.GetAxis("Horizontal");
        float AxisY = Input.GetAxis("Vertical");

        float moveMouseX = Input.GetAxis("Mouse X");

        Vector3 movement = AxisY * transform.forward + AxisX * transform.right;

        transform.Rotate(0, moveMouseX * Sensivity * Time.deltaTime, 0);

        _rigidbody.velocity =  movement * _speedCharacter * Time.deltaTime * 100f;

        if (UpGun._summCount == 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _gunCollider.SetActive(true);
                _gunRaycast.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _gunCollider.SetActive(false);
                _gunRaycast.SetActive(true);
            }
        }
        

    }

}
