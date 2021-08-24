using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public delegate void OnCoinTake();
    public event OnCoinTake coinTake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            TakeCoin();
        }

        if (other.CompareTag("Finish"))
        {
            Finish();
        }
    }

    private void TakeCoin()
    {
        coinTake?.Invoke();
    }

    private void Finish()
    {
        Debug.Log("Достигли финиша!");
    }
}
