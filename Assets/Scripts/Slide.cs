using UnityEngine;
using UnityEngine.EventSystems;

public class Slide : MonoBehaviour
{
    //private FloatingJoystick _joystick;

    //чтобы не выходить за границы
    [Tooltip("Значение выхода за границы (от центра)")]
    [SerializeField] private float _offsetSlide = 0.6f;
    //private float _currentPositionX = 0;
    [SerializeField] private float _speedSlide = 7;
    //делитель, чтобы корректировать скорость перемещения персонажа, иначе получается 1:1
    //и пермещение по плоскости = скорость света в вакууме
    private int _divider = 200;
    private float _difference;

    private float? lastMousePoint = null;

    private void Start()
    {
        //_joystick = FindObjectOfType<FloatingJoystick>();
        _difference = 0;
    }
    private void Update()
    {
        //if (_joystick.Horizontal != 0)
        //{
        //    _currentPositionX = _joystick.Horizontal * _offsetSlide;
        //    Debug.Log(_currentPositionX);
        //}
        //transform.localPosition = new Vector3(_currentPositionX, transform.localPosition.y, transform.localPosition.z);

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePoint = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastMousePoint = null;
        }
        if (lastMousePoint != null)
        {
            _difference = Input.mousePosition.x - lastMousePoint.Value;
            Debug.Log(_difference);
            //с границами
            //transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + _difference/700, -_offsetSlide, _offsetSlide), transform.localPosition.y, transform.localPosition.z);
            //без границ
            transform.localPosition = new Vector3(transform.localPosition.x + _difference / _divider, transform.localPosition.y, transform.localPosition.z);
            lastMousePoint = Input.mousePosition.x;
        }

        #region Other
        //transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, _currentPositionX, Time.deltaTime * _speedSlide), transform.localPosition.y, transform.localPosition.z);
        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, vectorTarget, Time.deltaTime*_speedSlide);
        //transform.localPosition = new Vector3(_touchControl.DirectionX, transform.localPosition.y, transform.localPosition.z);
        #endregion
    }
}
