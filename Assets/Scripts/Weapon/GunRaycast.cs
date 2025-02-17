using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunRaycast : MonoBehaviour
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


    [Header("Доп объекты для стрельбы")]
    [SerializeField] private GameObject _spriteHit;
    [SerializeField] private int _maxNumberOfPoints;


    [Header("Звуки")]
    [SerializeField] private AudioClip _rechargeSound;
    [SerializeField] private AudioClip _fireSound;

    private TextMeshProUGUI _textTarget;
    private bool _rechargeGanActive = true;
    private bool _delayGanActive = true;
    private GameObject _aim;
    private GameObject _bulletMagazin;
    private RaycastHit _raycastHit;
    private ParticleSystem _particalFire;
    private AudioSource _audioSource;
    private int _summTarget;
    private MoveCharacter _character;

    public GameObject[] BulletsListMagazin;

    private void Awake()
    {
        _bulletMagazin = GameObject.Find("BulletMagazin");
        gameObject.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _particalFire = transform.GetChild(0).GetComponent<ParticleSystem>();
        _textTarget = GameObject.Find("Canvas/NumberOfPoint").GetComponent<TextMeshProUGUI>();
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
            BulletsListMagazin[i] = obj;
            obj.transform.position = _startGanPosition.position;
            _bullet.Sleep(obj);
            BulletsListMagazin[i].transform.parent = _bulletMagazin.transform;
            _audioSource.Play();
            yield return new WaitForSeconds(time);

        }
        _delayGanActive = true;
        _character._activation = true;
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
        Destroy(obj);
        _audioSource.clip = _fireSound;
        _audioSource.Play();
        _particalFire.Play();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _raycastHit)) RaycastFire(_raycastHit);
    }
    public void RaycastFire(RaycastHit _raycastHit)
    {

        if (!_raycastHit.collider.gameObject.GetComponent<Index>()) return;

        for (int i = 0; i < 3; i++)
        {
            if (_raycastHit.collider.gameObject.GetComponent<Index>()._index == i + 1)
            {
                Debug.Log(i + 1);
                FillAmountImage((i + 1), _textTarget);
                _raycastHit.collider.gameObject.GetComponentInParent<CountTarget>()._countTarget += i + 1;
                if (_raycastHit.collider.gameObject.GetComponentInParent<CountTarget>()._countTarget >= 10)
                {
                    Destroy(_raycastHit.collider.transform.parent.gameObject);
                }

            }
        }
        GameObject obj = Instantiate(_spriteHit);
        obj.transform.eulerAngles = _raycastHit.transform.eulerAngles;
        obj.transform.position = _raycastHit.point - new Vector3(0, 0, 0.3f);
        obj.transform.parent = _raycastHit.transform;
    }
    private void FillAmountImage(int countXp, TextMeshProUGUI text)
    {
        _summTarget += countXp;
        text.text = ($"Заработанные очки: {_summTarget}/ {_maxNumberOfPoints}").ToString();
        if (_summTarget >= _maxNumberOfPoints)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4) SceneManager.LoadScene(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Winer");
        }
    }
}