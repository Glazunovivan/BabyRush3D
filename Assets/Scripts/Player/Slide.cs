using UnityEngine;
using UnityEngine.EventSystems;

public class Slide : MonoBehaviour
{
    //чтобы не выходить за границы
    [Tooltip("Значение выхода за границы (от центра)")]
    //[SerializeField] private float _offsetSlide = 0.6f;
    [SerializeField] private float _speedSlide = 7;
    //делитель, чтобы корректировать скорость перемещения персонажа, иначе получается 1:1
    //и скольжение по плоскости = скорость света в вакууме
    private int _divider = 200;
    private float _difference;

    private float? lastMousePoint = null;

    private void Start()
    {
        _difference = 0;
    }
    private void Update()
    {

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

    public void OnEnable()
    {
        enabled = true;
    }
    public void OnDisable()
    {
        enabled = false;
    }
}
