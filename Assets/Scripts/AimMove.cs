using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{
    [Header("Настройки перемещения")]
    [SerializeField] private float _maxX = 5f;
    [SerializeField] private float _minX = -5f;
    [SerializeField] private float _minY = -5f;
    [SerializeField] private float _maxY = 5f;

    private float _speed;

    public Vector3 TargetPosition {  get; private set; }

    public float Speed = 5f;

    private void Start()
    {
        NewTargetPosition();
    }

    private void Update()
    {
        MoveTargetPosition();

        if (transform.localPosition == TargetPosition)
        {
            NewTargetPosition();
        }
    }

    private void NewTargetPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);
        TargetPosition = new Vector3(randomX, randomY, TargetPosition.z);
    }
     
    private void MoveTargetPosition()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, _speed * Time.deltaTime);
    }

}
