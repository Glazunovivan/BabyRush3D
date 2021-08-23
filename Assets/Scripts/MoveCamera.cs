using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private Transform _pointForCamera;
    private Vector3 _position;

    void Start()
    {
        _player = FindObjectOfType<MovePlayer>().gameObject.transform;

        _position = _pointForCamera.InverseTransformPoint(transform.position);
        //transform.SetParent(_player);
    }

    private void Update()
    {
        var currentPosition = _pointForCamera.TransformPoint(_position);
        transform.position = currentPosition;
        transform.LookAt(_player);   
    }
}
