using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
    public delegate void OnColliderEvent();
    public event OnColliderEvent coinTake;
    public event OnColliderEvent cookieTake;
    public event OnColliderEvent finish;
    public event OnColliderEvent obstacle;

    public delegate void OnCollisionEvent();
    public event OnCollisionEvent fallIntoWater;

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

        if (other.CompareTag("Obstacle"))
        {
            Obstacle();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            Debug.Log("Упали в воду");
            fallIntoWater?.Invoke();
            //отключаем слайд
            GetComponent<Slide>().enabled = false;
            //отвязываем камеру
            GetComponentInChildren<Camera>().transform.SetParent(null);
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

        FindObjectOfType<SaveSystem>().Save();
    }

    private void Obstacle()
    {
        Debug.Log("Ударились в стену :(");
        obstacle?.Invoke();
    }
}
