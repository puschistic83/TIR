//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Machine : Weapon
//{
//    private void Awake()
//    {
//        _bulletsListMagazin = new GameObject[(int)_maxBulletGun];
//        _bulletMagazin = GameObject.Find("BulletMagazin");
//    }
//    public override void Update()
//    {
//        transform.localEulerAngles = new Vector3(Camera.main.transform.eulerAngles.x - 7, -3, 0);

//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            if (_rechargeGanActive)
//            {
//                float summ = _maxBulletGun - _bulletMagazin.transform.childCount;
//                StartCoroutine(base.rechargeSeconds(_timeRecharge, summ));
//            }
//        }
//        if (Input.GetMouseButton(0) && _bulletMagazin.transform.childCount != 0 && _delayGanActive)
//        {
//            StartCoroutine(base.DellayGan(_ganDelayTime));
//        }
//    }

//}
