using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip HitObstacle;
    [SerializeField] AudioClip LevelSuccess;
    [SerializeField] ParticleSystem ParticlesSuccess;
    [SerializeField] ParticleSystem ParticlesHit;

    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

    private void Start()

    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()

    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.leftBracketKey.wasPressedThisFrame)
        {
            LoadPreviousLevel();
        }

        else if (Keyboard.current.rightBracketKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }

        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (!isControllable || !isCollidable) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                StartSuccesSeq();
                break;

            default:
                StartCrashSeq();
                break;
        }
    }

    void StartSuccesSeq()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(LevelSuccess);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        ParticlesSuccess.Play();
    }

    void StartCrashSeq()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(HitObstacle);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        ParticlesHit.Play();
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        Debug.Log("Starting level: " + nextScene);

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

   void LoadPreviousLevel()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    int totalScenes = SceneManager.sceneCountInBuildSettings;

    int prevScene = (currentScene - 1 + totalScenes) % totalScenes;

    Debug.Log("Loading level: " + prevScene);
    SceneManager.LoadScene(prevScene);
}

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
