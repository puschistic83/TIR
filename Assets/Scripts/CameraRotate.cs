using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _sensivity;
    private float _mouseX;

    [SerializeField] private float _maxXRotate, _minXRotate;

    private void Start()
    {
        _sensivity = transform.parent.gameObject.GetComponent<MoveCharacter>().Sensivity;
    }
    void Update()
    {
        _mouseX = -Input.GetAxis("Mouse Y") * _sensivity * Time.deltaTime;
        _mouseX = Mathf.Clamp(_mouseX, _minXRotate, _maxXRotate);
        transform.Rotate(_mouseX, 0, 0);
        //transform.eulerAngles = new Vector3(Mathf.Clamp(-axisY * _sensivity * Time.deltaTime, _minXRotate, _maxXRotate), 0, 0);
    }
}
