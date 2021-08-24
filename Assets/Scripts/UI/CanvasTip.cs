using UnityEngine;

public class CanvasTip : MonoBehaviour
{
    [Tooltip("Ссылка на Player")]
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private GameObject _panelCounterCoins;
    [SerializeField] private GameObject _panelLoseLevel;
    [SerializeField] private GameObject _panelWinLevel;

    private const string _shopSceneName = "Shop";
    private void Start()
    {
        if (_movePlayer == null)
        {
            Debug.LogWarning("Поле _movePlayer пустое. Добавьте ссылку на Player в поле MovePlayer для оптимизации");
            _movePlayer = FindObjectOfType<MovePlayer>();
        }
        FindObjectOfType<PlayerCollider>().finish += WinGame;

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

    public void LoseGame()
    {

    }

    public void WinGame()
    {
        _panelCounterCoins.SetActive(false);
        _panelWinLevel.SetActive(true);
    }

    public void NextLevel(string nameLevel)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameLevel);
    }

    private void OnDisable()
    {
        FindObjectOfType<PlayerCollider>().finish -= WinGame;
    }
}
