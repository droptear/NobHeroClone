using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen: MonoBehaviour
{
    [SerializeField] private Button _tryAgainButton;

    private void OnEnable()
    {
        _tryAgainButton.onClick.AddListener(RestartScene);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}