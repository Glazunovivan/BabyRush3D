using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public delegate void OnColliderEvent();
    public event OnColliderEvent coinTake;
    public event OnColliderEvent finish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            TakeCoin(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Finish();
        }
    }

    private void TakeCoin(GameObject coin)
    {
        coinTake?.Invoke();
        Destroy(coin);
    }

    private void Finish()
    {
        Debug.Log("Достигли финиша!");
        finish?.Invoke();
    }
}
