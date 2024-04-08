using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Logger _logger;
    
    public static GameManager Instance; // A static reference to the GameManager instance

    void Awake()
    {
        if(Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        } else if(Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
    
    private void Start()
    {
        _logger = new Logger(GameObject.Find("Debug").GetComponent<TMPro.TextMeshProUGUI>());
        _logger.Log("GameManager started");
    }

    public void EnterStartZone()
    {
        _logger.Log("Player entered start zone");
        //switch to next scene
        
        SceneManager.LoadScene("LA_FireZone");
        _logger.Log("Scene switched to LA_FireZone");
        
    }
}
