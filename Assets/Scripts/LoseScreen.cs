using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen: MonoBehaviour
{
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private float _delayOnApperance;

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