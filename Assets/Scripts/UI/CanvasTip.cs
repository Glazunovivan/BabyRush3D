using UnityEngine;

public class CanvasTip : MonoBehaviour
{

    [Tooltip("Ссылка на Player")]
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private GameObject _panelCounterCoins;

    private const string _shopSceneName = "Shop";
    private void Start()
    {
        if (_movePlayer == null)
        {
            Debug.LogWarning("Поле _movePlayer пустое. Добавьте ссылку на Player в поле MovePlayer для оптимизации");
            _movePlayer = FindObjectOfType<MovePlayer>();
        }
        
        _panelCounterCoins.SetActive(false);
    }
    public void StartGame(GameObject hidenPanel)
    {
        hidenPanel.SetActive(false);
        _panelCounterCoins.SetActive(true);
        _movePlayer.StartRun();
    }

    public void OpenShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_shopSceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
