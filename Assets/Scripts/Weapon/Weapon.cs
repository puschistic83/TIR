//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Weapon : MonoBehaviour
//{
//    [Header("Характеристика оружия")]
//    [SerializeField] protected private float _timeRecharge;
//    [SerializeField] protected private float _ganDelayTime;
//    [SerializeField] protected private Transform _startGanPosition;
//    [SerializeField] protected private Bullet _bullet;
//    [SerializeField] protected private float _maxBulletGun;

//    protected private bool _rechargeGanActive = true;
//    protected private bool _delayGanActive = true;
//    protected private float _forceSpeed = 150f;
//    protected private GameObject _aim;
//    [SerializeField] protected private GameObject _bulletMagazin;
//    protected private RaycastHit _raycastHit;

//    public GameObject[] _bulletsListMagazin;


//    private void Awake()
//    {
//        _bulletMagazin = new GameObject("BulletMagazin");
//    }

//    public virtual void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            if (_rechargeGanActive)
//            {
//                float summ = _maxBulletGun - _bulletMagazin.transform.childCount;
//                StartCoroutine(rechargeSeconds(_timeRecharge, summ));
//            }
//        }
//        if (Input.GetMouseButton(0) && _bulletMagazin.transform.childCount != 0 && _delayGanActive)
//        {
//            StartCoroutine(DellayGan(_ganDelayTime));
//        }
//    }
//    public virtual IEnumerator rechargeSeconds(float time, float bulletAmount)
//    {
//        _rechargeGanActive = false;

//        for (int i = 0; i < bulletAmount; i++)
//        {
//            if (!_delayGanActive) yield return false;

//            GameObject obj = Instantiate(_bullet.gameObject);
//            _bulletsListMagazin[i] = obj;
//            obj.transform.position = _startGanPosition.position;
//            _bullet.Sleep(obj);
//            _bulletsListMagazin[i].transform.parent = _bulletMagazin.transform;
//            yield return new WaitForSeconds(time);

//        }
//        yield return _rechargeGanActive = true;

//    }
//    public virtual IEnumerator DellayGan(float time)
//    {
//        _delayGanActive = false;
//        Shot(_bulletMagazin.transform.GetChild(_bulletMagazin.transform.childCount - 1).gameObject);
//        yield return new WaitForSeconds(time);
//        _delayGanActive = true;
//    }
//    public virtual void Shot(GameObject obj)
//    {
//        Debug.Log(_startGanPosition);
//        obj.transform.position = _startGanPosition.position;
//        obj.SetActive(true);
//        obj.GetComponent<Rigidbody>().AddForce(transform.forward * _forceSpeed, ForceMode.Impulse);
//        obj.transform.parent = null;
//        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _raycastHit)) _bullet.RaycastFire(_raycastHit);
//    }
//}

