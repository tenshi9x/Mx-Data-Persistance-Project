using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField inputField;
    public string playerName;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //playerName = inputField.text;
        MenuManager.Instance.playerName = inputField.text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
