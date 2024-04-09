using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    private GameManager _gameManager;
    private Logger _logger;
    
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.EnterStartZone();
        }
    }
}
