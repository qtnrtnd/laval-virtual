using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Logger logger;
    public Animator EyeLidsAnimator;
    public GameObject xrRoot;
    public Canvas debugCanvas;
    public GameObject startZone;
    public AudioSource audioSource;
    public AudioClip fireAlarmSound;

    public static GameManager Instance; // A static reference to the GameManager instance

    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(
                gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
    
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        DontDestroyOnLoad(xrRoot);
        DontDestroyOnLoad(debugCanvas);
        logger = new Logger(GameObject.Find("Debug").GetComponent<TMPro.TextMeshProUGUI>());
        logger.Log("GameManager started");
    }

    public void EnterStartZone()
    {
        logger.Log("Player entered start zone");
        EyeLidsAnimator.SetBool("EyesOpened", false);
    }

    public void OnClosedEyes()
    {
        logger.Log("Closed eyes event");
        Invoke(nameof(ToFireScene), 2f);
    }

    private void ToFireScene()
    {
        SceneManager.LoadScene("LA_FireZone", LoadSceneMode.Additive);
        EyeLidsAnimator.SetBool("EyesOpened", true);
        logger.Log("Scene switched to LA_FireZone");
    }
    
    public void OnOpenedEyes() {}

    public void OnButtonClick()
    {
        audioSource.clip = fireAlarmSound;
        audioSource.Play();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == "LA_FireZone")
        {
            Destroy(startZone);
        }
    }
}