using UnityEngine;
using UnityEngine.EventSystems;

public class Slide : MonoBehaviour
{
    //private FloatingJoystick _joystick;

    //чтобы не выходить за границы
    private float _offsetSlide = 0.6f;
    private float _currentPositionX = 0;
    private float _speedSlide = 7;
    private float difference = 0;

    private float? lastMousePoint = null;

    private void Start()
    {
        //_joystick = FindObjectOfType<FloatingJoystick>();
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
            difference = Input.mousePosition.x - lastMousePoint.Value;
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + difference/700, -0.7f, 0.7f), transform.localPosition.y, transform.localPosition.z);
            lastMousePoint = Input.mousePosition.x;
        }

        #region Other
        //transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, _currentPositionX, Time.deltaTime * _speedSlide), transform.localPosition.y, transform.localPosition.z);
        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, vectorTarget, Time.deltaTime*_speedSlide);
        //transform.localPosition = new Vector3(_touchControl.DirectionX, transform.localPosition.y, transform.localPosition.z);
        #endregion
    }
}
