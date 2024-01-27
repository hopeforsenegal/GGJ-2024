using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Config config;
    public Button play;
    public Button quit;
    public Image background;
    public Image title;

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
        LeanTween.scale(title.gameObject, Vector3.one * 1.5f, 5).setLoopPingPong();
        LeanTween.rotate(title.gameObject, Vector3.one * 90, 5).setLoopPingPong();


        LeanTween.scale(background.gameObject, Vector3.one * 1.5f, 7).setEaseInElastic().setLoopPingPong();
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
