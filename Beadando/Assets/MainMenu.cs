using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text text;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Awake()
    {
        text.text = string.Format("Last Score:{0}", score);
    }
    private void OnEnable()
    {
        score = PlayerPrefs.GetInt("score", 0);
    }
}
