using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Config config;
    public Button play;
    public Button quit;

    protected void Start()
    {
        var a = FindObjectOfType<AudioSource>();
        a.clip = config.Menu;
        a.Play();

        play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(config.firstLevel);
        });
        quit.onClick.AddListener(() =>
        {
            QuitGame();
        });
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }


    private static void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
