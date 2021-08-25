using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
    public delegate void OnColliderEvent();
    public event OnColliderEvent coinTake;
    public event OnColliderEvent cookieTake;
    public event OnColliderEvent finish;

    [SerializeField] private UnityEvent TakeCoinEvent;
    [SerializeField] private UnityEvent TakeCookieEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            TakeCoin(other.gameObject);
        }

        if (other.CompareTag("Cookie"))
        {
            TakeCookie(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Finish();
        }

    }

    private void TakeCoin(GameObject coin)
    {
        coinTake?.Invoke();
        TakeCoinEvent.Invoke();
        Destroy(coin);
    }


    private void TakeCookie(GameObject cookie)
    {
        cookieTake?.Invoke();
        TakeCookieEvent.Invoke();
        Destroy(cookie);
    }

    private void Finish()
    {
        Debug.Log("Достигли финиша!");
        finish?.Invoke();
    }
}
