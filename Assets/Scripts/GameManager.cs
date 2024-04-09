using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject initialVolume;
    public Animator EyeLidsAnimator;
    public GameObject xrRoot;
    private GameObject player;
    public GameObject startZone;
    public AudioSource audioSource;
    public AudioSource sourcePas;
    public AudioClip fireAlarmSound;
    public AudioClip hearthSound;
    public AudioClip PompierSound;
    public AudioClip pasSound;
    private Volume endScreen;
    private Boolean endFlag = false;
    private float timerEnd = 0f;
    
    private Vector3 OldPosition;

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
        player = GameObject.FindWithTag("Player");
    }

    public void EnterStartZone()
    {
        EyeLidsAnimator.SetBool("EyesOpened", false);
    }

    public void OnClosedEyes()
    { 
        Invoke(nameof(ToFireScene), 2f);
    }

    private void ToFireScene()
    {
        SceneManager.LoadScene("LA_FireZone", LoadSceneMode.Additive);
        EyeLidsAnimator.SetBool("EyesOpened", true);
    }
    
    public void OnOpenedEyes() {}

    public void OnButtonClick()
    {
            audioSource.clip = fireAlarmSound;
            audioSource.volume = 0.5f;
            audioSource.Play();
            //endFlag = true;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == "LA_FireZone")
        {
            Destroy(startZone);
            Destroy(initialVolume);
            endScreen = GameObject.Find("EndVolume").GetComponent<Volume>();

        }
    }

    public void Update()
    {
        
        if (player.transform.position != OldPosition)
        {
            OldPosition = player.transform.position;
        }
        else
        {
            sourcePas.clip = pasSound;
            sourcePas.Play();
            OldPosition = player.transform.position;
        }
        
        if (endFlag)
        {
            if (timerEnd < 1f)
            {
                timerEnd += Time.deltaTime;
                endScreen.weight = Mathf.Lerp(0, 1, timerEnd);
            }
        }
    }
}