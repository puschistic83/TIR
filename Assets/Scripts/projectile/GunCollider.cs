using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunCollider : MonoBehaviour
{
    [Header("Характеристика оружия")]
    [SerializeField] private float _timeRecharge;
    [SerializeField] private float _ganDelayTime;
    [SerializeField] private Transform _startGanPosition;
    [SerializeField] private BulletCollider _bullet;
    [SerializeField] private float _maxBulletGun;
    [SerializeField] private TextMeshProUGUI _textCountMagazinInInventory;
    [SerializeField] private float _forceSpeed = 10f;
    [SerializeField] private MagazinInterface _magazinInterface;

    [Header("Звуки")]
    [SerializeField] private AudioClip _rechargeSound;
    [SerializeField] private AudioClip _fireSound;

    private bool _rechargeGanActive = true;
    private bool _delayGanActive = true;
    private GameObject _bulletMagazin;
    private AudioSource _audioSource;
    private ParticleSystem _particalFire;
    private MoveCharacter _character;

    public int _summTarget;
    public GameObject[] _bulletsListMagazin;

    private void Awake()
    {
        _bulletMagazin = GameObject.Find("BulletMagazin");
        gameObject.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _particalFire = transform.GetChild(0).GetComponent<ParticleSystem>();
        _character = GameObject.Find("Character").GetComponent<MoveCharacter>();
    }

    public virtual void Update()
    {
        transform.localEulerAngles = new Vector3(Camera.main.transform.eulerAngles.x - 2.5f, -1, 0);
        _textCountMagazinInInventory.text = _character.CountMaganzinInInventory.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_rechargeGanActive && _character.CountMaganzinInInventory > 0 && _bulletMagazin.transform.childCount != _maxBulletGun)
            {
                _character.CountMaganzinInInventory--;
                _magazinInterface.ActivationImageMagazin();
                float summ = _maxBulletGun - _bulletMagazin.transform.childCount;
                StartCoroutine(rechargeSeconds(_timeRecharge, summ));
            }
        }
        if (Input.GetMouseButton(0) && _bulletMagazin.transform.childCount != 0 && _delayGanActive)
        {
            StartCoroutine(DellayGan(_ganDelayTime));
        }
        if (_bulletMagazin.transform.childCount == 0 && _character.CountMaganzinInInventory == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public virtual IEnumerator rechargeSeconds(float time, float bulletAmount)
    {
        _delayGanActive = false;
        _rechargeGanActive = false;
        UpGun._summCount = 0;
        _audioSource.clip = _rechargeSound;

        for (int i = 0; i < bulletAmount; i++)
        {
            if (!_delayGanActive) yield return false;

            GameObject obj = Instantiate(_bullet.gameObject);
            _bulletsListMagazin[i] = obj;
            obj.transform.position = _startGanPosition.position;
            _bullet.Sleep(obj);
            _bulletsListMagazin[i].transform.parent = _bulletMagazin.transform;
            _audioSource.Play();
            yield return new WaitForSeconds(time);

        }
        _delayGanActive = true;
        _rechargeGanActive = true;
        UpGun._summCount = 2;
    }
    public virtual IEnumerator DellayGan(float time)
    {
        _delayGanActive = false;
        Shot(_bulletMagazin.transform.GetChild(_bulletMagazin.transform.childCount - 1).gameObject);
        yield return new WaitForSeconds(time);
        _delayGanActive = true;
    }
    public virtual void Shot(GameObject obj)
    {
        obj.transform.position = _startGanPosition.position;
        obj.SetActive(true);
        _audioSource.clip = _fireSound;
        _audioSource.Play();
        _particalFire.Play();
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * _forceSpeed, ForceMode.Impulse);
        obj.transform.parent = null;

    }
}