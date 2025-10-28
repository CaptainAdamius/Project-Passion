using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] string SceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName);    
    }

    public void ExitGame()
    {
        #if (UNITY_EDITOR)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
            Application.Quit();
        }
        #endif
    }
}
