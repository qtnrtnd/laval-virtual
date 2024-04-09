using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    private GameManager _gameManager = GameManager.Instance;
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _gameManager.audioSource.clip = _gameManager.hearthSound;
        _gameManager.audioSource.Play();
        
    }
}
