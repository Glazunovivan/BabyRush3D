using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovePlayer : MonoBehaviour
{
    private PathCreator _pathCreator;
    private float _distanceTravelled;

    [SerializeField] private float _speed;
    [SerializeField] private bool _isRun = false;

    //для движения с rigidbody
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        //_rigidbody = GetComponent<Rigidbody>();
        _pathCreator = FindObjectOfType<PathCreator>();
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        transform.position = new Vector3(_pathCreator.path.GetPointAtDistance(_distanceTravelled).x,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).y,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).z);
    }

    private void Update()
    {
        if (_isRun)
        {
            RunPlayer();
        }
    }

    private void RunPlayer()
    {
        TransformPositionPlayer();
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
    }
    public void StopRun()
    {
        _rigidbody.velocity = new Vector3(0,0,0);
        _isRun = false;
    }
    public void StopRunIntoObstacle()
    {
        _isRun = false;
    }

}
