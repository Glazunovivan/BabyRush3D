using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StatePlayer : MonoBehaviour
{
    #region Animation
    private Animator _animator;
    private int _idleHash = Animator.StringToHash("Idle");
    private int _joggingHash = Animator.StringToHash("Jogging");
    private int _stunnedHash = Animator.StringToHash("Stunned");
    private int _victoryIdleHash = Animator.StringToHash("Victory Idle");
    private int _joggingKickHash = Animator.StringToHash("JoggingKick");
    #endregion

    private void Start()
    {
        _animator = GetComponent<Animator>();
        FindObjectOfType<PlayerCollider>().obstacle += Stunned;
        FindObjectOfType<PlayerCollider>().finish += Victory;
    }

    public void Run()
    {
        _animator.SetBool("IsRun", true);
    }

    public void Victory()
    {
        _animator.SetTrigger("Victory");
    }
    
    public void Kick()
    {
        _animator.SetTrigger("Kick");
    }

    public void Stunned()
    {
        _animator.SetTrigger("Stunned");
    }

    private void OnDestroy()
    {
        FindObjectOfType<PlayerCollider>().obstacle -= Stunned;
        FindObjectOfType<PlayerCollider>().finish -= Victory;
    }
}
