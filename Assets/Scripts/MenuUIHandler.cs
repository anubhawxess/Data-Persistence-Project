#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text HighScore;
    public InputField mainInputField;

    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            GameManager.Instance.currentPlayer = input.text;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = $"Best Score : {GameManager.Instance.bestPlayer} : {GameManager.Instance.score}";
        mainInputField.text = GameManager.Instance.currentPlayer;
        mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });
    }

    public void StartNew()
    {
        GameManager.Instance.currentPlayer = mainInputField.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
