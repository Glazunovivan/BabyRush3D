using UnityEngine;

public class CanvasTip : MonoBehaviour
{
    [Tooltip("������ �� Player")]
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private GameObject _panelCounterCoins;
    [SerializeField] private GameObject _panelLoseLevel;
    [SerializeField] private GameObject _panelWinLevel;

    private const string _shopSceneName = "Shop";
    private void Start()
    {
        if (_movePlayer == null)
        {
            Debug.LogWarning("���� _movePlayer ������. �������� ������ �� Player � ���� MovePlayer ��� �����������");
            _movePlayer = FindObjectOfType<MovePlayer>();
        }
        _panelCounterCoins.SetActive(false);
        _panelLoseLevel.SetActive(false);
        _panelWinLevel.SetActive(false);

        //�������
        FindObjectOfType<PlayerCollider>().finish += WinGame;
        FindObjectOfType<PlayerCollider>().obstacle += LoseGame;
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
    public void NextLevel()
    {
        int numberLevel = int.Parse(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        numberLevel++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(numberLevel.ToString());
    }
    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void LoseGame()
    {
        _panelCounterCoins.SetActive(false);
        _panelLoseLevel.SetActive(true);
    }

    private void WinGame()
    {
        _panelCounterCoins.SetActive(false);
        _panelWinLevel.SetActive(true);
    }    

    private void OnDisable()
    {
        FindObjectOfType<PlayerCollider>().finish -= WinGame;
        FindObjectOfType<PlayerCollider>().obstacle -= LoseGame;
    }
}
