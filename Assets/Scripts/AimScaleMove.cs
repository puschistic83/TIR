using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AimScaleMove : MonoBehaviour
{
    [Header("Скорость раздвижения прицела при хотьбе")]
    [SerializeField] private float _speedAimMove;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }
    public async void MoveAim()
    {
        while (transform.position != _startPosition * 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition * 2, _speedAimMove * Time.deltaTime);
            await Task.Yield();
        }
    }
}
