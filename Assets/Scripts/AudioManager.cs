using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip easyGameMusic;
    public AudioClip hardGameMusic;
    public AudioClip lostGameMusic;

    private AudioSource audioSource;
    private static AudioManager instance;

    void Awake()
    {
        // Evitar dulpicados
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusicForCurrentScene();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }

    void PlayMusicForCurrentScene()
    {
        AudioClip newClip = null;

        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenuScene":
                newClip = mainMenuMusic;
                break;
            case "EasyGameScene":
                newClip = easyGameMusic;
                break;
            case "HardGameScene":
                newClip = hardGameMusic;
                break;
            case "LostGameScene":
                newClip = lostGameMusic;
                break;
            default:
                newClip = mainMenuMusic;
                break;
        }

        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}
