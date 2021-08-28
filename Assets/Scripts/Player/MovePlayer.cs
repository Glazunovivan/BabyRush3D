using System;
using UnityEngine;
using PathCreation;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class MovePlayer : MonoBehaviour
{
    private PathCreator _pathCreator;
    private float _distanceTravelled;
    private Slide _slideComponent;

    [Tooltip("Скорость перемещения")]
    [SerializeField] private float _speed;
    [SerializeField] private bool _isRun = false;
    [Tooltip("Время на ускорение (в секундах, по умолчанию 0)")]
    [SerializeField] private float _secondBoostSpeed = 0;
    [Tooltip("Множитель ускорения")]
    [SerializeField] private float _multiplierBoostSpeed = 1f;

    //для движения с rigidbody
    private Rigidbody _rigidbody;

    private StatePlayer _statePlayer;

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _pathCreator = FindObjectOfType<PathCreator>();
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        transform.position = new Vector3(_pathCreator.path.GetPointAtDistance(_distanceTravelled).x,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).y,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).z);
        _slideComponent = GetComponentInChildren<Slide>();
        _slideComponent.OnDisable();
        _statePlayer = GetComponentInChildren<StatePlayer>();
        //событие
        FindObjectOfType<PlayerCollider>().finish += StopRun;
        FindObjectOfType<PlayerCollider>().obstacle += StopRunIntoObstacle;
        //ускорение
        FindObjectOfType<PlayerCollider>().cookieTake += BoostSpeed;
    }


    private void Update()
    {
        if (_isRun)
        {
            TransformPositionPlayer();
        }
    }
    private void OnDisable()
    {
        FindObjectOfType<PlayerCollider>().finish -= StopRun;
        FindObjectOfType<PlayerCollider>().obstacle -= StopRunIntoObstacle;
        FindObjectOfType<PlayerCollider>().cookieTake -= BoostSpeed;
    }

    private void TransformPositionPlayer()
    {
        _distanceTravelled +=  _speed * Time.deltaTime;
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        transform.position = new Vector3(_pathCreator.path.GetPointAtDistance(_distanceTravelled).x,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).y,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).z);
    }

    public void StartRun()
    {
        _isRun = true;
        _slideComponent.OnEnable();
        _statePlayer.Run();
    }

    private void StopRun()
    {
        _rigidbody.velocity = new Vector3(0,0,0);
        _slideComponent.OnEnable();
        _isRun = false;
    }

    private void StopRunIntoObstacle()
    {
        _isRun = false;
    }
    private void BoostSpeed()
    {
        StartCoroutine(BoostingSpeed());
    }
    private IEnumerator BoostingSpeed()
    {
        _speed += _multiplierBoostSpeed;
        yield return new WaitForSeconds(_secondBoostSpeed);
        _speed -= _multiplierBoostSpeed; 
    }
}
